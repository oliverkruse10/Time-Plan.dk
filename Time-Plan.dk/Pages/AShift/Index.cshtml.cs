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

        public async Task OnGetAsync(string sortOrder)
        {
            IQueryable<Shift> shiftQuery = _context.Shift;

            // Applying sorting based on the sortOrder parameter
            switch (sortOrder)
            {
                case "starttime_asc":
                    shiftQuery = shiftQuery.OrderBy(s => s.StartTime);
                    break;
                case "starttime_desc":
                    shiftQuery = shiftQuery.OrderByDescending(s => s.StartTime);
                    break;
                case "endtime_asc":
                    shiftQuery = shiftQuery.OrderBy(s => s.EndTime);
                    break;
                case "endtime_desc":
                    shiftQuery = shiftQuery.OrderByDescending(s => s.EndTime);
                    break;
                default:
                    shiftQuery = shiftQuery.OrderBy(s => s.StartTime);
                    break;
            }

            Shift = await shiftQuery.ToListAsync();
        }

    }
}
