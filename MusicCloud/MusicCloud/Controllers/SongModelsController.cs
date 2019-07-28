using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicCloud.Binders;
using MusicCloud.Models;

namespace MusicCloud.Controllers
{
    public class SongModelsController : Controller
    {
        SongBinder SongBinder = new SongBinder();
        
        private MusicCloudEntities db = new MusicCloudEntities();

        // GET: SongModels
        public ActionResult Index()
        {
            var song = db.Song.Include(s => s.Album).Include(s => s.Style).ToList();
            SongBinder songBinder = new SongBinder();
            ICollection<SongModel>  songModel = songBinder.Bind(song);
            return View(songModel);
        }

        // GET: SongModels
        public ActionResult GetSongsBySingerId(int singerId)
        {
            var song = db.Song.Where(s => s.Album.SingerId == singerId).ToList();
            ICollection<SongModel> songModel = new List<SongModel>();
            SongBinder songBinder = new SongBinder();
            songModel = songBinder.Bind(song);
            return View("Index", songModel);
        }

        // GET: SongModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song songModel = db.Song.Find(id);
            if (songModel == null)
            {
                return HttpNotFound();
            }
            return View(songModel);
        }

        // GET: SongModels/Create
        public ActionResult Create()
        {
            if (!Convert.ToBoolean(Session["IsAdmin"]))
            {
                return HttpNotFound("You are not admin");
            }

            ViewBag.AlbumId = new SelectList(db.Album, "Id", "Name");
            ViewBag.StyleId = new SelectList(db.Style, "Id", "Name");
            return View();
        }

        // POST: SongModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlbumId,StyleId,Name")] SongModel songModel)
        {
            if (ModelState.IsValid)
            {
                Song song = SongBinder.Bind(songModel);
                db.Song.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Album, "Id", "Name", songModel.AlbumId);
            ViewBag.StyleId = new SelectList(db.Style, "Id", "Name", songModel.StyleId);
            return View(songModel);
        }

        // GET: SongModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song songModel = db.Song.Find(id);
            if (songModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Album, "Id", "Name", songModel.AlbumId);
            ViewBag.StyleId = new SelectList(db.Style, "Id", "Name", songModel.StyleId);
            return View(songModel);
        }

        // POST: SongModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlbumId,StyleId,Name")] SongModel songModel)
        {
            if (ModelState.IsValid)
            {
                Song song = SongBinder.Bind(songModel);
                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Album, "Id", "Name", songModel.AlbumId);
            ViewBag.StyleId = new SelectList(db.Style, "Id", "Name", songModel.StyleId);
            return View(songModel);
        }

        // GET: SongModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song songModel = db.Song.Find(id);
            if (songModel == null)
            {
                return HttpNotFound();
            }
            return View(songModel);
        }

        // POST: SongModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Song songModel = db.Song.Find(id);
            //Song song = SongBinder.ConvertCustomModelToDbObject(song);
            //db.Song.Remove(song);
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
