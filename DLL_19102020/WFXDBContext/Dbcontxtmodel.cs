using BLL_19102020.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace DLL_19102020.WFXDBContext
{
    public partial class Dbcontxtmodel : DbContext
    {
        const string constrings = "wfxaudit";
        // use in dotnet 3.1
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if(!optionsBuilder.IsConfigured)
        //    {

        //        //  optionsBuilder.UseSqlQuery(@"Data Source=DESKTOP-I9MNF8O\SQLEXPRESS;Database=pharmacy;uid=sa;password=sa@123;");
        //        optionsBuilder.UseSqlServer(constrings);
        //    }
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Customer> customers { get; set; }
    }
}
