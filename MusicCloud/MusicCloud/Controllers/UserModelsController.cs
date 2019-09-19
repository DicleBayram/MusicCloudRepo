using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using MusicCloud.Binders;
using MusicCloud.Helper;
using MusicCloud.Models;

namespace MusicCloud.Controllers
{
    public class UserModelsController : Controller
    {
        private MusicCloudEntities db = new MusicCloudEntities();

        // GET: UserModels
        public ActionResult Index()
        {
            UserBinder userBinder = new UserBinder();
            ICollection<UserModel> userModel = userBinder.Bind(db.User.ToList());
            return View(userModel);
        }

        // GET: UserModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UserModels/Create
        [LoginControl(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserType, "Id", "UserTypeCode");
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Password,UserName,UserTypeId")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                UserBinder userBinder = new UserBinder();
                User user = userBinder.Bind(userModel);
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userModel);
        }

        // GET: UserModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,UserName,UserTypeId")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        // GET: UserModels/Delete/5
        [LoginControl(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Password,UserName")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                UserModel dbUser = userModel.GetUserByUsername(userModel.UserName);
                if (dbUser.UserName == null)
                {
                    return HttpNotFound("User is not found");
                }

                PasswordHelper passwordHelper = new PasswordHelper();
                bool isVerified = passwordHelper.VerifyPassword(userModel.Password, dbUser.Password);

                if (!isVerified)
                {
                    return HttpNotFound("Wrong password");
                }

                Session["UserName"] = dbUser.UserName;

                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "Password,RePassword,UserName")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                UserModel dbUser = userModel.GetUserByUsername(userModel.UserName);
                if (dbUser.UserName != null)
                {
                    return HttpNotFound("Username is already used");
                }

                if (!String.Equals(userModel.Password, userModel.RePassword))
                {
                    return HttpNotFound("Passwords are not same");
                }

                Session["UserName"] = dbUser.UserName;

                UserBinder userBinder = new UserBinder();
                userModel.UserTypeId = 2;
                User user = userBinder.Bind(userModel);
                db.User.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(userModel);
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
