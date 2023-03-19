using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        MVCOkulEntities db = new MVCOkulEntities();

        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            /*List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Value = "0", Text= "Matematik" });
            items.Add(new SelectListItem { Value = "1", Text = "Fen Bilgisi" });
            items.Add(new SelectListItem { Value = "2", Text = "Atatürk İlke ve İnkılapları" });
            items.Add(new SelectListItem { Value = "3", Text = "Coğrafya" });

            ViewBag.Dersler = items;*/

            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList() select new SelectListItem() { Text = i.KULUPAD, Value = i.KULUPID.ToString() }).ToList();

            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER ogrenci)
        {
            var klp = db.TBLKULUPLER.Where(x => x.KULUPID == ogrenci.TBLKULUPLER.KULUPID).FirstOrDefault();
            ogrenci.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList() select new SelectListItem() { Text = i.KULUPAD, Value = i.KULUPID.ToString() }).ToList();

            ViewBag.dgr = degerler;
            return View(ogrenci);
        }

        public ActionResult Guncelle(TBLOGRENCILER ogrenci)
        {
            var ogr = db.TBLOGRENCILER.Find(ogrenci.OGRID);
            ogr.OGRAD = ogrenci.OGRAD;
            ogr.OGRSOYAD = ogrenci.OGRSOYAD;
            ogr.OGRFOTO = ogrenci.OGRFOTO;
            ogr.OGRCINSIYET = ogrenci.OGRCINSIYET;
            ogr.OGRKULUP = ogrenci.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}