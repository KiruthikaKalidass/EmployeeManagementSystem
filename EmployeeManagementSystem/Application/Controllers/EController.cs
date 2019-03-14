using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class EController : Controller
    {

        
        // GET: E
        public ActionResult Index()
        {
            EmployeeDBHandle dbhandle = new EmployeeDBHandle();
            ModelState.Clear();
          
            return View(dbhandle.GetEmployee());

        }
       
        // GET: E/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: E/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: E/Create
        [HttpPost]
        public ActionResult Create(EModel emodel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    EmployeeDBHandle edb = new EmployeeDBHandle();
                    if (edb.AddEmployee(emodel))
                    {
                        ViewBag.Message = "Employee Details Added Successfully";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch 
            {
                return View();
            }
        }

        // GET: E/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeDBHandle edb = new EmployeeDBHandle();
            var result = edb.GetEmployee().Find(emodel => emodel.Id == id);
            return View(result);
           
        }

        // POST: E/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EModel emodel)
        {
            try
            {
              
                EmployeeDBHandle edb = new EmployeeDBHandle();
                edb.UpdateDetails(emodel);
                return RedirectToAction("Index");
             
            }
            catch
            {
                return View();
            }
        }

        // GET: E/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                EmployeeDBHandle edb = new EmployeeDBHandle();
                if (edb.DeleteEmployees(id))
                {
                    ViewBag.AlertMsg = "Employee Record Deleted Successfully";
                }
                return RedirectToAction("Index");
            }


            catch
            {
                return View();
            }
        
        }
       
            // GET: E/Edit/5
            public ActionResult Action(int id)
            {
                EmployeeDBHandle edb = new EmployeeDBHandle();
                var result = edb.GetEmployee().Find(emodel => emodel.Id == id);
                return View(result);

            }

        // POST: E/Edit/5
        [HttpPost]
        public ActionResult Action(int id, EModel emodel)
        {
            try
            {

                EmployeeDBHandle edb = new EmployeeDBHandle();
                edb.Search(emodel);
                return RedirectToAction("Index");

            }
            catch 
            {
                return View();
            }
        }
    }

      
        
    
}
