using Microsoft.EntityFrameworkCore;
using ProyectoPNT.Entity;

namespace ProyectoPNT.Context;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Archivo3D> Archivos3D { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       //      optionsBuilder.UseSqlServer("Server=localhost;Database=test;User Id=sa;Password=YourPassword!;TrustServerCertificate=true;");
       optionsBuilder.UseSqlServer(
           "Server=localhost;Database=ProyectoPNTDB;User Id= SA; Password=reallyStrongPwd123;TrustServerCertificate=true;");

       base.OnConfiguring(optionsBuilder);
       
       //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
      // {}
  
}}