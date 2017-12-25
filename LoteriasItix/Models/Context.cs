using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace LoteriasItix.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
        }

        public DbSet<Aposta> Apostas { get; set; }
        public DbSet<Sorteio> Sorteios { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Aposta>().ToTable("Apostas");
        //    modelBuilder.Entity<Sorteio>().ToTable("Sorteios");
        //}
    }

    public class SorteioDBInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);
        }
    }
}