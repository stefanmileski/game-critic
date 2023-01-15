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
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Genre).Include(g => g.Publisher);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [Authorize(Roles = "Administrator, Editor")]
        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,GenreId,PublisherId,Name,Description,ImageUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", game.GenreId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", game.PublisherId);
            return View(game);
        }

        [Authorize(Roles = "Administrator, Editor")]
        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", game.GenreId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", game.PublisherId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,GenreId,PublisherId,Name,Description,ImageUrl")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", game.GenreId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", game.PublisherId);
            return View(game);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Administrator, Editor, User")]
        public ActionResult AddReview(int id)
        {
            List<int> ratings = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                ratings.Add(i);
            }
            ViewBag.ratings = ratings;
            Review model = new Review();
            Game game = db.Games.Find(id);
            game.GameId = id;
            model.Game = game;
            model.GameId = game.GameId;
            model.UserEmail = User.Identity.Name;
            ViewBag.Game = game;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            Game game = db.Games.Find(review.GameId);
            if (game.Reviews == null)
            {
                game.Reviews = new List<Review>();
            }
            game.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowReviews(int id)
        {
            var reviews = db.Games.Find(id).Reviews;
            return View(reviews.ToList());
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}
