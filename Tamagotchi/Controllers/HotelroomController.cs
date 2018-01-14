using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tamagotchi.Domein;
using Tamagotchi.Models;
using Tamagotchi.Domein.Repository;

namespace Tamagotchi.Controllers
{
    public class HotelroomController : Controller
    {
        private IHotelroomRepository _hotelroomRepo = RepositoryLocator.Repositories.HotelroomRepository;

        // GET: Hotelroom
        public ActionResult Index()
        {
            _hotelroomRepo.ForceRefresh();
            return View(_hotelroomRepo.GetAll());
        }

        // GET: Hotelroom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelroom hotelroom = _hotelroomRepo.GetById(id);
            if (hotelroom == null)
            {
                return HttpNotFound();
            }
            return View(hotelroom);
        }

        // GET: Hotelroom/Create
        public ActionResult Create()
        {
            _hotelroomRepo.ForceRefresh();
            return View();
        }


        // POST: Hotelroom/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Beds,Type,Price")] Hotelroom hotelroom)
        {
            if (ModelState.IsValid)
            {
                _hotelroomRepo.Add(hotelroom);
                RepositoryLocator.Repositories.Save();
                return RedirectToAction("Index");
            }

            return View(hotelroom);
        }

        // GET: Hotelroom/Edit/5
        public ActionResult Edit(int? id)
        {
            _hotelroomRepo.ForceRefresh();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelroom hotelroom = _hotelroomRepo.GetById(id);
            if (hotelroom == null)
            {
                return HttpNotFound();
            }
            return View(hotelroom);
        }

        // POST: Hotelroom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Beds,Type,Price")] Hotelroom hotelroom)
        {
            if (ModelState.IsValid)
            {
                _hotelroomRepo.Update(hotelroom);
                RepositoryLocator.Repositories.Save();
                return RedirectToAction("Index");
            }
            return View(hotelroom);
        }

        // GET: Hotelroom/Delete/5
        public ActionResult Delete(int? id)
        {
            _hotelroomRepo.ForceRefresh();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotelroom hotelroom = _hotelroomRepo.GetById(id);
            if (hotelroom == null)
            {
                return HttpNotFound();
            }
            return View(hotelroom);
        }

        // POST: Hotelroom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_hotelroomRepo.GetAll().Count > 4)
            {
                Hotelroom hotelroom = _hotelroomRepo.GetById(id);
                _hotelroomRepo.Remove(hotelroom);
                RepositoryLocator.Repositories.Save();
            }
            return RedirectToAction("Index");
        }
    }
}