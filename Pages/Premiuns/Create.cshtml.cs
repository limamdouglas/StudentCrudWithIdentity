using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCrudWithIdentity.Data;
using StudentCrudWithIdentity.Models;

namespace StudentCrudWithIdentity.Pages_Premiuns
{
    public class CreateModel : PageModel
    {
        private readonly StudentCrudWithIdentity.Data.ApplicationDbContext _context;

        public CreateModel(StudentCrudWithIdentity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Premiun Premiun { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Premiuns == null || Premiun == null)
            {
                return Page();
            }

            _context.Premiuns.Add(Premiun);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
