using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCrudWithIdentity.Data;
using StudentCrudWithIdentity.Models;

namespace StudentCrudWithIdentity.Pages_Premiuns
{
    public class EditModel : PageModel
    {
        private readonly StudentCrudWithIdentity.Data.ApplicationDbContext _context;

        public EditModel(StudentCrudWithIdentity.Data.ApplicationDbContext context)
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

            var premiun =  await _context.Premiuns.FirstOrDefaultAsync(m => m.Id == id);
            if (premiun == null)
            {
                return NotFound();
            }
            Premiun = premiun;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Premiun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiunExists(Premiun.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PremiunExists(int id)
        {
          return (_context.Premiuns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
