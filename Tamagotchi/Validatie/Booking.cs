using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domein.Models
{
    [MetadataType(typeof(BookingAttributes))]
    public partial class Booking
    {
        public sealed class BookingAttributes
        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Start datum is verplicht.")]
            [DisplayName("Start")]
            [DataType(DataType.Date)]
            public System.DateTime Start { get; set; }
            [Required(ErrorMessage = "Eind datum is verplicht.")]
            [DisplayName("Einde")]
            [DataType(DataType.Date)]
            public Nullable<System.DateTime> End { get; set; }

            [Required(ErrorMessage = "Een tamagotchi is verplicht.")]
            public int TamagotchiId { get; set; }
            [Required(ErrorMessage = "Een Hotelkamer is verplicht.")]
            public int HotelroomId { get; set; }
        }
    }
}