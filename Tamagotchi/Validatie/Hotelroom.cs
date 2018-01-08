using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domein.Models
{
    [MetadataType(typeof(HotelroomAttributes))]
    public partial class Hotelroom
    {
        public sealed class HotelroomAttributes {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Aantal bedden is verplicht. (2, 3 of 5)")]
            [DisplayName("Beds")]
            [Range(2, 5)]
            public byte Beds { get; set; }
            [Required(ErrorMessage = "Het type is verplicht.")]
            [DisplayName("Type")]
            public string Type { get; set; }
            [Required(ErrorMessage = "Prijs is verplicht.")]
            [DisplayName("Price")]
            public decimal Price { get; set; }
        }
    }
}