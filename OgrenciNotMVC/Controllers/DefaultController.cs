using OgrenciNotMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        MVCOkulEntities db = new MVCOkulEntities();
        // GET: Default
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDersEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDersEkle(TBLDERSLER ders)
        {
            db.TBLDERSLER.Add(ders);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View(ders);
        }

        public ActionResult Guncelle(TBLDERSLER ders)
        {
            var drs = db.TBLDERSLER.Find(ders.DERSID);
            drs.DERSAD = ders.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}