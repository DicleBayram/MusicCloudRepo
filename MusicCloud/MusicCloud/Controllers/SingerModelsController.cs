using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicCloud.Binders;
using MusicCloud.Models;

namespace MusicCloud.Controllers
{
    public class SingerModelsController : Controller
    {
        private MusicCloudEntities db = new MusicCloudEntities();

        // GET: SingerModels
        public ActionResult Index()
        {
            ICollection<SingerModel> singerModel = new List<SingerModel>();
            SingerBinder singerBinder = new SingerBinder();
            singerModel = singerBinder.Bind(db.Singer.ToList());
            return View(singerModel);
        }

        // GET: SingerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singerModel = db.Singer.Find(id);
            if (singerModel == null)
            {
                return HttpNotFound();
            }
            return View(singerModel);
        }

        // GET: SingerModels/Create
        public ActionResult Create()
        {
            if (!Convert.ToBoolean(Session["IsAdmin"]))
            {
                return HttpNotFound("You are not admin");

            }
            return View();
        }

        // POST: SingerModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SingerModel singerModel)
        {
            if (ModelState.IsValid)
            {
                SingerBinder singerBinder = new SingerBinder();
                Singer singer = singerBinder.Bind(singerModel);
                db.Singer.Add(singer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(singerModel);
        }

        // GET: SingerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singerModel = db.Singer.Find(id);
            if (singerModel == null)
            {
                return HttpNotFound();
            }
            return View(singerModel);
        }

        // POST: SingerModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SingerModel singerModel)
        {
            if (ModelState.IsValid)
            {
                SingerBinder singerBinder = new SingerBinder();
                Singer singer = new Singer();
                singer = singerBinder.Bind(singerModel);
                db.Entry(singer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(singerModel);
        }

        // GET: SingerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Singer singerModel = db.Singer.Find(id);
            if (singerModel == null)
            {
                return HttpNotFound();
            }
            return View(singerModel);
        }

        // POST: SingerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Singer singerModel = db.Singer.Find(id);
            //Singer singer = new Singer();
            //SingerBinder singerBinder = new SingerBinder();
            //singer = singerBinder.Bind(singerModel);
            //db.Singer.Remove(singer);
            //db.SaveChanges();
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
    }
}
