using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;
using System.Net.Mail;
using System.Net;
using System;
using Microsoft.Extensions.Configuration;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository;
using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Repository.IRepository;
using System.Linq;


namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantManagerRepository _restaurantManagerRepository;
        public LoginController(IAccountRepository accountRepository, IUserRepository userRepository,IRestaurantManagerRepository restaurantManagerRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _restaurantManagerRepository = restaurantManagerRepository;
        }

        [Route("sendOTP")]
        [HttpPost]
        public IActionResult SendOTP(string email)
        {
            email = email.Replace("%40", "@");
            if (SendActivationEmail(email) == false)
            {
                return BadRequest(new ResponseObject
                {
                    Message = "Email alredy exist!"
                }); 
            }
            return Ok();
        }
        [Route("tryOTP")]
        [HttpPost]
        public IActionResult CheckOTP(string email,string otp)
        {
            email = email.Replace("%40", "@");
            ActiveCodeRepositoryImp repo = new ActiveCodeRepositoryImp();
            string code = repo.GetActiveCode(email);
            if(code != null && code.Equals(otp))
            {
                return Ok();
            }
            return Unauthorized();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var acc = _accountRepository.GetAll().FirstOrDefault(a => a.Email.Equals(model.email) && a.Password.Equals(model.password));
            if(acc == null)
            {
                return Unauthorized();
            }
            if (acc.Status != 1)
            {
                return Unauthorized(new ResponseObject
                {
                    Message = "Account is banned!"
                } );
            }
            else
            {
                acc.Password = "";
                if (acc.Role.Equals("user")&&acc.UserId!=null)
                {
                    var uinf = _userRepository.Get(acc.UserId.Value);
                    acc.User = uinf;
                }else if (acc.Role.Equals("manager"))
                {
                    var rinf = _restaurantManagerRepository.Get(acc.ResManagerId.Value);
                    acc.ResManager = rinf;
                }
                return Ok(acc);
            }
        }
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register(RegisterModel model)
        {
            // Check if the email already exists
            if (_accountRepository.GetByEmail(model.Email)!=null)
            {
                return Conflict("An account with the provided email already exists.");
            }

            // Create a new user
            var user = new User
            {
                Name = model.Name,
                Avatar = null,
                Phone = model.Phone,
                IsPremium = false,
                Status = 1,
                IsDeleted = false
            };
            _userRepository.Create(user);
            user = _userRepository.GetByPhone(model.Phone);
            // Create a new account
            var account = new Account
            {
                Email = model.Email,
                Password = model.Password,
                Status = 1,
                Role = "user",
                UserId = user.UserId,
                createDate = DateTime.Now,
            };
            _accountRepository.Create(account);
            return Ok("Account registered successfully.");
        }


        private bool SendActivationEmail(string email)
        {
            if (_accountRepository.GetByEmail(email) != null)
            {
                return false;
            }
            // gen code, update to database
            Random random = new Random();
            string rdn = "";
            for(int i = 0; i < 6; i++)
            {
                rdn += (random.Next(0,9)).ToString();
            }
            ActiveCodeRepositoryImp repo = new ActiveCodeRepositoryImp();
            repo.CreateActiveCode(email, rdn);

            // end
            // send otp
            using (MailMessage mm = new MailMessage("efoodcompanyservice@gmail.com", email))
            {
                mm.Subject = "Active Code";

                mm.Body = "Your active code is: " + rdn;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("efoodcompanyservice@gmail.com", "ihyxaxrsytxnwcbo");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            return true;
        }
    }
}
