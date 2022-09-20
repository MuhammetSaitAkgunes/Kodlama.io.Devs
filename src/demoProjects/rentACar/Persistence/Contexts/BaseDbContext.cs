using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgramingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.LanguageName).HasColumnName("LanguageName");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.LanguageId).HasColumnName("LanguageId");
                a.Property(p => p.TechnologyName).HasColumnName("TechnologyName");
                //a.Property(p => p.TechnologyForPL).HasColumnName("ProgrammingLanguage");
                a.HasOne(p => p.ProgrammingLanguage);
            });


            ProgrammingLanguage[] languagesSeeds = { new(1, "C#"), new(2, "Java"), new(3, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(languagesSeeds);

            Technology[] technologySeeds = { new(1, 1, "Blazor"), new(2, 2, "Spring"), new(3, 3, "Pandas"), new(4, 3, "Tensorflow") };
            modelBuilder.Entity<Technology>().HasData(technologySeeds);
        }
    }
}