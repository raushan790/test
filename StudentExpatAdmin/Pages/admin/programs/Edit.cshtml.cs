using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.programs
{
    public class EditModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public EditModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programs Programs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programs = await _context.Programs
                .Include(p => p.Language)
                .Include(p => p.ProgramType)
                .Include(p => p.School).SingleOrDefaultAsync(m => m.Id == id);

            if (Programs == null)
            {
                return NotFound();
            }
           ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Id");
           ViewData["ProgramTypeId"] = new SelectList(_context.ProgramTypes, "Id", "Id");
           ViewData["Schoolid"] = new SelectList(_context.Schools, "Id", "Id");
           ViewData["School"] = new SelectList(_context.Schools, "Id", "Name");
           ViewData["ProgramType"] = new SelectList(_context.ProgramTypes, "Id", "ProgramType");
            ViewData["Language"] = new SelectList(_context.Language, "Id", "Language1");
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Programs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramsExists(Programs.Id))
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

        private bool ProgramsExists(int id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }
    }
}
