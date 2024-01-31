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
    public class DeleteModel : PageModel
    {
        private readonly StudentCrudWithIdentity.Data.ApplicationDbContext _context;

        public DeleteModel(StudentCrudWithIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Premiun Premiun { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Premiuns == null)
            {
                return NotFound();
            }

            var premiun = await _context.Premiuns.FirstOrDefaultAsync(m => m.Id == id);

            if (premiun == null)
            {
                return NotFound();
            }
            else 
            {
                Premiun = premiun;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Premiuns == null)
            {
                return NotFound();
            }
            var premiun = await _context.Premiuns.FindAsync(id);

            if (premiun != null)
            {
                Premiun = premiun;
                _context.Premiuns.Remove(Premiun);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
