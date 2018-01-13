using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Models
{
    [MetadataType(typeof(BookingAttributes))]
    public partial class Booking
    {
        public sealed class BookingAttributes
        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Amount of nights is required.")]
            [DisplayName("Nights")]
            public int Nights { get; set; }
            [Required(ErrorMessage = "A tamagotchi is required.")]
            public int TamagotchiId { get; set; }
            [Required(ErrorMessage = "A Hotelroom is required.")]
            public int HotelroomId { get; set; }
        }
    }
}