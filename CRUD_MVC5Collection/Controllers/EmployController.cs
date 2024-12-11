using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CRUD_MVC5Collection.Models;



namespace CRUD_MVC5Collection.Controllers
{
    public class EmployController : Controller
    {

        public static List<Employ> employees = new List<Employ>
        {
            new Employ{Id=101,Name="Raja",Salary=25000},
            new Employ{Id=102,Name="Danish",Salary=30000},
            new Employ{Id=103,Name="adnan",Salary=35000},
        };
        // GET: Employ
        public ActionResult Index()
        {
            //displaying employes
            return View(employees);
        }

        public ActionResult Create()
        {
            return View(new Employ());
        }

        [HttpPost]
        public ActionResult Create(Employ employ)
        {
            if (ModelState.IsValid)
            {
                employees.Add(employ);
                ViewBag.Message = "Added successfully";
            }
            return View(employ);
        }
        //get
        
        public ActionResult Edit(int id)
        {
            //checking id entered by user is available or not collection
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }
        [HttpPost]

        public ActionResult Edit(Employ employ)
        {
            if (ModelState.IsValid)
            {
                var existingEmploy = employees.FirstOrDefault(emp => emp.Id == employ.Id);
                if (existingEmploy != null)
                {
                    existingEmploy.Name = employ.Name;
                    existingEmploy.Salary = employ.Salary;
                }
                ViewBag.Message = "Employ Updated successfully..!";
            }
            return View(employ);
        }
    }
}