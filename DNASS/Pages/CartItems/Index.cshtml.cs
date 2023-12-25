using DNASS.Data;
using DNASS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DNASS.Pages.CartItems
{
    public class IndexModel : PageModel
    {
        private readonly DNASSDbContext _context;
        private readonly UserManager<User> _userManager;

        public IndexModel(DNASSDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal totalPrice { get; set; }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                CartItems = await _context.CartItems.Include(ci => ci.Product).Where(ci => ci.UserId == user.Id).ToListAsync();
                totalPrice = CartItems.Sum(ci=>ci.Product.Cost);
            }
        }
        public async Task<IActionResult> OnPostDetete(Guid productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var cartItem = await _context.CartItems
                    .Include(ci => ci.Product)
                    .FirstOrDefaultAsync(ci => ci.UserId == user.Id && ci.Product.Id == productId);

                if (cartItem != null)
                {
                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("/CartItems/Index");
        }
        public async Task<IActionResult> OnPostAddToOrderAsync(Guid productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var cartItem = await _context.CartItems
                    .Include(ci => ci.Product)
                    .FirstOrDefaultAsync(ci => ci.UserId == user.Id && ci.Product.Id == productId);

                if (cartItem != null)
                {
                    var order = new Order()
                    {
                        Name = Guid.NewGuid(),
                        DateCreationOrder = DateOnly.FromDateTime(DateTime.Today),
                        OrdersProduct = new List<OrderProduct>()
                        {
                            new OrderProduct()
                            {
                                ProductId = productId,
                                ProductCount = 1
                            }
                        }

                    };
                    _context.Orders.Add(order);
                    _context.Remove(cartItem);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("/CartItems/Index");
        }
    }

    

}
