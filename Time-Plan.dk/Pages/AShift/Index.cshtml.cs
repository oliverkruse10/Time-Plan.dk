using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.AShift
{
    public class IndexModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public IndexModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

        public IList<Shift> Shift { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Shift != null)
            {
                Shift = await _context.Shift.ToListAsync();
            }
        }
    }
}
