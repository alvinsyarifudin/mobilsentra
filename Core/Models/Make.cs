using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace mobilsentra.Core.Models
{
    public class Make
    {
        public int id {get;set;}
        [Required]
        [StringLength(255)]
        public string Name {get;set;}
        public ICollection<Model> Models {get;set;}

        public Make()
        {
            Models = new Collection<Model>();
        }
    }
} 