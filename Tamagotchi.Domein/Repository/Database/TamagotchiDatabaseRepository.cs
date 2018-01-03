using Tamagotchi.Domein.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tamagotchi.Domein.Repository
{
    public class TamagotchiDatabaseRepository : ITamagotchiRepository
    {
        private TamagotchiEntities _db;

        public TamagotchiDatabaseRepository(TamagotchiEntities db)
        {
            _db = db;
        }

        public void Add(Tamagochi obj)
        {
            _db.Tamagochis.Add(obj);
        }

        public List<Tamagochi> GetAll()
        {
            return _db.Tamagochis.ToList();
        }

        public Tamagochi GetById(int ID)
        {
            return _db.Tamagochis.Find(ID);
        }

        public void Remove(Tamagochi obj)
        {
            _db.Tamagochis.Remove(obj);
        }

        public void Update(Tamagochi obj)
        {
            Tamagochi t = _db.Tamagochis.FirstOrDefault(a => a.Id == obj.Id);

            if (t != null)
            {
                t.Name = obj.Name;
                t.Level = obj.Level;
                t.Health = obj.Health;
                t.Hapinness = obj.Hapinness;
                t.Age = obj.Age;
                t.Alive = obj.Alive;
                t.Currency = obj.Currency;
            }
        }

        public bool ForceRefresh()
        {
            return true;
        }
    }
}
