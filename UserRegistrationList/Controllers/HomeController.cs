using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserRegistrationList.Models;
using DataLibrary;
using DataLibrary.Logic;


namespace UserRegistrationList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NewUser()

        {
            ViewBag.Message = "User sign-up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = UserProcessor.CreateUser(model.FirstName, model.LastName, model.EmailAddress);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult UserList()
        {
            ViewBag.Message = "User List";

            
            var data = UserProcessor.LoadUserList();
            List<UserModel> users = new List<UserModel>();
            int x = 1;


            /*    foreach (var item in data)
                {
                    users.Add(new UserModel()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        EmailAddress = item.EmailAddress,
                        ConfirmEmailAddress = item.EmailAddress

                    });
            



                }*/
            foreach (var item in data)
            {
                UserModel model = new UserModel();
                model.Id = item.Id;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;
                model.EmailAddress = item.EmailAddress;
                model.ConfirmEmailAddress = item.EmailAddress;

                users.Add(model);
                x += 1;
            }
            return View(users);

            }

            

       

           





    

        public IActionResult Proba()

           
        {

            var data = UserProcessor.LoadUserList();
            Console.WriteLine(data);
            return View();
        }

    }
}


