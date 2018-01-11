using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Models;

namespace Tamagotchi.Domein.Repository
{
    public class HotelroomDummyRepository : IHotelroomRepository
    {
        private List<Hotelroom> _hotelroomList;

        public HotelroomDummyRepository()
        {
            _hotelroomList = new List<Hotelroom>();

            _hotelroomList.Add(new Hotelroom()
            {
                Id = 1,
                Beds = 2,
                Price = 100,
                Type = "REST"
            });

            _hotelroomList.Add(new Hotelroom()
            {
                Id = 2,
                Beds = 3,
                Price = 100,
                Type = "FIGHT"
            });

            _hotelroomList.Add(new Hotelroom()
            {
                Id = 3,
                Beds = 5,
                Price = 100,
                Type = "GAME"
            });

            _hotelroomList.Add(new Hotelroom()
            {
                Id = 4,
                Beds = 5,
                Price = 100,
                Type = "WORK"
            });
        }

        public void Add(Hotelroom obj)
        {
            _hotelroomList.Add(obj);
        }

        public List<Hotelroom> GetAll()
        {
            return _hotelroomList;
        }

        public Hotelroom GetById(int? ID)
        {
            return _hotelroomList.FirstOrDefault(x => x.Id == ID);
        }

        public void Remove(Hotelroom obj)
        {
            _hotelroomList.Remove(obj);
        }

        public void Update(Hotelroom obj)
        {
            Hotelroom h = _hotelroomList.FirstOrDefault(x => x.Id == obj.Id);

            if (h != null)
            {
                h.Price = obj.Price;
                h.Type = obj.Type;
                h.Beds = obj.Beds;
            }
        }

        public bool ForceRefresh()
        {
            return true;
        }
    }
}
