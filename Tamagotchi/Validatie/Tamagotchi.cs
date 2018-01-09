﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tamagotchi.Domein.Models
{
    [MetadataType(typeof(TamagotchiAttributes))]
    public partial class Tamagochi
    {
        public sealed class TamagotchiAttributes
        {
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Naam is verplicht.")]
            [DisplayName("Name")]
            [MinLength(1, ErrorMessage = "Lengte van de naam moet minimaal uit 1 letter bestaan.")]
            [MaxLength(10, ErrorMessage = "Lengte van de naam mag maximaal uit 10 letters bestaan.")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Leeftijd is verplicht.")]
            [DisplayName("Age")]
            [DefaultValue(0)]
            public int Age { get; set; }
            [Required(ErrorMessage = "Geld is verplicht.")]
            [DisplayName("Currency")]
            [DefaultValue(100)]
            public Nullable<decimal> Currency { get; set; }
            [Required(ErrorMessage = "Level is verplicht.")]
            [DisplayName("Level")]
            [DefaultValue(0)]
            public int Level { get; set; }
            [Required(ErrorMessage = "Gezondheid is verplicht.")]
            [DisplayName("Health")]
            [Range(0, 100, ErrorMessage = "Gezondheid mag maar tussen de 0 en 100 bedragen.")]
            [DefaultValue(100)]
            public int Health { get; set; }
            [Required(ErrorMessage = "Verveling is verplicht.")]
            [DisplayName("Happiness")]
            [Range(0, 100, ErrorMessage = "Verveling mag maar tussen de 0 en 100 bedragen.")]
            [DefaultValue(0)]
            public byte Hapinness { get; set; }
            [Required(ErrorMessage = "Levend of Dood is verplicht.")]
            [DisplayName("Alive")]
            [DefaultValue(1)]
            public byte Alive { get; set; }
        }
    }
}