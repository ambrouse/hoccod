using fantaysWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fantaysWeb.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult ListSinhVien()
        {
            return View(DSSinhVien.dssv);
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(SinhVien model)
        {
            
            for(int i = 0; i<DSSinhVien.dssv.Count;i++)
            {
                if(DSSinhVien.dssv[i].Id == model.Id)
                {
                    ModelState.AddModelError("", "id da ton tai");
                    return View(model);
                }
            }
            if(model.Id <= 0)
            {
                ModelState.AddModelError("", "id phai lon hon 0");
                return View();
            }

            DSSinhVien.dssv.Add(model);

            return RedirectToAction("ListSinhVien");
        }
        public ActionResult Update(int id)
        {
            var Update = DSSinhVien.dssv.FirstOrDefault(x => x.Id == id);
            return View(Update);
        }
        [HttpPost]
        public ActionResult Update(SinhVien sv)
        {
            var Update = DSSinhVien.dssv.FirstOrDefault(x => x.Id == sv.Id);
            if(String.IsNullOrEmpty(sv.Name)|| String.IsNullOrEmpty(sv.MaLop))
            {
                ModelState.AddModelError("", "khong dc de trong du lieu");
                return View(sv);

            }
            
            Update.Name = sv.Name;
            Update.Age = sv.Age;
            Update.MaLop = sv.MaLop;

            return RedirectToAction("ListSinhVien");
        }
        public ActionResult Delete(int id)
        {
            var delete = DSSinhVien.dssv.FirstOrDefault(x => x.Id == id);
            DSSinhVien.dssv.Remove(delete);
            return RedirectToAction("Index");
        }
    }
}