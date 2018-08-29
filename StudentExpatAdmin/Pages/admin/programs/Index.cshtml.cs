using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using studentexpat.com.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace studentexpat.com.Pages.admin.programs
{
    public class IndexModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public IndexModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        public IList<Programs> Programs { get;set; }

        public async Task OnGetAsync()
        {
            Programs = await _context.Programs
                .Include(p => p.Language)
                .Include(p => p.ProgramType)
                .Include(p => p.School).ToListAsync();
            ViewData["Language"] = new SelectList(_context.Language, "Language1", "Language1");
            ViewData["ProgramType"] = new SelectList(_context.ProgramTypes, "ProgramType", "ProgramType");

        }
    }
}
