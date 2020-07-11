using SiyaJuwarkarProject.Manager.Account;
using SiyaJuwarkarProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiyaJuwarkarProject.Controllers.Account
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountManager _IAccountManager;
        // GET: Account


        

        public ActionResult Index()
        {
            var accman = new AccountManager();
            accman.GetCandidates();
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            var accountmanager = new AccountManager();
            if(accountmanager.UserExists(email,password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
            
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SetupPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        [AcceptVerbs("GET", "POST")]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (registerModel != null)
            {
                TempData["registerModel"] = registerModel;
                return RedirectToAction("SetupPassword");
                //     var response = _IAccountManager.Register(registerModel);
                //if(response)

            }
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SetupPassword")]
        [AcceptVerbs("GET", "POST")]
        public ActionResult SetupPassword(RegisterModel registerModel)
        {
            if (registerModel != null)
            {
                var Data = TempData["registerModel"] as RegisterModel;
                Data.ConfirmPassword = registerModel.ConfirmPassword;
                Data.Password = registerModel.Password;
                AccountManager accManager = new AccountManager();
                var response = accManager.Register(Data);
                if (response)
                {
                    return RedirectToAction("Login");
                }

            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

   
    }

 


}