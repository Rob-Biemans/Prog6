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
    public class BookingController : Controller
    {
        private IBookingRepository _bookingRepo = RepositoryLocator.Repositories.BookingRepository;

        // GET: Booking
        public ActionResult Index()
        {
            _bookingRepo.ForceRefresh();
            return View(_bookingRepo.GetAll());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _bookingRepo.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            _bookingRepo.ForceRefresh();
            List<SelectListItem> items = new List<SelectListItem>();
            List<SelectListItem> hotelrooms = new List<SelectListItem>();
            using (var context = new TamagotchiEntities())
            {
                context.Tamagochis.ToList().ForEach(t => items.Add(new SelectListItem { Text = t.Name, Value = t.Id.ToString() }));
                context.Hotelrooms.Where(h => h.Bookings.Count < 0).ToList().ForEach(h => hotelrooms.Add(new SelectListItem { Text = h.Type, Value = h.Id.ToString() }));
            }
            ViewBag.TamagotchiName = items;
            ViewBag.HotelRooms = hotelrooms;
            return View();
        }


        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Start,End,TamagotchiId,HotelroomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingRepo.Add(booking);
                RepositoryLocator.Repositories.Save();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            _bookingRepo.ForceRefresh();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _bookingRepo.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Start,End,TamagotchiId,HotelroomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingRepo.Update(booking);
                RepositoryLocator.Repositories.Save();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            _bookingRepo.ForceRefresh();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _bookingRepo.GetById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = _bookingRepo.GetById(id);
            _bookingRepo.Remove(booking);
            RepositoryLocator.Repositories.Save();
            return RedirectToAction("Index");
        }
    }
}