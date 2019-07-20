using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCloud;
using MusicCloud.Binders;
using MusicCloud.Models;

namespace MusicCloud.Controllers
{
    public class StyleModelsController : Controller
    {
        private MusicCloudEntities db = new MusicCloudEntities();

        // GET: StyleModels
        public ActionResult Index()
        {
            StyleBinder styleBinder = new StyleBinder();
            ICollection<StyleModel> styleModelList = styleBinder.Bind(db.Style.ToList());
            return View(styleModelList);
        }

        // GET: StyleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Style style = db.Style.Find(id);
            if (style == null)
            {
                return HttpNotFound();
            }
            return View(style);
        }

        // GET: StyleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StyleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] StyleModel styleModel)
        {
            if (ModelState.IsValid)
            {
                StyleBinder styleBinder = new StyleBinder();
                Style style = styleBinder.Bind(styleModel);
                db.Style.Add(style);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(styleModel);
        }

        // GET: StyleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Style style = db.Style.Find(id);
            if (style == null)
            {
                return HttpNotFound();
            }
            return View(style);
        }

        // POST: StyleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] StyleModel styleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(styleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(styleModel);
        }

        // GET: StyleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Style style = db.Style.Find(id);
            if (style == null)
            {
                return HttpNotFound();
            }
            return View(style);
        }

        // POST: StyleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Style style= db.Style.Find(id);
            db.Style.Remove(style);
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
    }
}
