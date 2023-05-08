﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.Admin
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
        public Person Person { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //Person.Password = Person.LønNr.ToString();



            if (!ModelState.IsValid || _context.Person == null || Person == null)
            {
                return Page();
            }
            
            _context.Person.Add(Person);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
