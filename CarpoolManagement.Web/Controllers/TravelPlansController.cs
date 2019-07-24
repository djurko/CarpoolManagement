using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarpoolManagement.Common.Interfaces;
using CarpoolManagement.Common.Models;
using CarpoolManagement.DAL.Infrastructure;
using CarpoolManagement.DAL.Repositories;
using CarpoolManagement.Web.Models;

namespace CarpoolManagement.Web.Controllers
{
    public class TravelPlansController : Controller
    {
        //private CarpoolManagementContext _carpoolRepository = new CarpoolManagementContext();
        private ITravelPlanRepository _travelPlanRepository;
        private ICarpoolRepository _carpoolRepository;
        private IEmployeeRepository _employeeRepository;

        public TravelPlansController()
        {
            CarpoolManagementContext context = new CarpoolManagementContext();
            _travelPlanRepository = new TravelPlanRepository(context);
            _carpoolRepository = new CarpoolRepository(context);
            _employeeRepository = new EmployeeRepository(context);
        }

        public TravelPlansController(ITravelPlanRepository travelPlanRepository, ICarpoolRepository carpoolRepository, IEmployeeRepository _employeeRepository)
        {
            _travelPlanRepository = travelPlanRepository;
            _carpoolRepository = carpoolRepository;
            _employeeRepository = _employeeRepository;
        }

        // GET: TravelPlans
        public ActionResult Index()
        {
            return View(_travelPlanRepository.GetTravelPlans().ToList());
        }

        // GET: TravelPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelPlan travelPlan = _travelPlanRepository.FindById(Convert.ToInt32(id));
            if (travelPlan == null)
            {
                return HttpNotFound();
            }
            return View(travelPlan);
        }

        // GET: TravelPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Id,StartLocation,EndLocation,StartDate,EndDate")]*/ TravelPlanModel travelPlan)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                try
                {
                    Carpool car = _carpoolRepository.FindById(travelPlan.CarId);
                    List<Employee> employees = _employeeRepository.FindByIds(travelPlan.EmployeeIds).ToList();
                    if (travelPlan.HasDriver && car.NumberOfSeats >= travelPlan.EmployeeIds.Count)
                    {
                        TravelPlan result = new TravelPlan()
                        {
                            StartLocation = travelPlan.StartLocation,
                            EndLocation = travelPlan.EndLocation,
                            StartDate = travelPlan.StartDate,
                            EndDate = travelPlan.EndDate,
                            CarId = travelPlan.CarId,
                            Car = car
                        };
                        result.EmployeeTravelPlans = new List<EmployeeTravelPlan>();
                        foreach (var el in employees)
                        {
                            result.EmployeeTravelPlans.Add(new EmployeeTravelPlan()
                            {
                                Employee = el,
                                EmployeeId = el.Id,
                                TravelPlan = result
                            });
                        }
                        _travelPlanRepository.Add(result);
                        success = true;
                        return Json(new{ success });
                    }
                    else
                    {
                        return Json(new { success });
                    }
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }

            return Json(new { success });
        }

        // GET: TravelPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelPlan travelPlan = _travelPlanRepository.FindById(Convert.ToInt32(id));
            if (travelPlan == null)
            {
                return HttpNotFound();
            }
            return View(travelPlan);
        }

        // POST: TravelPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartLocation,EndLocation,StartDate,EndDate")] TravelPlan travelPlan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _travelPlanRepository.Edit(travelPlan);
                    return RedirectToAction("Index");
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }
            return View(travelPlan);
        }

        // GET: TravelPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelPlan travelPlan = _travelPlanRepository.FindById(Convert.ToInt32(id));
            if (travelPlan == null)
            {
                return HttpNotFound();
            }
            return View(travelPlan);
        }

        // POST: TravelPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _travelPlanRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult FindAvailableEmployeesAndCars(TravelPlan travelPlan)
        {
            List<TravelPlan> conflictingTravelPlans = _travelPlanRepository.FindConflictingTravelPlans(travelPlan.StartDate, travelPlan.EndDate).ToList();
            List<Carpool> availableCarpoolsDb = _carpoolRepository.FindAllAvailableCarpools(conflictingTravelPlans).ToList();
            List<Employee> availableEmployeesDb = _employeeRepository.FindAllAvailableEmployees(conflictingTravelPlans).ToList();

            List<CarpoolModel> availableCarpools = CarpoolModel.MapToList(availableCarpoolsDb);
            List<EmployeeModel> availableEmployees = EmployeeModel.MapToList(availableEmployeesDb);

            return Json(new
            {
                availableCarpools,
                availableEmployees,
                travelPlan
            });
        }

        [HttpGet]
        public ActionResult MonthlyView()
        {
            List<TravelPlan> allTravelPlans = _travelPlanRepository.GetTravelPlans().ToList();
            var result = allTravelPlans
                .GroupBy(x => x.StartDate.Year.ToString() + "-" + x.StartDate.Month.ToString())
                .ToDictionary(g => g.Key, g => g.ToList());
            return View(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _travelPlanRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
