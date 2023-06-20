using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorFood.Data;
using RazorFood.Models;

namespace RazorFood.Pages.Dishes
{
    public class IndexModel : PageModel
    {
        private readonly RazorFood.Data.RazorFoodContext _context;

        public IndexModel(RazorFood.Data.RazorFoodContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Courses { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SelectedCourse { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> courseQuery = from m in _context.Dish
                                            orderby m.Course
                                            select m.Course;

            var dishes = from d in _context.Dish
                         select d;
            if (!string.IsNullOrEmpty(SearchString))
            {
                dishes = dishes.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SelectedCourse))
            {
                dishes = dishes.Where(d => d.Course.Contains(SelectedCourse));
            }

            Courses = new SelectList(await courseQuery.Distinct().ToListAsync());

            Dish = await dishes.ToListAsync();
        }
    }
}
