using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.enrolments
{
    public class EditModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public EditModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollments Enrollments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollments = await _context.Enrollments
                .Include(e => e.Program)
                .Include(e => e.Student).SingleOrDefaultAsync(m => m.Id == id);

            if (Enrollments == null)
            {
                return NotFound();
            }
            ViewData["ProgramId"] = new SelectList(_context.Programs, "Id", "Id");
            ViewData["Program"] = new SelectList(_context.Programs, "Id", "Name");
            ViewData["Student"] = new SelectList(_context.Students, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enrollments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentsExists(Enrollments.Id))
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

        private bool EnrollmentsExists(int id)
        {
            return _context.Enrollments.Any(e => e.Id == id);
        }
    }
}
