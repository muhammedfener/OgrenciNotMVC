using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
using OgrenciNotMVC.Models;

namespace OgrenciNotMVC.Controllers
{
    public class NotlarController : Controller
    {
        MVCOkulEntities db = new MVCOkulEntities();
        // GET: Sinav
        public ActionResult Index()
        {
            var sinavNotlar = db.TBLNOTLAR.ToList();
            return View(sinavNotlar);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR not)
        {
            db.TBLNOTLAR.Add(not);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View(not);
        }

        [HttpPost]
        public ActionResult NotGetir(TBLNOTLAR not, Islem model, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if(model.islem == "HESAPLA")
            {
                int ortalama = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ortalama;
            }
            if(model.islem == "NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(not.NOTID);
                snv.SINAV1 = not.SINAV1;
                snv.SINAV2 = not.SINAV2;
                snv.SINAV3 = not.SINAV3;
                snv.PROJE = not.PROJE;
                snv.ORTALAMA = not.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}