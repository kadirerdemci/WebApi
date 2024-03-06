using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concretes;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class WebApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=WebApi;Username=postgres;Password=123456");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; } 

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; } 
        public DbSet<Users> Users { get; set; }
    }
}
