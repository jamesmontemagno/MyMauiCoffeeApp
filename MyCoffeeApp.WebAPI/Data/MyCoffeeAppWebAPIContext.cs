using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.Shared.Models;

namespace MyCoffeeApp.WebAPI.Data
{
    public class MyCoffeeAppWebAPIContext : DbContext
    {
        public MyCoffeeAppWebAPIContext (DbContextOptions<MyCoffeeAppWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MyCoffeeApp.Shared.Models.Coffee> Coffee { get; set; } = default!;
    }
}
