using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisement_MVC_.Models
{
    public class Candidates
    {
        public int Id { get; set; }
        [Required]
        public string Name_of_candidate { get; set; }
        
        public DateTime DOB_of_candidate { get; set; }
     
        public string Mobile_no_of_candidate { get; set; }
        public string Email_address_of_candidate { get; set; }
    }
}
