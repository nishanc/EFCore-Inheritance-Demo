using InheritanceStrategyDemoEFCore5.Models.TPCModels;
using InheritanceStrategyDemoEFCore5.Models.TPHModels;
using InheritanceStrategyDemoEFCore5.Models.TPTModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InheritanceStrategyDemoEFCore5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Model classes for Table per hierarchy
        public DbSet<TPHUser> TPHUsers { get; set; }
        public DbSet<TPHStudent> TPHStudents { get; set; }
        public DbSet<TPHTeacher> TPHTeachers { get; set; }

        // Model classes for Table per type
        public DbSet<TPTUser> TPTUsers { get; set; }
        public DbSet<TPTStudent> TPTStudents { get; set; }
        public DbSet<TPTTeacher> TPTTeachers { get; set; }

        // Model classes for Table per Concrete Type
        public DbSet<TPCStudent> TPCStudents { get; set; }
        public DbSet<TPCTeacher> TPCTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table per hierarchy pattern - configure discriminator
            modelBuilder.Entity<TPHUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<TPHTeacher>("Teacher")
                .HasValue<TPHStudent>("Student");

            // Table per type pattern
            modelBuilder.Entity<TPTStudent>().ToTable("TPTStudents");
            modelBuilder.Entity<TPTTeacher>().ToTable("TPTTeachers");

        }
    }
}
