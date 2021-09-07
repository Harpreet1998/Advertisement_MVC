using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertisement_MVC_.Models
{
    public class Apply_job_detail
    {

        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidates Candidate { get; set; }
        public int Job_DetailId { get; set; }
        public Jobs Job_Detail { get; set; }
        [Required]
        public string Candidate_availabilities { get; set; }
        public DateTime Candidate_notice_period { get; set; }
    }
}
