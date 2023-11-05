using Core.ApiModels;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Services;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CarsApiDbContext>()
                .AddDefaultTokenProviders();

            // Business logic
            builder.Services.AddScoped<ICarsService, CarsService>();
            builder.Services.AddScoped<ICategoriesService, CategoriesService>();
            builder.Services.AddScoped<IAccountsService, AccountsService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Validation
            builder.Services.AddTransient<IValidator<CreateCarModel>, CreateCarModelValidator>();
            builder.Services.AddTransient<IValidator<EditCarModel>, EditCarModelValidator>();
            builder.Services.AddTransient<IValidator<Category>, EditCategoryModelValidator>();
            builder.Services.AddTransient<IValidator<CreateCategoryModel>, CreateCategoryModelValidator>();

            // configure AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure JWT token
            var jwtOpts = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOpts.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
