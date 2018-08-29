using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.programs
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
        ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Id");
        ViewData["ProgramTypeId"] = new SelectList(_context.ProgramTypes, "Id", "Id");
        ViewData["Schoolid"] = new SelectList(_context.Schools, "Id", "Id");
            ViewData["School"] = new SelectList(_context.Schools, "Id", "Name");
            ViewData["ProgramType"] = new SelectList(_context.ProgramTypes, "Id", "ProgramType");
            ViewData["Language"] = new SelectList(_context.Language, "Id", "Language1");
            return Page();
        }

        [BindProperty]
        public Programs Programs { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programs.Add(Programs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}