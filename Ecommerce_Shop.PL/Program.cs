
using Ecommerce_Shop.BLL.Services;
using Ecommerce_Shop.DAL.Data;
using Ecommerce_Shop.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar;
using Scalar.AspNetCore;

namespace Ecommerce_Shop.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapScalarApiReference();

            app.MapControllers();

            app.Run();
        }
    }
}
