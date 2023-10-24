
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace CarsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connStr = builder.Configuration.GetConnectionString("LocalDb")!;
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<CarsApiDbContext>(opts => opts.UseSqlServer(connStr));

            //Business logic
            builder.Services.AddScoped<ICarsService, CarsService>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
