using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisement_MVC_.Models
{
    public class Jobs
    {
        public int Id { get; set; } //
        [Required]
        public string Job_role { get; set; }
        public string Job_type { get; set; }
        public decimal Job_salary { get; set; }
        public string Job_description { get; set; }
        public int Employe_Name { get; set; }
        public Employer Employer { get; set; }
    }
}
