using System;
using System.ComponentModel;
using Tamagotchi.Domein.Models;

namespace Tamagotchi.Models
{
    public class HotelroomViewModel
    {
        [DisplayName("Beds")]
        public byte Beds { get; set; }
        [DisplayName("Type")]
        public string Type { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }

        public HotelroomViewModel(Hotelroom h)
        {
            Beds = h.Beds;
            Type = h.Type;
            Price = h.Price;
        }
    }
}