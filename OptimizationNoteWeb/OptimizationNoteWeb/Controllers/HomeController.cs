using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OptimizationNote.Data.DBContext;

namespace OptimizationNoteWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new Ken_DemoEntities();
            var query=db.PUBGOptimization.ToList();

            return View(query);
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Edit(int serialNo)
        {
            var db = new Ken_DemoEntities();
            var query = db.PUBGOptimization.FirstOrDefault(o=>o.SerialNo==serialNo);

            return View(query);
        }

        public ActionResult Delete(int serialNo)
        {
            var result = true;

            try
            {
                var db = new Ken_DemoEntities();
                var query = db.PUBGOptimization.FirstOrDefault(o => o.SerialNo == serialNo);

                db.PUBGOptimization.Remove(query);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(new { success = result });
        }

        public ActionResult Add(PUBGOptimization model)
        {
            var result = true;

            try
            {
                var db = new Ken_DemoEntities();

                db.PUBGOptimization.Add(model);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }
            
            return Json(new { success = result });
        }

        public ActionResult Update(PUBGOptimization model)
        {
            var result = true;

            try
            {
                var db = new Ken_DemoEntities();
                var query = db.PUBGOptimization.FirstOrDefault(o => o.SerialNo == model.SerialNo);
                
                query.DownloadURL = model.DownloadURL;
                query.Description = model.Description;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(new { success = result });
        }
    }
}