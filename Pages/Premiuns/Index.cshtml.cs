using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentCrudWithIdentity.Data;
using StudentCrudWithIdentity.Models;

namespace StudentCrudWithIdentity.Pages_Premiuns
{
    public class IndexModel : PageModel
    {
        private readonly StudentCrudWithIdentity.Data.ApplicationDbContext _context;

        public IndexModel(StudentCrudWithIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premiun> Premiun { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Premiuns != null)
            {
                Premiun = await _context.Premiuns
                .Include(p => p.Student).ToListAsync();
            }
        }
    }
}
