using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Domein.Repository
{
    public class BookingDummyRepository : IBookingRepository
    {
        private List<Booking> _bookingList;

        public BookingDummyRepository()
        {
            _bookingList = new List<Booking>();

            _bookingList.Add(new Booking()
            {
                Id = 1,
                Nights = 1,
                HotelroomId = 1,
                TamagotchiId = 1
            });

            _bookingList.Add(new Booking()
            {
                Id = 2,
                Nights = 1,
                HotelroomId = 2,
                TamagotchiId = 1
            });
        }

        public void Add(Booking obj)
        {
            _bookingList.Add(obj);
        }

        public List<Booking> GetAll()
        {
            return _bookingList;
        }

        public Booking GetById(int? ID)
        {
            return _bookingList.FirstOrDefault(x => x.Id == ID);
        }

        public void Remove(Booking obj)
        {
            _bookingList.Remove(obj);
        }

        public void Update(Booking obj)
        {
            Booking b = _bookingList.FirstOrDefault(x => x.Id == obj.Id);

            if (b != null)
            {
                b.Nights = obj.Nights;
                b.HotelroomId = obj.HotelroomId;
                b.TamagotchiId = obj.TamagotchiId;
            }
        }

        public bool ForceRefresh()
        {
            return true;
        }
    }
}
