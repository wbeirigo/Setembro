using System;
using System.Linq;
using CarService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.Data
{
        public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            using (serviceScope)
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if(!context.Car.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Car.AddRange(
                    new Car() {Marca = "WolksWagem", Modelo="Gol", Ano=2015, Preco=30000 },
                    new Car() {Marca = "WolksWagem", Modelo="Fusca", Ano=1933, Preco=30000 },
                    new Car() {Marca = "WolksWagem", Modelo="Paraty", Ano=2000, Preco=30000 }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}