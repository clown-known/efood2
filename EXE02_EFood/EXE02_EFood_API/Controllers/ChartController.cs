using EXE02_EFood_API.BusinessObject;
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
    public class ChartController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPremium_hisRepository _premiumHisRepository;
        private readonly IPremiumRepository _premiumRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;


        public ChartController(ITransactionRepository transactionRepository, IPremium_hisRepository premium_HisRepository, IPremiumRepository premiumRepository, IAccountRepository accountRepository, IUserRepository userRepository,IRestaurantRepository restaurantRepository)
        {
            _transactionRepository = transactionRepository;
            _premiumRepository = premiumRepository;
            _premiumHisRepository = premium_HisRepository;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }
        [HttpGet]
        public IActionResult Home()
        {
            int count = 0;
            ChartApiModel result = new ChartApiModel();

            //total user
            result.user = _userRepository.GetAll().Count;

            //total premium
            result.premium = _premiumHisRepository.GetAll().Count;

            // new premium
            List<PremiumHi> premiumList = _premiumHisRepository.GetAll();
            foreach (PremiumHi premium in premiumList)
            {
                if(premium.TimeStart!=null&&premium.TimeStart.Value.Month == DateTime.Now.Month&&premium.TimeStart.Value.Year == DateTime.Now.Year)
                {
                    count++;
                }
            }
            result.newPremium = count;
            int thism = count;
            count = 0;
            // last premium
            foreach (PremiumHi premium in premiumList)
            {
                if(premium.TimeStart!=null&&premium.TimeStart.Value.AddMonths(1).Month == DateTime.Now.Month&&premium.TimeStart.Value.AddMonths(1).Year == DateTime.Now.Year)
                {
                    count++;
                }
            }
            int last = count;

            result.onemonth = last;
            if (last == 0)
            {
                last = 1;
            }

            result.pers = thism * 100 - last * 100 / last;
            count = 0;


            result.thismonth = thism;
            // new User
            List<Account> userList = _accountRepository.GetAll();
            foreach (Account acc in userList)
            {
                if (acc.createDate != null && acc.createDate.Value.Month == DateTime.Now.Month && acc.createDate.Value.Year == DateTime.Now.Year)
                {
                    count++;
                }
            }
            result.newUser = count;
            count=0;

            // premium unexpired
            result.premiumUnexpired = premiumList.Where(a => a.TimeEnd > DateTime.Now).Count();

            // total restaurant
            result.rest = _restaurantRepository.GetAll().Count;

            // pending
            result.pending = _transactionRepository.GetAll().Where(a => a.Note.Equals("pending")).Count();
            return Ok(result);
        }
    }
}
