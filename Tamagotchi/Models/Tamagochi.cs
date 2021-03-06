//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tamagotchi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tamagochi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tamagochi()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Nullable<decimal> Currency { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public byte Hapinness { get; set; }
        public byte Alive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
