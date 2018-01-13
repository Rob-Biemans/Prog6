using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class NightController : Controller
    {
        private const string REST = "REST";
        private const string FIGHT = "FIGHT";
        private const string GAME = "GAME";
        private const string WORK = "WORK";
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        public ActionResult Index()
        {
            using (var context = new TamagotchiEntities())
            {
                var bookings = context.Bookings;

                foreach (var booking in bookings)
                {
                    switch (booking.Hotelroom.Type)
                    {
                        case REST:
                            booking.Tamagochi.Currency -= 10;
                            booking.Tamagochi.Health += 20;
                            booking.Tamagochi.Hapinness += 10;
                            break;
                        case GAME:
                            booking.Tamagochi.Currency -= 20;
                            booking.Tamagochi.Hapinness = 0;
                            break;
                        case WORK:
                            Random r = new Random();
                            booking.Tamagochi.Currency += r.Next(10, 60);
                            booking.Tamagochi.Hapinness += 20;
                            break;
                        case FIGHT:
                            // TODO: Implement
                            throw new NotImplementedException();
                            break;
                    }
                }
                context.SaveChanges();
            }

            return View();
        }

        private Booking ProcessBooking(Booking booking)
        {
            switch (booking.Hotelroom.Type)
            {
                case REST:
                    booking.Tamagochi.Currency -= 10;
                    booking.Tamagochi.Health += 20;
                    booking.Tamagochi.Hapinness += 10;
                    break;
                case GAME:
                    booking.Tamagochi.Currency -= 20;
                    booking.Tamagochi.Hapinness = 0;
                    break;
                case WORK:
                    Random r = new Random();
                    booking.Tamagochi.Currency += r.Next(10, 60);
                    booking.Tamagochi.Hapinness += 20;
                    break;
                case FIGHT:
                    // TODO: Implement
                    throw new NotImplementedException();
                    break;
            }
            return booking;
        }
    }
}