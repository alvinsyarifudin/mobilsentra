using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mobilsentra.Core.Models;

namespace mobilsentra.Controllers.Resources
{
    public class VehicleResources
    {
        public int Id { get; set; }
        public KeyValuePairs Make { get; set; }
        public KeyValuePairs Model { get; set; }
        public ContactResource Contact { get; set; }        
        public DateTime LastUpdate { get; set; }
        public ICollection<KeyValuePairs> Features { get; set; }

        public VehicleResources (){
            Features = new Collection<KeyValuePairs>();
        } 
    }
}