using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace mobilsentra.Controllers.Resources
{
    public class SaveVehicleResources
    {
        public int Id { get; set; }
        public int ModelId { get; set; }        
        [Required]
        public ContactResource Contact { get; set; }
        public Boolean IsRegistered { get; set; }
        
        public ICollection<int> Features { get; set; }

        public SaveVehicleResources (){
            Features = new Collection<int>();
        }
    }
}