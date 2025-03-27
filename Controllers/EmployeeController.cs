using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;
using Employee_Management_System.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL dal = new EmployeeDAL();

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = dal.GetAllEmployees();
            return View(employees);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dal.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            Employee employee = dal.GetEmployeeByID(id);
            return View(employee);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                dal.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            Employee employee = dal.GetEmployeeByID(id);
            return View(employee);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            dal.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
