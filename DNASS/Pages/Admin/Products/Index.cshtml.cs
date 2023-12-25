using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DNASS.Data;
using DNASS.Models;
using Microsoft.AspNetCore.Authorization;

namespace DNASS.Pages.Admin.Products
{
    [Authorize(Roles ="Admin")]
    public class IndexModel : PageModel
    {
        private readonly DNASS.Data.DNASSDbContext _context;

        public IndexModel(DNASS.Data.DNASSDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
