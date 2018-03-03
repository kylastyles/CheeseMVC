using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            // Add the new cheese to my existing cheeses, using model binding on the default constructor
            CheeseData.Add(newCheese);

            /* below is an example of "property initializer method", utilizing the default constructor
             * same as:
             * Cheese newCheese = new Cheese();
             * newCheese.Name = name;
             * newCheese.Description = description;

            Cheese newCheese = new Cheese
            {
                Description = description,
                Name = name
            }; */

            return Redirect("/Cheese"); 
        }

        [HttpGet]
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Edit(int cheeseId)
        { 
            ViewBag.cheeseToEdit = CheeseData.GetById(cheeseId);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            CheeseData.EditCheese(cheeseId, name, description);

            return View();
        }
    }
}
