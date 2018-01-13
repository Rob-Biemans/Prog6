using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Models
{
    [MetadataType(typeof(TamagotchiAttributes))]
    public partial class Tamagochi
    {
        public sealed class TamagotchiAttributes
        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Name is required.")]
            [DisplayName("Name")]
            [MinLength(1, ErrorMessage = "Length must be atleast 1.")]
            [MaxLength(10, ErrorMessage = "The maximum allowed length is 10.")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Age is required.")]
            [DisplayName("Age")]
            [DefaultValue(0)]
            public int Age { get; set; }
            [Required(ErrorMessage = "Currency is required.")]
            [DisplayName("Currency")]
            [DefaultValue(100)]
            public Nullable<decimal> Currency { get; set; }
            [Required(ErrorMessage = "Level is required.")]
            [DisplayName("Level")]
            [DefaultValue(0)]
            public int Level { get; set; }
            [Required(ErrorMessage = "Health is required.")]
            [DisplayName("Health")]
            [Range(0, 100, ErrorMessage = "Health must be between 0 and 100.")]
            [DefaultValue(100)]
            public int Health { get; set; }
            [Required(ErrorMessage = "Happiness is required.")]
            [DisplayName("Happiness")]
            [Range(0, 100, ErrorMessage = "Happiness must be between 0 and 100.")]
            [DefaultValue(0)]
            public byte Hapinness { get; set; }
            [Required(ErrorMessage = "Alive or Death is required.")]
            [DisplayName("Alive")]
            [DefaultValue(1)]
            public byte Alive { get; set; }
        }
    }
}