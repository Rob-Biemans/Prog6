using System;
using System.ComponentModel;
using Tamagotchi.Domein.Models;

namespace Tamagotchi.Models
{
    public class TamagotchiViewModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
        [DisplayName("Currency")]
        public Nullable<decimal> Currency { get; set; }
        [DisplayName("Level")]
        public int Level { get; set; }
        [DisplayName("Health")]
        public int Health { get; set; }
        [DisplayName("Happiness")]
        public byte Hapinness { get; set; }
        [DisplayName("Alive")]
        public byte Alive { get; set; }

        public TamagotchiViewModel(Tamagochi t)
        {
            Name = t.Name;
            Age = t.Age;
            Currency = t.Currency;
            Level = t.Level;
            Health = t.Health;
            Hapinness = t.Hapinness;
            Alive = t.Alive;
        }
    }
}