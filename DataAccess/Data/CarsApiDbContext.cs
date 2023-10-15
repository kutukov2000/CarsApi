using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class CarsApiDbContext : DbContext
    {
        public CarsApiDbContext() { }
        public CarsApiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category {Id = 1, Name = "Sedan", Description = "A passenger car with a closed body and two rows of seats."},
                new Category {Id = 2, Name = "Truck", Description = "A large motor vehicle used for transporting goods."},
                new Category {Id = 3, Name = "SUV", Description = "A rugged automotive vehicle similar to a station wagon but built on a light-truck chassis."},
                new Category {Id = 4, Name = "Sports Car", Description = "A low-built car designed for performance at high speeds."},
                new Category {Id = 5, Name = "Hatchback", Description = "A small car with a rear door that opens upwards."},
                new Category {Id = 6, Name = "Convertible", Description = "A car with a roof that can be folded back."},
                new Category {Id = 7, Name = "Minivan", Description = "A small van, typically one used for transporting passengers."},
                new Category {Id = 8, Name = "Coupe", Description = "A two-door car with a fixed roof."},
                new Category {Id = 9, Name = "Crossover", Description = "A vehicle that combines the features of an SUV with those of a passenger car."},
                new Category {Id = 10, Name = "Electric", Description = "A car that runs on electricity stored in batteries."}
            });

            modelBuilder.Entity<Car>().HasData(new[]
            {
                new Car {Id = 1, Producer = "Toyota", Model = "Camry", Year = 2022, CategoryId = 1},
                new Car {Id = 2, Producer = "Ford", Model = "F-150", Year = 2021, CategoryId = 2},
                new Car {Id = 3, Producer = "Chevrolet", Model = "Malibu", Year = 2023, CategoryId = 1},
                new Car {Id = 4, Producer = "Honda", Model = "Civic", Year = 2022, CategoryId = 5},
                new Car {Id = 5, Producer = "BMW", Model = "X5", Year = 2022, CategoryId = 3},
                new Car {Id = 6, Producer = "Audi", Model = "A4", Year = 2023, CategoryId = 2},
                new Car {Id = 7, Producer = "Mercedes-Benz", Model = "E-Class", Year = 2021, CategoryId = 4},
                new Car {Id = 8, Producer = "Nissan", Model = "Altima", Year = 2022, CategoryId = 1},
                new Car {Id = 9, Producer = "Tesla", Model = "Model 3", Year = 2023, CategoryId = 10},
                new Car {Id = 10, Producer = "Volkswagen", Model = "Golf", Year = 2021, CategoryId = 5}
            });

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
