using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.subcategories
{
    public class IndexModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public IndexModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        public IList<Subcategory> Subcategory { get;set; }

        public async Task OnGetAsync()
        {
            Subcategory = await _context.Subcategory
                .Include(s => s.Category)
                .Include(s => s.Language).ToListAsync();
        }
    }
}
