using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorFood.Models;

namespace RazorFood.Data
{
    public class RazorFoodContext : DbContext
    {
        public RazorFoodContext (DbContextOptions<RazorFoodContext> options)
            : base(options)
        {
        }

        public DbSet<RazorFood.Models.Dish> Dish { get; set; } = default!;
    }
}
