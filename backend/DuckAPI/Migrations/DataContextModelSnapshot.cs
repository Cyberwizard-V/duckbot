﻿// <auto-generated />
using DuckAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DuckAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DuckAPI.Models.Duck", b =>
                {
                    b.Property<int>("DuckID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DuckID"));

                    b.Property<string>("DuckColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DuckGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DuckName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuckloreID")
                        .HasColumnType("int");

                    b.HasKey("DuckID");

                    b.HasIndex("DuckloreID");

                    b.ToTable("Ducks");
                });

            modelBuilder.Entity("DuckAPI.Models.Ducklore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Lore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Ducklores");
                });

            modelBuilder.Entity("DuckAPI.Models.Duckuser", b =>
                {
                    b.Property<int>("DuckUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DuckUserID"));

                    b.Property<string>("DuckPW")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duckusername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("DuckUserID");

                    b.ToTable("Duckusers");
                });

            modelBuilder.Entity("DuckAPI.Models.Duck", b =>
                {
                    b.HasOne("DuckAPI.Models.Ducklore", "Ducklore")
                        .WithMany("Ducks")
                        .HasForeignKey("DuckloreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ducklore");
                });

            modelBuilder.Entity("DuckAPI.Models.Ducklore", b =>
                {
                    b.Navigation("Ducks");
                });
#pragma warning restore 612, 618
        }
    }
}
