using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class KulupController : Controller
    {
        MVCOkulEntities db = new MVCOkulEntities();
        // GET: Kulup
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER kulup)
        {
            db.TBLKULUPLER.Add(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            
            return View(kulup);
        }

        [HttpPost]
        public ActionResult Guncelle(TBLKULUPLER kulup)
        {
            var klp = db.TBLKULUPLER.Find(kulup.KULUPID);
            klp.KULUPAD = kulup.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}