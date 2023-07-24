using System.Reflection;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeFeature> EmployeeFeatures { get; set; }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeFeature>().HasData(new EmployeeFeature
        {
                Id = 1,
                Age = 20,
                Email = "qwerty123@gmail.com",
                Number = "0512 345 67 89",
                Gender = "Erkek",
                Language ="ingilizce",
                MilitaryService = true,
                Feature1 = "MVC",
                Feature2 = "Core",
                Feature3 = "SQL",
                Feature4 = "java",
                Experience = 3,



        },
            new EmployeeFeature
            {
                Id = 2,
                Age = 20,
                Email = "qwerty3838@gmail.com",
                Number = "0555 555 55 55",
                Gender = "Erkek",
                Language = "ingilizce",
                MilitaryService = false,
                Feature1 = "python",
                Feature2 = "c#",
                Feature3 = "c++",
                Feature4 = "java",
                Experience = 6,

            });

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
    */
}
}