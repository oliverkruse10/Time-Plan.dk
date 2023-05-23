using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.AShift
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public EditModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
            GenerateEmployeeDict();
        }

        [BindProperty]
        public Shift Shift { get; set; } = default!;


        public Dictionary<int, string> EmployeeDict { get; set; } = new Dictionary<int, string>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shift == null)
            {
                return NotFound();
            }

            var shift =  await _context.Shift.FirstOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }
            Shift = shift;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            _context.Attach(Shift).State = EntityState.Modified;

            if (Shift.EndTime <= Shift.StartTime)
            {
                ModelState.AddModelError("erroneoustime", "Sluttid kan ikke være før starttid");
                return Page();
            }

            if (Shift.MedarbejderLønNr != 0)
            {
                if (!EmployeeAavailable())
                {
                    return Page();
                }
            }
            if (Shift.MedarbejderLønNr == 0)
            {
                Shift.MedarbejderLønNr = null;
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftExists(Shift.ShiftId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Oversigt");
        }

        private bool ShiftExists(int id)
        {
          return (_context.Shift?.Any(e => e.ShiftId == id)).GetValueOrDefault();
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
        public bool EmployeeAavailable()
        {
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
    }
}
