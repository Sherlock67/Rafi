using Kazirafi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kazirafi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeRecordsEntities db = new EmployeeRecordsEntities();

        public ActionResult Dash()
        {
            return View();
        }
        public ActionResult GetList()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            emp.FirstName = emp.FirstName;
            emp.MiddleName = emp.MiddleName;
            emp.LastName = emp.LastName;
            db.Employees.Add(emp);
            db.SaveChanges();
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(image img)
        {
            string fileName = Path.GetFileNameWithoutExtension(img.ImageFile.FileName);
            string extension = Path.GetExtension(img.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            img.Imagepath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            img.ImageFile.SaveAs(fileName);
            db.images.Add(img);
            db.SaveChanges();
            return View();
        }
    }
}