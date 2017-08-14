using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using YourNamespace.Models;


namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {

       
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
            }
        
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            System.Console.WriteLine(user);
            if (ModelState.IsValid)
            {
                DbConnector.Execute($"INSERT INTO User (FirstName, LastName, Email, Password, CreatedAt, UpdatedAt) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}', NOW(), NOW())");
                return View("Result");
            } else {
                return View("Index");
            }
        }   
          
        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            List<Dictionary<string, object>> dbuser = DbConnector.Query($"SELECT * FROM User WHERE Email = '{user.Email}'");
            System.Console.WriteLine(dbuser);
            return View("Result");
        
        }
        // [HttpPost]
        // [Route("show")]
        // public IActionResult 
    }
}
