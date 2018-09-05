using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using studentexpat.com.Models;

namespace studentexpat.com.Pages.admin.enrolments
{
    public class IndexModel : PageModel
    {
        private readonly studentexpat.com.Models.DB_A3A1FE_stexpContext _context;

        public IndexModel(studentexpat.com.Models.DB_A3A1FE_stexpContext context)
        {
            _context = context;
        }

        public IList<Enrollments> Enrollments { get;set; }

        public async Task OnGetAsync()
        {
            Enrollments = await _context.Enrollments
                .Include(e => e.Program)
                .Include(e => e.Student).ToListAsync();
        }
    }
}
