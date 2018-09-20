﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private static Dictionary<string, string> Cheeses = new Dictionary<string, string>();

        public static bool IsAlpha(string name)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach(char character in name.ToLower())
            {
                if(!(alphabet.Contains(character)))
                {
                    return false;
                }
            }

            return true;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Cheese/Add")]
        public IActionResult NewCheese(string cheeseName, string cheeseDescription)
        {
            if ((String.IsNullOrEmpty(cheeseName)) || !(IsAlpha(cheeseName)))
            {
                string error = "The cheese name is required and must be alphabetic.";
                ViewBag.error = error;

                return View("Add");
            }

            Cheeses.Add(cheeseName, cheeseDescription);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;

            return View();
        }

        [HttpPost]
        [Route("Cheese/Remove")]
        public IActionResult DeleteCheese(string[] cheeseNames)
        {
            foreach(string name in cheeseNames)
            {
                Cheeses.Remove(name);
            }

            return Redirect("/Cheese");
        }
    }
}