using CarpoolManagement.Common.Models;
using CarpoolManagement.DAL.Repositories;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarpoolManagement.Common.Interfaces;
using CarpoolManagement.DAL.Infrastructure;

namespace CarpoolManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        //private CarpoolManagementContext _carpoolRepository = new CarpoolManagementContext();
        private IEmployeeRepository _employeeRepository;

        public EmployeesController()
        {
            _employeeRepository = new EmployeeRepository(new CarpoolManagementContext());
        }

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(_employeeRepository.GetEmployees().ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.FindById(Convert.ToInt32(id));
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsDriver")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Add(employee);
                    return RedirectToAction("Index");
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.FindById(Convert.ToInt32(id));
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsDriver")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Edit(employee);
                    return RedirectToAction("Index");
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.FindById(Convert.ToInt32(id));
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employeeRepository.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _employeeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
