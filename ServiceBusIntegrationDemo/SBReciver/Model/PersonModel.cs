using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBReciver.Model
{
    internal class PersonModel
    
    {
        [Required]
        public string FirestName { get; set; }
       
        [Required]
        public string LastName { get; set; }
    }
}
