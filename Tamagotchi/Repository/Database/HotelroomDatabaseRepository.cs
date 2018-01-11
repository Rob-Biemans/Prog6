using System.Collections.Generic;
using System.Linq;
using System;
using Tamagotchi.Models;

namespace Tamagotchi.Domein.Repository
{
    public class HotelroomDatabaseRepository : IHotelroomRepository
    {
        private TamagotchiEntities _db;

        public HotelroomDatabaseRepository(TamagotchiEntities db)
        {
            _db = db;
        }

        public void Add(Hotelroom obj)
        {
            _db.Hotelrooms.Add(obj);
        }

        public List<Hotelroom> GetAll()
        {
            return _db.Hotelrooms.ToList();
        }

        public Hotelroom GetById(int? ID)
        {
            return _db.Hotelrooms.Find(ID);
        }

        public void Remove(Hotelroom obj)
        {
            _db.Hotelrooms.Remove(obj);
        }

        public void Update(Hotelroom obj)
        {
            Hotelroom h = _db.Hotelrooms.FirstOrDefault(x => x.Id == obj.Id);

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
