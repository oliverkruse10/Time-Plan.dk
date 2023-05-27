using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public DetailsModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

      public Person Person { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            else 
            {
                Person = person;
            }
            return Page();
        }

        public IActionResult OnPostResetPassword(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.ID == id);
            if (person != null)
            {
                person.SetDefaultPassword();

                _context.SaveChanges();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
