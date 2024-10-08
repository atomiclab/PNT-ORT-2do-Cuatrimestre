﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPNT.Context;

#nullable disable

namespace ProjectoPNT.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoPNT.Entity.Archivo3D", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RepositorioArchivosBorradosId")
                        .HasColumnType("int");

                    b.Property<int?>("RepositorioArchivosId")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tamano")
                        .HasColumnType("float");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RepositorioArchivosBorradosId");

                    b.HasIndex("RepositorioArchivosId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Archivos3D");
                });

            modelBuilder.Entity("ProyectoPNT.Entity.RepositorioArchivos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("RepositorioArchivos");
                });

            modelBuilder.Entity("ProyectoPNT.Entity.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoPNT.Entity.Archivo3D", b =>
                {
                    b.HasOne("ProyectoPNT.Entity.RepositorioArchivos", "RepositorioArchivosBorrados")
                        .WithMany("ArchivosBorrados")
                        .HasForeignKey("RepositorioArchivosBorradosId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProyectoPNT.Entity.RepositorioArchivos", "RepositorioArchivos")
                        .WithMany("Archivos")
                        .HasForeignKey("RepositorioArchivosId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProyectoPNT.Entity.Usuario", "Usuario")
                        .WithMany("Archivos3D")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RepositorioArchivos");

                    b.Navigation("RepositorioArchivosBorrados");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProyectoPNT.Entity.RepositorioArchivos", b =>
                {
                    b.Navigation("Archivos");

                    b.Navigation("ArchivosBorrados");
                });

            modelBuilder.Entity("ProyectoPNT.Entity.Usuario", b =>
                {
                    b.Navigation("Archivos3D");
                });
#pragma warning restore 612, 618
        }
    }
}
