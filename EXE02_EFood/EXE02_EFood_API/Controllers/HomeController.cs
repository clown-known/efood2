﻿using AutoMapper;
using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDishRepository dishRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IDishCategoryRepository dishCategoryRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IMenuRepository menuRepository;


        public HomeController(IDishRepository dishRepository, ICategoryRepository categoryRepository, IDishCategoryRepository dishCategoryRepository, IRestaurantRepository restaurantRepository, IMenuRepository menuRepository)
        {
            this.dishRepository = dishRepository;
            this.categoryRepository = categoryRepository;
            this.dishCategoryRepository = dishCategoryRepository;
            this.restaurantRepository = restaurantRepository;
            this.menuRepository = menuRepository;
        }
        [HttpGet]
        public IActionResult Home(string cate)
        {
            HomeApiModel result = new HomeApiModel();
            if (cate == null || cate.Equals("") || cate.Equals("0"))
                result.res = restaurantRepository.GetAll();
            else
            {
                int idd = Int32.Parse(cate);
                foreach (int d in dishCategoryRepository.GetDishesByCategory(idd))
                {
                    var resid = menuRepository.GetRes(d);
                    var res = restaurantRepository.Get(resid);
                    if(!result.res.Contains(res))
                        result.res.Add(res);
                }
            }
            result.cate.Add(new CateHome { name = "all" });
            foreach (Category c in categoryRepository.GetAll())
            {
                result.cate.Add(new CateHome { id = c.CategoryId, name = c.CategoryName });
            }
            List<Dish> dishList = dishRepository.GetAll();
            for(int i = 0; i <= 5; i++)
            {
                Random rnd = new Random();
                int randIndex = rnd.Next(dishList.Count);
                result.slider.Add(dishList[randIndex]);
            }
            return Ok(result);
        }
        
    }
}
