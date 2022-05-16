using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serverScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serverScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data");

                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name = "Dot NET",
                        Publisher = "Soloncy",
                        Cost = "Free"
                    }
                    );

            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        } 

    }
}
