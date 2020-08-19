using System;
using BulkExtensionsIssue354.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkExtensionsIssue354
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<EntityA> EntityAs { get; set; }
        public DbSet<EntityB> EntityBs { get; set; }
        public DbSet<EntityC> EntityCs { get; set; }
        public DbSet<IdC> IdCs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new NullReferenceException();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityA>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<EntityB>(entity =>
            {
                entity.HasKey(e => new {e.EntityAId, e.Id});

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.EntityA)
                    .WithMany(p => p.EntityBs)
                    .HasForeignKey(d => d.EntityAId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EntityC>(entity =>
            {
                entity.HasKey(e => new {e.EntityAId, e.EntityBId, e.Id});

                entity.HasOne(d => d.IdC)
                    .WithMany(p => p.EntityCs)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.EntityB)
                    .WithMany(p => p.EntityCs)
                    .HasForeignKey(d => new {d.EntityAId, d.EntityBId})
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            
            modelBuilder.Entity<IdC>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }
    }
}