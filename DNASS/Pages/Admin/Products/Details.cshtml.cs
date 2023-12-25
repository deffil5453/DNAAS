using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DNASS.Data;
using DNASS.Models;

namespace DNASS.Pages.Admin.Products
{
    public class DetailsModel : PageModel
    {
        private readonly DNASS.Data.DNASSDbContext _context;

        public DetailsModel(DNASS.Data.DNASSDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.FindAsync(id);
            }
        }
    }
}
