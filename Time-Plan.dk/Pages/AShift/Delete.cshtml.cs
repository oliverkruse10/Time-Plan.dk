using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.AShift
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public DeleteModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }
            var shift = await _context.Shift.FindAsync(id);

            if (shift != null)
            {
                Shift = shift;
                _context.Shift.Remove(Shift);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Oversigt");
        }
    }
}
