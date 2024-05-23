using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Data
{
    public class JobPortalDbContext:DbContext
    {
        public JobPortalDbContext()
        {
        }

        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Function> Functions { get; set; }

        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
        
        public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

        public virtual DbSet<Job> Jobs { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<fu_jo_ro> Fu_Jo_Ros {get;set;}
        public virtual DbSet<User> Users {get;set; }


    }
}