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
    public class CarpoolsController : Controller
    {
        //private CarpoolManagementContext _carpoolRepository = new CarpoolManagementContext();
        private ICarpoolRepository _carpoolRepository;

        public CarpoolsController()
        {
            _carpoolRepository = new CarpoolRepository(new CarpoolManagementContext());
        }

        public CarpoolsController(ICarpoolRepository carpoolRepository)
        {
            _carpoolRepository = carpoolRepository;
        }

        // GET: Carpools
        public ActionResult Index()
        {
            return View(_carpoolRepository.GetCarpools().ToList());
        }

        // GET: Carpools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carpool carpool = _carpoolRepository.FindById(Convert.ToInt32(id));
            if (carpool == null)
            {
                return HttpNotFound();
            }
            return View(carpool);
        }

        // GET: Carpools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carpools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CarType,Color,Plates,NumberOfSeats")] Carpool carpool)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_carpoolRepository.IsUniquePlates(carpool.Plates, carpool.Id))
                    {
                        _carpoolRepository.Add(carpool);
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Plates already exist.");
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }

            return View(carpool);
        }

        // GET: Carpools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carpool carpool = _carpoolRepository.FindById(Convert.ToInt32(id));
            if (carpool == null)
            {
                return HttpNotFound();
            }
            return View(carpool);
        }

        // POST: Carpools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CarType,Color,Plates,NumberOfSeats")] Carpool carpool)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_carpoolRepository.IsUniquePlates(carpool.Plates, carpool.Id))
                    {
                        _carpoolRepository.Edit(carpool);
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError("", "Plates already exist.");
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }
            return View(carpool);
        }

        // GET: Carpools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carpool carpool = _carpoolRepository.FindById(Convert.ToInt32(id));
            if (carpool == null)
            {
                return HttpNotFound();
            }
            return View(carpool);
        }

        // POST: Carpools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _carpoolRepository.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _carpoolRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
