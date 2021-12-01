using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2201_Robot_Car_Website.Models
{
    public class DataContext : DbContext
    {   

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(entity => entity.Sid);

                entity.Property(entity => entity.StudentName)
                .IsRequired()
                .HasMaxLength(45);

                entity.Property(entity => entity.Class)
                .IsRequired()
                .HasMaxLength(4);
            });
        }
    }
}
