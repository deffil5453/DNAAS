using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DNASS.Data;
using DNASS.Models;
using DNASS.ViewModels;
using Microsoft.Extensions.Hosting;

namespace DNASS.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly DNASS.Data.DNASSDbContext _context;

        public EditModel(DNASS.Data.DNASSDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditProductVewModel EditProduct { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                EditProduct = new EditProductVewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Cost = product.Cost,
                    Skidka = product.Skidka,
                    ImgUrl = product.ImgUrl,
                    CategoryId = product.CategoryId,
                };
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task OnPostAsync(Guid id)
        {
            if (EditProduct != null)
            {
                var productAsync = await _context.Products.FindAsync(id);
                productAsync.Name = EditProduct.Name;
                productAsync.Description = EditProduct.Description;
                productAsync.Cost = EditProduct.Cost;
                productAsync.Skidka = EditProduct.Skidka;
                productAsync.ImgUrl = EditProduct.ImgUrl;
                productAsync.CategoryId = EditProduct.CategoryId;
                ViewData["Message"] = "Товар обновлён";
                await _context.SaveChangesAsync();

            }
        }
    }
}
