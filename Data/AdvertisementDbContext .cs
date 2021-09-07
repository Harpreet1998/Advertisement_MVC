using Advertisement_MVC_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Advertisement_MVC_.Data
{
    public class AdvertisementDbContext : DbContext
    {

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<Apply_job_detail> Apply_job_detail { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public AdvertisementDbContext(DbContextOptions<AdvertisementDbContext> options)
            : base(options)
        {
        }
        public AdvertisementDbContext()
        {
        }
    }
}
