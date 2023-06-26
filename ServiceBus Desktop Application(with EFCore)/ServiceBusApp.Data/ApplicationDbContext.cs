using Microsoft.EntityFrameworkCore;
using ServiceBusApp.Models.Abstractions;
using ServiceBusApp.Models.Concretes;


namespace ServiceBusApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public DbSet<Student> Students { get; set; }

    public DbSet<Class> Classes { get; set; }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Parent> Parents { get; set; }

    public DbSet<Ride> Rides { get; set; }


    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
                    .HasMany(c => c.Students)
                    .WithOne(s => s.Class)
                    .HasForeignKey(s => s.ClassId)
                    .OnDelete(DeleteBehavior.SetNull);
    }

    protected sealed override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
    }

    public override int SaveChanges()
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreationTime = DateTime.Now,
                EntityState.Modified => data.Entity.LastModifiedTime = DateTime.Now,
                _ => DateTime.UtcNow
            };
        }
        return base.SaveChanges();
    }
}