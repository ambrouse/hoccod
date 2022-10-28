using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fantaysWeb.Models;

namespace fantaysWeb.Controllers
{
    public class SeviceController : Controller
    {
        // GET: Sevice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List() {
            return View(StarticDonHang.listdonhang);
        }
        public ActionResult Them() {

            return View(new donHang());
        }
        [HttpPost]
        public ActionResult Them(donHang model) {
            
            if (model.ID == 0)
            {
                ModelState.AddModelError("", "id phai lon hon khong");
                return View(model);
            }
                for(int i =0;i<StarticDonHang.listdonhang.Count;i++){
                    if (StarticDonHang.listdonhang[i].ID == model.ID) {
                        ModelState.AddModelError("", "id da ton tai");
                        return View(model);
                    }
                }
            if (String.IsNullOrEmpty(model.TenKH) || String.IsNullOrEmpty(model.DiaChi) || String.IsNullOrEmpty(model.SoDt))
            {
                ModelState.AddModelError("", "khong dc de trong du lieu");
                return View(model);
            }
            StarticDonHang.listdonhang.Add(model);
            return RedirectToAction("List");
        }
        public ActionResult Update(int idKH) {

            var update = StarticDonHang.listdonhang.SingleOrDefault(c=>c.ID == idKH);
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(donHang model)
        {
            if (String.IsNullOrEmpty(model.TenKH) || String.IsNullOrEmpty(model.DiaChi) || String.IsNullOrEmpty(model.SoDt)) {
                ModelState.AddModelError("", "khong dc de trong du lieu");
                return View(model);

            }
            var update = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == model.ID);
            update.TenKH = model.TenKH;
            update.DiaChi = model.DiaChi;
            update.SoDt = model.SoDt;
            update.NgayDat = model.NgayDat;
            return RedirectToAction("List");
        }
        public ActionResult Delete(int idKH) {
            var delete = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == idKH);
            StarticDonHang.listdonhang.Remove(delete);
            return RedirectToAction("List");
        }
        public ActionResult listChiTiet(int idKH) {
            var list = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == idKH);
            return View(list);
        }
        public ActionResult ThemChiTiet(int idKH) {
            ViewBag.idKH = idKH;
            return View(new Truyen());
        }
        [HttpPost]
        public ActionResult ThemChiTiet(Truyen model,int idKH)
        {
            var them = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == idKH);
            them.ChitietDH.Add(model);
            return RedirectToAction("listChiTiet");
        }
        public ActionResult UpdateChiTiet(int idKH,int idTR)
        {
            ViewBag.idKH = idKH;
            var update = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == idKH);
            return View(update.ChitietDH.SingleOrDefault(c => c.ID == idTR));
        }
        [HttpPost]
        public ActionResult UpdateChiTiet(Truyen model, int idKH,int idTR)
        {
            var update = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == idKH);
            var update_tr = update.ChitietDH.SingleOrDefault(c => c.ID == idTR);
            update_tr.Name = model.Name;
            update_tr.Gia = model.Gia;
            return RedirectToAction("listChiTiet");
        }
        public ActionResult DeleteChiTiet(int idKH,int idTR) {
            var delete = StarticDonHang.listdonhang.SingleOrDefault(c => c.ID == idKH);
            var delete_tr = delete.ChitietDH.SingleOrDefault(c => c.ID == idTR);
            delete.ChitietDH.Remove(delete_tr);
            return RedirectToAction("listChiTiet");
        }
    }
}