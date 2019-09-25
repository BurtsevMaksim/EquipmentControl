using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EquipmentControl.Data;

namespace EquipmentControl.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LastochkaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LastochkaContext>>()))
            {
                // Look for any movies.
                if (context.Lastochka.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lastochka.AddRange(
                    new Lastochka
                    {
                        TrainNumber = "ES-2G-21",
                        MarIP = "10.115.21.253"
                    },

                    new Lastochka
                    {
                        TrainNumber = "ES-2G-22",
                        MarIP = "10.115.22.253"
                    },

                    new Lastochka
                    {
                        TrainNumber = "ES-2G-23",
                        MarIP = "10.115.23.253"
                    },

                    new Lastochka
                    {
                        TrainNumber = "Static",
                        MarIP = "213.182.181.212"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
