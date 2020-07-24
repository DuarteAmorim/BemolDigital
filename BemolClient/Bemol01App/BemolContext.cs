using Bemol01App.Entities;
using Microsoft.EntityFrameworkCore;
using System;
namespace Bemol01App
{
    public class BemolContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Data Source=henrique-insp\sqlexpress;Initial Catalog=BemolDB;ConnectRetryCount=0;Persist Security Info=True;User ID=sa;Password=123");
        }
    }
}
