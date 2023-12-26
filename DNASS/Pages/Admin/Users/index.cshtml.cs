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

namespace DNASS.Pages.Admin.Users
{
    [Authorize(Roles ="Admin")]
    public class indexModel : PageModel
    {
        private readonly DNASS.Data.DNASSDbContext _context;

        public indexModel(DNASS.Data.DNASSDbContext context)
        {
            _context = context;
        }

        public IList<User> Users { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
