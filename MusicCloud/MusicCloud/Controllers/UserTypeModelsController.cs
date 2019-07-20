﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCloud;
using MusicCloud.Models;

namespace MusicCloud.Controllers
{
    public class UserTypeModelsController : Controller
    {
        private MusicCloudEntities db = new MusicCloudEntities();

        // GET: UserTypeModels
        public ActionResult Index()
        {
            return View(db.UserType.ToList());
        }

        // GET: UserTypeModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userTypeModel = db.UserType.Find(id);
            if (userTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(userTypeModel);
        }

        // GET: UserTypeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserTypeCode")] UserType userTypeModel)
        {
            if (ModelState.IsValid)
            {
                db.UserType.Add(userTypeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTypeModel);
        }

        // GET: UserTypeModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userTypeModel = db.UserType.Find(id);
            if (userTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(userTypeModel);
        }

        // POST: UserTypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserTypeCode")] UserTypeModel userTypeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTypeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTypeModel);
        }

        // GET: UserTypeModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userTypeModel = db.UserType.Find(id);
            if (userTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(userTypeModel);
        }

        // POST: UserTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserType userTypeModel = db.UserType.Find(id);
            db.UserType.Remove(userTypeModel);
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