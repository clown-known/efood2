using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremium_hisRepository _premiumHisRepository;
        private readonly IPremiumRepository _premiumRepository;
        private readonly ITransactionRepository _transactionRepository;

        public PremiumController(IPremium_hisRepository premiumHisRepository, IPremiumRepository premiumRepository, ITransactionRepository transactionRepository)
        {
            _premiumHisRepository = premiumHisRepository;
            _premiumRepository = premiumRepository;
            _transactionRepository = transactionRepository;
        }

        [HttpGet("value")]
        public IActionResult GetAllPremiums()
        {
            var premiumHis = _premiumRepository.GetAll();
            return Ok(premiumHis);
        }[HttpGet]
        public IActionResult GetAllPremiumHis()
        {
            var premiumHis = _premiumHisRepository.GetAll();
            return Ok(premiumHis);
        }

        [HttpGet("{id}")]
        public IActionResult GetPremiumHisOfUser(int idu)
        {
            var premiumHis = _premiumHisRepository.GetByUserId(idu);
            if (premiumHis == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Premium history not found",
                    Data = premiumHis
                });
            }
            return Ok(premiumHis);
        }

        [HttpPost]
        public IActionResult CreatePremiumHis(PremiumHi premiumHis,int Premium_id)
        {
            premiumHis.Status = 2; //pending
            premiumHis.TimeStart = null;
            premiumHis.TimeEnd = null;
            premiumHis.PremiumId = Premium_id;
            premiumHis.Premium = _premiumRepository.Get(Premium_id);
            _premiumHisRepository.Create(premiumHis);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePremiumHis(int id, PremiumHi premiumHis)
        {
            var existingPremiumHis = _premiumHisRepository.Get(id);
            if (existingPremiumHis == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Premium history not found",
                    Data = premiumHis
                });
            }

            existingPremiumHis.UserId = premiumHis.UserId;
            existingPremiumHis.PremiumId = premiumHis.PremiumId;
            existingPremiumHis.TimeStart = premiumHis.TimeStart;
            existingPremiumHis.TimeEnd = premiumHis.TimeEnd;

            _premiumHisRepository.Update(existingPremiumHis);

            return NoContent();
        }
        [HttpPut("active/{id}")]
        public IActionResult ActivePremium(int id)
        {
            var existingPremiumHis = _premiumHisRepository.Get(id);
            if (existingPremiumHis == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Premium history not found",
                });
            }
            existingPremiumHis.TimeStart = DateTime.Now; 
            var time = _premiumRepository.Get(id).Period;
            existingPremiumHis.TimeEnd = DateTime.Now.AddMonths(Int32.Parse(time));
            _premiumHisRepository.Update(existingPremiumHis);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePremiumHis(int id)
        {
            var premiumHis = _premiumHisRepository.Get(id);
            if (premiumHis == null)
            {
                return NotFound();
            }

            _premiumHisRepository.Delete(id);

            return NoContent();
        }
    }

}
