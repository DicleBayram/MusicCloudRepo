using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicCloud.Binders;
using MusicCloud.Models;

namespace MusicCloud.Controllers
{
    public class AlbumModelsController : Controller
    {
        private MusicCloudEntities db = new MusicCloudEntities();

        // GET: AlbumModels
        public ActionResult Index()
        {
            var album = db.Album.Include(a => a.Singer).ToList();
            ICollection<AlbumModel> albumModels = new List<AlbumModel>();          
            AlbumBinder albumBinder = new AlbumBinder();
            albumModels = albumBinder.Bind(album);
            return View(albumModels);
        }

        // GET: AlbumModels
        public ActionResult GetAlbumsBySingerId(int singerId)
        {
            var album = db.Album.Where(s => s.Singer.Id == singerId).ToList();
            ICollection<AlbumModel> albumModels = new List<AlbumModel>();
            AlbumBinder albumBinder = new AlbumBinder();
            albumModels = albumBinder.Bind(album);
            return View("Index", albumModels);
        }


        // GET: AlbumModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album albumModel = db.Album.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            return View(albumModel);
        }

        // GET: AlbumModels/Create
        public ActionResult Create()
        {
            ViewBag.SingerId = new SelectList(db.Singer, "Id", "Name");
            return View();
        }

        // POST: AlbumModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UploadDate,SingerId")] AlbumModel albumModel)
        {
            if (ModelState.IsValid)
            {
                AlbumBinder albumBinder = new AlbumBinder();
                Album album = albumBinder.Bind(albumModel);
                db.Album.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SingerId = new SelectList(db.Singer, "Id", "Name", albumModel.SingerId);
            return View(albumModel);
        }

        // GET: AlbumModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album albumModel = db.Album.Find(id);

            if (albumModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.SingerId = new SelectList(db.Singer, "Id", "Name", albumModel.SingerId);
            return View(albumModel);
        }

        // POST: AlbumModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UploadDate,SingerId")] AlbumModel albumModel)
        {
            if (ModelState.IsValid)
            {
                AlbumBinder albumBinder = new AlbumBinder();
                Album album = albumBinder.Bind(albumModel);
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SingerId = new SelectList(db.Singer, "Id", "Name", albumModel.SingerId);
            return View(albumModel);
        }

        // GET: AlbumModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album albumModel = db.Album.Find(id);
            if (albumModel == null)
            {
                return HttpNotFound();
            }
            return View(albumModel);
        }

        // POST: AlbumModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            //AlbumModel albumModel = db.AlbumModels.Find(id);
            //Album album = AlbumBinder.Bind(albumModel);
            //db.Album.Remove(album);
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
