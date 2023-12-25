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
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;

namespace DNASS.Pages.Admin.Products
{
    [Authorize(Roles ="Admin")]
    public class IndexModel : PageModel
    {
        private readonly DNASSDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(DNASSDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
        public async Task<IActionResult> OnPostAddToCart(Guid productid)
        {
            var user = await _userManager.GetUserAsync(User);
            var cartitem = new CartItem
            {
                ProductId = productid,
                UserId = user.Id
            };
            _context.CartItems.Add(cartitem);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/Products/Index");
        }
    }
}
