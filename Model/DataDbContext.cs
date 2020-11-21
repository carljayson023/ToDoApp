using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoApp_v1._2.Model
{
    public class DataDbContext : DbContext
    {
        public DbSet<Itemlist> Itemlists { get; set; }
        public DbSet<Datalist> Datalists { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=datalist.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
