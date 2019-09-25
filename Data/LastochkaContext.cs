using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentControl.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentControl.Data
{
    public class LastochkaContext : DbContext
    {
        public LastochkaContext(DbContextOptions<LastochkaContext> options) : base(options)
        {
        }
        public DbSet<Lastochka> Lastochka { get; set; }
    }
}
