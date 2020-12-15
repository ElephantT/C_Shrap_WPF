using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace lab15
{
    public class UsersDB : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDB()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=userdb;Trusted_Connection=True;");
        }
    }
}
