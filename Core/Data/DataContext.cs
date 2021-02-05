using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<MoneyChangeRecord> MoneyChangeBodies { get; set; }
        public DbSet<MoneyChangeType> MoneyChangeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#if DEBUG
            //optionsBuilder.LogTo(System.Console.WriteLine);
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
            //#endif
        }

    }
}
