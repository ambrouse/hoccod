using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantaysWeb.Models;

namespace fantaysWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List() {
            qlKHEntities db = new qlKHEntities();
            return View(db.KhachHangs);
        }
        public ActionResult Them()
        {
            return View(new KhachHang());
        }
        [HttpPost]
        public ActionResult Them(KhachHang model)
        {
            qlKHEntities db = new qlKHEntities();
            db.KhachHangs.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Update(int id) {
            qlKHEntities db = new qlKHEntities();
            KhachHang update = db.KhachHangs.SingleOrDefault(c => c.ID == id);
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(KhachHang model)
        {
            qlKHEntities db = new qlKHEntities();
            var update = db.KhachHangs.Find(model.ID);
            update.TenKH = model.TenKH;
            update.SoDT = model.SoDT;
            update.IDKH = model.IDKH;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            qlKHEntities db = new qlKHEntities();
            KhachHang update = db.KhachHangs.SingleOrDefault(c => c.ID == id);
            db.KhachHangs.Remove(update);
            db.SaveChanges();
            return RedirectToAction("List");
        }



        public ActionResult ListLoaiKH()
        {
            qlKHEntities db = new qlKHEntities();
            return View(db.LoaiKhachHangs);
        }

        public ActionResult ThemLoaiKH()
        {
            return View(new LoaiKhachHang());
        }
        [HttpPost]
        public ActionResult ThemLoaiKH(LoaiKhachHang model)
        {
            qlKHEntities db = new qlKHEntities();
            var them = db.LoaiKhachHangs.ToList();
            db.LoaiKhachHangs.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}