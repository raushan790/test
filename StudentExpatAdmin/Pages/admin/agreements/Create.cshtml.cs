using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.agreements
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
        ViewData["SchoolId"] = new SelectList(_context.Schools, "Id", "Id");
        ViewData["School"] = new SelectList(_context.Schools, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public Agreements Agreements { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Agreements.Add(Agreements);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}