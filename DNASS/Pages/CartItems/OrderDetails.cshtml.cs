using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DNASS.Data;
using DNASS.Models;

namespace DNASS.Pages.CartItems
{
    public class OrderDetailsModel : PageModel
    {
        private readonly DNASS.Data.DNASSDbContext _context;

        public OrderDetailsModel(DNASS.Data.DNASSDbContext context)
        {
            _context = context;
        }

        public Order Order { get;set; }
        public string UserFullName { get; set; }
        public async Task OnGetAsync(Guid Id)
        {
            Order = await _context.Orders
                .Include(o => o.OrdersProduct)
                .ThenInclude(op=>op.Product)
                .Include(o=>o.User)
                .FirstOrDefaultAsync(o=>o.Id == Id);
            UserFullName = Order.User.LastName +" "+ Order.User.FirstName + " " + Order.User.MiddleName;
        }
    }
}