using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.students
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
            //ViewData["Nationalityid"] = new SelectList(_context.Nationality, "Id", "Id");
            ViewData["Nationality"] = new SelectList(_context.Nationality, "Id", "Nationality1");
            return Page();
        }

        [BindProperty]
        public Students Students { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Students);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}