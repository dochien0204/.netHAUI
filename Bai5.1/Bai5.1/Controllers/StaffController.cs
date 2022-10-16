using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Bai5._1.Models;

namespace Bai5._1.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(FormCollection f)
        {

            var fhinh = Request.Files["myFile"];
            var pathHinh = Server.MapPath("~/Images/" + fhinh.FileName);
            fhinh.SaveAs(pathHinh);
            string path = Server.MapPath("~/StaffInfo.txt");
            string[] infor = { f["Id"], f["Name"], f["DateOfBirth"], f["Salary"], f["Image"] };
            System.IO.File.WriteAllLines(path, infor);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Open()
        {
            string path = Server.MapPath("~/StaffInfo.txt");
            string[] info = System.IO.File.ReadAllLines(path);
            StaffInfo s = new StaffInfo();
            s.id = (info[0]);
            s.name = info[1];
            s.dateOfBirth = DateTime.Parse(info[2]);
            s.salary = decimal.Parse(info[3]);
            s.image = info[4];

            ViewBag.id = s.id;
            ViewBag.name = s.name;
            ViewBag.date = s.dateOfBirth;
            ViewBag.salary = s.salary;
            ViewBag.image = "../../Images";

            return View("Index");
        }
    }
}