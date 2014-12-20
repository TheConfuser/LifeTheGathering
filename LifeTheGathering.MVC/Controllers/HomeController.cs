using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LifeTheGathering.MVC.Models;
using LifeTheGathering.MVC.ViewModels;

namespace LifeTheGathering.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var currentUser = (User)Session["currentUser"];
            if(currentUser == null)
                return View();
            else
                return RedirectToAction("Game");
        }

        public ActionResult CreateUser(string name)
        {
            Session["currentUser"] = new User(name);
            return RedirectToAction("Game");
        }

        public ActionResult Game(string message)
        {
            var currentUser = (User)Session["currentUser"];
            if (currentUser == null)
                return View("Index");
            else
            {
                var model = new GameViewModel();
                model.User = (User)Session["currentUser"];
                if (message != null)
                    model.Message = message;
                return View(model);
            }
        }
        
        public ActionResult GatherFood()
        {
            var currentUser = (User) Session["currentUser"];
            currentUser.Food += 1;
            return RedirectToAction("Game");
        }

        public ActionResult GatherWood()
        {
            var currentUser = (User)Session["currentUser"];
            currentUser.Wood += 1;
            return RedirectToAction("Game");
        }

        public ActionResult BuySnail()
        {
            var currentUser = GetUser();
            if(currentUser != null)
            {
                if (currentUser.Food >= 5 && currentUser.Wood >= 3)
                {
                    currentUser.Food -= 5;
                    currentUser.Wood -= 3;
                    currentUser.Snails += 1;
                }
                else
                    return RedirectToAction("Game", new { message = "Du har inte råd att köpa snigel :(" });
                if (currentUser.Snails >= 5)
                    return RedirectToAction("Win");
            }
            return RedirectToAction("Game");
        }

        public ActionResult Win()
        {
            var currentUser = GetUser();
            var model = new IndexViewModel();
            model.Name = currentUser.Name;
            return View(model);
        }

        private User GetUser()
        {
            var currentUser = (User)Session["currentUser"];
            if (currentUser == null)
                return null;
            else
                return currentUser;
        }
    }
}