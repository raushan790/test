using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.agreements
{
    public class DeleteModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public DeleteModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agreements Agreements { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agreements = await _context.Agreements
                .Include(a => a.School).SingleOrDefaultAsync(m => m.Id == id);

            if (Agreements == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agreements = await _context.Agreements.FindAsync(id);

            if (Agreements != null)
            {
                _context.Agreements.Remove(Agreements);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
