using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeMvc.Models;
using PracticeMvc.Models.Views;

namespace PracticeMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PracticeMvc.Models.Employee1> Employee1 { get; set; }
        public DbSet<PracticeMvc.Models.Department> Department { get; set; }
        public DbSet<PracticeMvc.Models.Views.GoodsPurchaseViews> GoodsPurchaseViews { get; set; }

    }
}
