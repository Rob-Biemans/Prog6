using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchi.Models
{
    [MetadataType(typeof(HotelroomAttributes))]
    public partial class Hotelroom
    {
        public sealed class HotelroomAttributes {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Amount of beds is required. (2, 3 of 5)")]
            [DisplayName("Beds")]
            [Range(2, 5)]
            [RegularExpression("(2|3|5)", ErrorMessage = "Amount does not contain one of the following options: 2, 3 of 5")]
            public byte Beds { get; set; }
            [Required(ErrorMessage = "Type is required.")]
            [DisplayName("Type")]
            [RegularExpression("(REST|FIGHT|GAME|WORK|MISC)", ErrorMessage = "Type does not contain one of the following options: REST,FIGHT,GAME,WORK,MISC")]
            public string Type { get; set; }
            [Required(ErrorMessage = "Price is required.")]
            [DisplayName("Price")]
            [DefaultValue(10)]
            [Range(1,30)]
            public decimal Price { get; set; }
        }
    }
}