using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.Models.Data;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public static bool IsAlpha(string name)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (char character in name.ToLower())
            {
                if (!(alphabet.Contains(character)))
                {
                    return false;
                }
            }

            return true;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.findAll();

            return View();
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addedCheese)
        {
            if (!(ModelState.IsValid))
            {
                return View(addedCheese);

            }

            if ((String.IsNullOrEmpty(addedCheese.Name)) || !(IsAlpha(addedCheese.Name)))
            {
                string error = "The cheese name is required and must be alphabetic.";
                ViewBag.error = error;

                return View(addedCheese);

            }

            Cheese newCheese = new Cheese
            {
                Name = addedCheese.Name,
                Description = addedCheese.Description,
                Type = addedCheese.Type
            };

            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

       
        public IActionResult Edit(int cheeseId)
        {
            Cheese cheese = CheeseData.findById(cheeseId);

            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel
            {
                CheeseId = cheeseId,
                Name = cheese.Name,
                Description = cheese.Description,
                Type = cheese.Type
            };
            return View(editCheeseViewModel);
        }

        [Route("/cheese/edit/{cheeseId}")]
        public IActionResult EditPath(int cheeseId)
        {
            Cheese cheese = CheeseData.findById(cheeseId);
            Console.WriteLine("edit with path variable.");

            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel
            {
                CheeseId = cheeseId,
                Name = cheese.Name,
                Description = cheese.Description,
                Type = cheese.Type
            };
            return View("Edit", editCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheese)
        {
            if (!(ModelState.IsValid))
            {
                return View(editCheese);

            }

            if ((String.IsNullOrEmpty(editCheese.Name)) || !(IsAlpha(editCheese.Name)))
            {
                string error = "The cheese name is required and must be alphabetic.";
                ViewBag.error = error;

                return View(editCheese);

            }

            Cheese cheese = CheeseData.findById(editCheese.CheeseId);

            cheese.Name = editCheese.Name;
            cheese.Description = editCheese.Description;
            cheese.Type = editCheese.Type;


            return Redirect("/Cheese");
        }
        public IActionResult Remove()
        {
            ViewBag.cheeses = CheeseData.findAll();

            return View();
        }

        [HttpPost]
        [Route("Cheese/Remove")]
        public IActionResult DeleteCheese(int[] cheeseIds)
        {
            CheeseData.deleteById(cheeseIds);

            return Redirect("/Cheese");
        }
    }
}
