using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.AShift
{
    public class CreateModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public CreateModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shift Shift { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Shift == null || Shift == null)
            {
                return Page();
            }

            _context.Shift.Add(Shift);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
