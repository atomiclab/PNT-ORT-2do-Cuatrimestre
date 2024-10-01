using Microsoft.EntityFrameworkCore;
using ProjectoPNT.Entity;

namespace ProjectoPNT.Data;

public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       //      optionsBuilder.UseSqlServer("Server=localhost;Database=test;User Id=sa;Password=YourPassword!;TrustServerCertificate=true;");
       optionsBuilder.UseSqlServer(
           "Server = localhost; Database = ProyectoPNTDB; User Id= sa; Password= sa; Data Source = localhost; Initial Catalog = ProyectoPNT; Integrated Security = True; TrustServerCertificate=true;");

       base.OnConfiguring(optionsBuilder);
       
       //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
      // {}
  
}}