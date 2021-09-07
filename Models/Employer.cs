using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisement_MVC_.Models
{
    public class Employer
    {
        public int Id { get; set; }

        [Required]
        public string Employer_name { get; set; }
        public DateTime Date_of_establishment { get; set; }
        public string Address_of_employer { get; set; }
    }
}
