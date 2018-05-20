using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVCSite.Models;

namespace FirstMVCSite.Controllers
{
    public class ReviewsController : Controller
    {
        public ActionResult Index()
        {
            var model =
                from r in _reviews
                orderby r.Country
                select r;

            return View (model);
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try 
            {
                return RedirectToAction ("Index");
            } 
            catch
            {
                return View ();
            }
        }

        static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview {
                Id = 1,
                Name = "Cinnamon Club",
                City = "Paris",
                Country = "France",
                Rating = 10
            },
            new RestaurantReview{
                Id = 2,
                Name = "Marrakesh",
                City = "D.C.",
                Country = "USA",
                Rating = 10
            },
            new RestaurantReview{
                Id = 3,
                Name = "The House of Elliot",
                City = "Ghent",
                Country = "Belgium",
                Rating = 10
            },
            new RestaurantReview{
                Id = 4,
                Name = "The Green Pig",
                City = "Salt Lake City",
                Country = "USA",
                Rating = 10
            }
        };
    }
}