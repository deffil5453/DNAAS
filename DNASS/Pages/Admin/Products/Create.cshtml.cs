using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DNASS.Data;
using DNASS.Models;
using DNASS.ViewModels;

namespace DNASS.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly DNASS.Data.DNASSDbContext _context;

        public CreateModel(DNASS.Data.DNASSDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public AddProductViewModel AddProduct { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var product = new Product()
            {
                Name = AddProduct.Name,
                Description = AddProduct.Description,
                Cost = AddProduct.Cost,
                Skidka = AddProduct.Skidka,
                ImgUrl = AddProduct.ImgUrl,
                CategoryId = AddProduct.CategoryId,
                

            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
