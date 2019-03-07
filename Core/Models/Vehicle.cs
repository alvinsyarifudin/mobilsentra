using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobilsentra.Core.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
      
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        [Required]
        [StringLength(255)]
        public String ContactName { get; set; }
        [Required]
        [StringLength(255)]
        public String ContactPhone { get; set; }
        public String contactEmail { get; set; }
        public Boolean IsRegistered { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle (){
            Features = new Collection<VehicleFeature>();
        }
    }
}