using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.AShift
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public CreateModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
            GenerateEmployeeDict();
        }

        public IActionResult OnGet()
        {
            
            return Page();
        }
        
        public Dictionary<int, string> EmployeeDict { get; set; } = new Dictionary<int, string>();


        [BindProperty]
        public Shift Shift { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Shift == null || Shift == null)
            {
                return Page();
            }

            if (Shift.EndTime <= Shift.StartTime)
            {
                ModelState.AddModelError("erroneoustime", "Sluttid kan ikke være før starttid");
                return Page();
            }

            if (!EmployeeAavailable())
                {
                    return Page();
                }
            
            if (Shift.MedarbejderLønNr == 0)
            {
                Shift.MedarbejderLønNr = null;
            }


            _context.Shift.Add(Shift);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Oversigt");
        }

        public bool EmployeeAavailable()
        {
            if (Shift.MedarbejderLønNr == 0)
            {
                return true;
            }
            foreach (var shift in _context.Shift)
            {
                if (shift.MedarbejderLønNr == Shift.MedarbejderLønNr)
                {
                    if (shift.StartTime < Shift.StartTime && shift.EndTime > Shift.StartTime)
                    {
                        ModelState.AddModelError("Planlægningsfejl", $"Medarbejderen er optaget på en vagt fra:{shift.StartTime} til {shift.EndTime} med opgaverne {shift.TypeofJob}");
                        return false;
                    }
                    if (shift.StartTime < Shift.EndTime && shift.EndTime > Shift.EndTime)
                    {
                        ModelState.AddModelError("Planlægningsfejl", $"Medarbejderen er optaget på en vagt fra:{shift.StartTime} til {shift.EndTime} med opgaverne {shift.TypeofJob}");
                        return false;
                    }
                }
            }
            
            return true;
        }

        public void GenerateEmployeeDict()
        {
            EmployeeDict.Clear();
            EmployeeDict.Add(0, "Ingen medarbejder");
            foreach (var employee in _context.Person)
            {
                EmployeeDict.Add(employee.LønNr, employee.LønNr + ": " + employee.FullName);
                EmployeeDict = EmployeeDict.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);
            }
        }
    }
}
