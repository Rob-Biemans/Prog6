//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tamagotchi.Domein.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public int TamagotchiId { get; set; }
        public int HotelroomId { get; set; }
    
        public virtual Hotelroom Hotelroom { get; set; }
        public virtual Tamagochi Tamagochi { get; set; }
    }
}
