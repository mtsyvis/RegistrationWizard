using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Core.Entities;

namespace RegistrationWizard.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<User> Users { get; set; }

    public string DbPath { get; }

    public ApplicationDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "registration_wizard.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure primary keys
        modelBuilder.Entity<User>()
            .HasKey(u => u.Login);

        modelBuilder.Entity<Country>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<Province>()
            .HasKey(u => u.Id);

        // Configure User Login property
        modelBuilder.Entity<User>()
            .Property(u => u.Login)
            .IsRequired()
            .HasMaxLength(50);

        // Configure Contry Name property
        modelBuilder.Entity<Country>()
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Configure Province Name property
        modelBuilder.Entity<Province>()
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Configure the foreign key relationship between Country and Province
        modelBuilder.Entity<Province>()
            .HasOne(p => p.Country)
            .WithMany(c => c.Provinces)
            .HasForeignKey(p => p.CountryId);

        // Configure the foreign key relationships for User
        modelBuilder.Entity<User>()
            .HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Province)
            .WithMany()
            .HasForeignKey(u => u.ProvinceId);

        // Populate the database with some data
        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "Country 1" },
            new Country { Id = 2, Name = "Country 2" }
        );

        modelBuilder.Entity<Province>().HasData(
            new Province { Id = 1, Name = "Province 1.1", CountryId = 1 },
            new Province { Id = 2, Name = "Province 1.2", CountryId = 1 },
            new Province { Id = 3, Name = "Province 2.1", CountryId = 2 }
        );
    }
}
