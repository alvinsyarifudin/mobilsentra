using System.Collections.Generic;
using System.Collections.ObjectModel;
using mobilsentra.Core.Models;
using mobilsentra.Persistence;

namespace mobilsentra.Controllers.Resources
{
    public class MakeResource : KeyValuePairs
    {    
        public ICollection<KeyValuePairs> Models {get;set;}

        private readonly MobilSentraDbContext db;

        public MakeResource()
        {
            Models = new Collection<KeyValuePairs>();
        }
     
    }
}