using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

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
    }
}