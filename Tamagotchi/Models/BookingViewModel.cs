using System;
using System.ComponentModel;
using Tamagotchi.Domein.Models;

namespace Tamagotchi.Models
{
    public class BookingViewModel
    {
        [DisplayName("Start")]
        public System.DateTime Start { get; set; }
        [DisplayName("End")]
        public Nullable<System.DateTime> End { get; set; }

        public int TamagotchiId { get; set; }
        public int HotelroomId { get; set; }

        public BookingViewModel(Booking b)
        {
            Start = b.Start;
            End = b.End;
            TamagotchiId = b.TamagotchiId;
            HotelroomId = b.HotelroomId;
        }
    }
}