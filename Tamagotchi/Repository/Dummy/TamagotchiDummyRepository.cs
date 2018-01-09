using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Domein.Models;

namespace Tamagotchi.Domein.Repository
{
    public class TamagotchiDummyRepository : ITamagotchiRepository
    {
        private List<Tamagochi> _tamagotchiList;

        public TamagotchiDummyRepository()
        {
            _tamagotchiList = new List<Tamagochi>();

            _tamagotchiList.Add(new Tamagochi()
            {
                Id = 1,
                Name = "Daan v Hoof",
                Level = 0,
                Age = 0,
                Alive = 1,
                Currency = 100,
                Hapinness = 0,
                Health = 100
            });

            _tamagotchiList.Add(new Tamagochi()
            {
                Id = 2,
                Name = "Piet v Ethopie",
                Level = 0,
                Age = 0,
                Alive = 1,
                Currency = 100,
                Hapinness = 0,
                Health = 100
            });

            _tamagotchiList.Add(new Tamagochi()
            {
                Id = 3,
                Name = "Puk van flat",
                Level = 0,
                Age = 0,
                Alive = 1,
                Currency = 100,
                Hapinness = 0,
                Health = 100
            });
        }

        public void Add(Tamagochi obj)
        {
            _tamagotchiList.Add(obj);
        }

        public List<Tamagochi> GetAll()
        {
            return _tamagotchiList;
        }

        public Tamagochi GetById(int? ID)
        {
            return _tamagotchiList.FirstOrDefault(x => x.Id == ID);
        }

        public void Remove(Tamagochi obj)
        {
            _tamagotchiList.Remove(obj);
        }

        public void Update(Tamagochi obj)
        {
            Tamagochi t = _tamagotchiList.FirstOrDefault(x => x.Id == obj.Id);

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
