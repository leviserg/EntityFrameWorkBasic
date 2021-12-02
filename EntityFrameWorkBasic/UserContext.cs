using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkBasic
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
            optionsBuilder.UseMySql("Server=remotemysql.com;Database=swvroGhNgL;Uid=swvroGhNgL;Pwd=OvhionSoR4;", builder =>
            {
                builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), null);
            });
            base.OnConfiguring(optionsBuilder);
        }

    }
}
