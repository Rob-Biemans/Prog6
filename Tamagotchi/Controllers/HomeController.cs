using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamagotchi.Domein.Models;
using Tamagotchi.Domein.Repository;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //BookingDatabaseRepository bookingRepo = new BookingDatabaseRepository(new TamagotchiEntities());
            //List<SelectListItem> bookings = new List<SelectListItem>();
            //bookingRepo.GetAll().ForEach(b => bookings.Add(new SelectListItem { Text = b.Hotelroom.Type + " " + b.Hotelroom.Id, Value = b.Hotelroom}));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}