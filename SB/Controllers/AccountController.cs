﻿using Microsoft.AspNetCore.Mvc;


using SB.Models;

namespace SB.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            
            return View();
        }
        
        public IActionResult Logout() 
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Register(Register register) 
        {
            // todo try{} catch{} unique email

            User user = new User {Age = register.Age , City= register.City ,
            Email=register.Email , Password =register.Password , Phone = register.Phone };

            SwapBookDbContext swapBookDbContext = new SwapBookDbContext();

            swapBookDbContext.Add(user);

            swapBookDbContext.SaveChanges();

            HttpContext.Session.SetString("email", user.Email ?? "Not Specified");

            HttpContext.Session.SetInt32("user",user.Id);
            
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            SwapBookDbContext dbContext = new SwapBookDbContext();
            
            var user = dbContext.Users.FirstOrDefault(u => u.Email == login.Email && u.Password==login.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("email", user.Email);

                HttpContext.Session.SetInt32("user", user.Id);

                return RedirectToAction("Index", "Home");
            }
            else 
            {
                return View(); // todo view for accsess denied reenter red line 
            }
           
        }
    }
}
