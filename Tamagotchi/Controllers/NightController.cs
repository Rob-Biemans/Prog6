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
        private const string MISC = "MISC";
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
                            if (booking.Hotelroom.Bookings.Count > 1)
                            {
                                Booking booking2 = booking.Hotelroom.Bookings.Where(b => b.Tamagochi.Id != booking.Tamagochi.Id).First();
                                Random ran = new Random();
                                if (ran.NextDouble() >= 0.5)
                                {
                                    booking2.Tamagochi.Health -= 30;
                                    booking2.Tamagochi.Currency -= 20;
                                    if (booking2.Tamagochi.Health <= 0)
                                        booking2.Tamagochi.Alive = 0;
                                    booking.Tamagochi.Level += 1;
                                    booking.Tamagochi.Currency += 20;
                                }
                                else
                                {
                                    booking.Tamagochi.Health -= 30;
                                    booking.Tamagochi.Currency -= 20;
                                    if (booking.Tamagochi.Health <= 0)
                                        booking.Tamagochi.Alive = 0;
                                    booking2.Tamagochi.Level += 1;
                                    booking2.Tamagochi.Currency += 20;
                                }
                            }
                            break;
                        case MISC:
                            booking.Tamagochi.Alive = 0;
                            break;
                            
                    }
                    if (booking.Tamagochi.Hapinness >= 70)
                        booking.Tamagochi.Health -= 20;
                    if (booking.Tamagochi.Health <= 0)
                        booking.Tamagochi.Alive = 0;
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