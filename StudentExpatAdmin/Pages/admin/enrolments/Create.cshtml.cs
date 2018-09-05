using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.enrolments
{
    public class CreateModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public CreateModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProgramId"] = new SelectList(_context.Programs, "Id", "Id");
        ViewData["Program"] = new SelectList(_context.Programs, "Id", "Name");
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
        ViewData["Student"] = new SelectList(_context.Enrollments, "Id", "name");
            return Page();
        }

        [BindProperty]
        public Enrollments Enrollments { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollments.Add(Enrollments);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}