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
    public class DetailsModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public DetailsModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

      public Shift Shift { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift.FirstOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }
            else 
            {
                Shift = shift;
            }
            return Page();
        }
       
        
    }
}
