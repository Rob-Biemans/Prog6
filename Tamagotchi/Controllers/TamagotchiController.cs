using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tamagotchi.Domein;
using Tamagotchi.Domein.Models;
using Tamagotchi.Domein.Repository;

namespace Tamagotchi.Controllers
{
    public class TamagotchiController : Controller
    {
        private ITamagotchiRepository _tamagotchiRepo { get; set; }

        public TamagotchiController() : this(null) {

        }

        public TamagotchiController(ITamagotchiRepository tamagotchiRepo)
        {
            this._tamagotchiRepo = tamagotchiRepo;
        }

        // GET: Tamagotchi
        public ActionResult Index()
        {
            _tamagotchiRepo.ForceRefresh();
            return View();
        }

        // GET: Tamagotchi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagochi tamagotchi = _tamagotchiRepo.GetById(id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // GET: Tamagotchi/Create
        public ActionResult Create()
        {
            _tamagotchiRepo.ForceRefresh();
            return View();
        }


        // POST: Tamagotchi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Start,End,TamagotchiId,HotelroomId")] Tamagochi tamagotchi)
        {
            if (ModelState.IsValid)
            {
                _tamagotchiRepo.Add(tamagotchi);
                RepositoryLocator.Repositories.Save();
                return RedirectToAction("Index");
            }

            return View(tamagotchi);
        }

        // GET: Tamagotchi/Edit/5
        public ActionResult Edit(int? id)
        {
            _tamagotchiRepo.ForceRefresh();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagochi tamagotchi = _tamagotchiRepo.GetById(id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // POST: Tamagotchi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Start,End,TamagotchiId,HotelroomId")] Tamagochi tamagotchi)
        {
            if (ModelState.IsValid)
            {
                _tamagotchiRepo.Update(tamagotchi);
                RepositoryLocator.Repositories.Save();
                return RedirectToAction("Index");
            }
            return View(tamagotchi);
        }

        // GET: Tamagotchi/Delete/5
        public ActionResult Delete(int? id)
        {
            _tamagotchiRepo.ForceRefresh();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagochi tamagotchi = _tamagotchiRepo.GetById(id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // POST: Tamagotchi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamagochi tamagotchi = _tamagotchiRepo.GetById(id);
            _tamagotchiRepo.Remove(tamagotchi);
            RepositoryLocator.Repositories.Save();
            return RedirectToAction("Index");
        }
    }
}