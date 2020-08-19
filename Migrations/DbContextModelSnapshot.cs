﻿// <auto-generated />
using BulkExtensionsIssue354;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BulkExtensionsIssue354.Migrations
{
    [DbContext(typeof(DbContext))]
    partial class DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("BulkExtensionsIssue354.Model.EntityA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EntityAs");
                });

            modelBuilder.Entity("BulkExtensionsIssue354.Model.EntityB", b =>
                {
                    b.Property<int>("EntityAId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("EntityAId", "Id");

                    b.ToTable("EntityBs");
                });

            modelBuilder.Entity("BulkExtensionsIssue354.Model.EntityC", b =>
                {
                    b.Property<int>("EntityAId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntityBId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntityAId", "EntityBId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("EntityCs");
                });

            modelBuilder.Entity("BulkExtensionsIssue354.Model.IdC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("IdCs");
                });

            modelBuilder.Entity("BulkExtensionsIssue354.Model.EntityB", b =>
                {
                    b.HasOne("BulkExtensionsIssue354.Model.EntityA", "EntityA")
                        .WithMany("EntityBs")
                        .HasForeignKey("EntityAId")
                        .IsRequired();
                });

            modelBuilder.Entity("BulkExtensionsIssue354.Model.EntityC", b =>
                {
                    b.HasOne("BulkExtensionsIssue354.Model.EntityA", "EntityA")
                        .WithMany()
                        .HasForeignKey("EntityAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulkExtensionsIssue354.Model.IdC", "IdC")
                        .WithMany("EntityCs")
                        .HasForeignKey("Id")
                        .IsRequired();

                    b.HasOne("BulkExtensionsIssue354.Model.EntityB", "EntityB")
                        .WithMany("EntityCs")
                        .HasForeignKey("EntityAId", "EntityBId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
