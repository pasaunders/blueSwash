using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using blueSwash.Models;

namespace blueSwash.Controllers
{
    public class UserController : Controller
    {
        private IdeaContext _context;
        public UserController(IdeaContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("Main");
        }
        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(logRegCompositeModel incoming)
        {
            RegistrationViewModel registrationData = incoming.registration;
            TryValidateModel(registrationData);
            if (ModelState.IsValid)
            {
                Users newUser = new Users();
                PasswordHasher<Users> hasher = new PasswordHasher<Users>();
                newUser.name = registrationData.name;
                newUser.alias = registrationData.alias;
                newUser.email = registrationData.email;
                newUser.password = hasher.HashPassword(newUser, registrationData.password);
                _context.users.Add(newUser);
                _context.SaveChanges();
                System.Console.WriteLine("registration validates");
            } else {
                System.Console.WriteLine("no validation here");
            }
            return RedirectToAction("Main");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(logRegCompositeModel incoming)
        {
            loginViewModel loginData = incoming.login;
            TryValidateModel(loginData);
            if (ModelState.IsValid)
            {
                Users user = _context.users.FirstOrDefault(entry => entry.alias == loginData.alias);
                if (user != null)
                {
                    PasswordHasher<Users> hasher = new PasswordHasher<Users>();
                    if (hasher.VerifyHashedPassword(user, user.password, loginData.password) != 0)
                    {
                        HttpContext.Session.SetInt32("currentUserId", user.usersId);
                        return RedirectToAction("list", "Idea");
                    }
                }
            }
            return RedirectToAction("Main");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Main");
        }
        [HttpGet]
        [Route("users/{id}")]
        public IActionResult Profile(int id)
        {
            UserDetail userData = new UserDetail
            {
                user = _context.users.FirstOrDefault(item => item.usersId == id)
            };
            return View(userData);
        }
    }
}
