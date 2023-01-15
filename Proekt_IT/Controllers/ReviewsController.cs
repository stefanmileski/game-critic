using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proekt_IT.Models;

namespace Proekt_IT.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Game);
            return View(reviews.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult MyReviews()
        {
            List<Review> myReviews = new List<Review>();
            foreach(Review review in db.Reviews)
            {
                if(review.UserEmail.Equals(User.Identity.Name))
                {
                    myReviews.Add(review);
                }
            }
            return View(myReviews);
        }

        public ActionResult UserReviews(string mail)
        {
            List<Review> reviews = new List<Review>();
            foreach (Review review in db.Reviews)
            {
                if (review.UserEmail.Equals(mail))
                {
                    reviews.Add(review);
                }
            }
            ViewBag.mail = mail;
            return View(reviews);
        }
    }
}
