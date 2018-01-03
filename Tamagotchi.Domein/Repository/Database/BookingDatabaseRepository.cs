using Tamagotchi.Domein.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tamagotchi.Domein.Repository
{
    public class BookingDatabaseRepository : IBookingRepository
    {
        private TamagotchiEntities _db;

        public BookingDatabaseRepository(TamagotchiEntities db)
        {
            _db = db;
        }

        public void Add(Booking obj)
        {
            _db.Bookings.Add(obj);
        }

        public List<Booking> GetAll()
        {
            return _db.Bookings.ToList();
        }

        public Booking GetById(int ID)
        {
            return _db.Bookings.Find(ID);
        }

        public void Remove(Booking obj)
        {
            _db.Bookings.Remove(obj);
        }

        public void Update(Booking obj)
        {
            Booking b = _db.Bookings.FirstOrDefault(x => x.Id == obj.Id);

            if (b != null)
            {
                b.Start = obj.Start;
                b.Hotelroom = obj.Hotelroom;
                b.HotelroomId = obj.HotelroomId;
                b.End = obj.End;
                b.Tamagochi = obj.Tamagochi;
                b.TamagotchiId = obj.TamagotchiId;
            }
        }

        public bool ForceRefresh()
        {
            return true;
        }
    }
}
