using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Time_Plan.dk.Pages.AShift
{
    public class OversigtModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public OversigtModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

        public IList<Shift> Shift { get; set; } = default!;
        public IList<Person> Person { get; set; } = default!;

        
        [BindProperty(SupportsGet = true)]
        public DateTime date { get; set; } = DateTime.Now;

        public DateTime datePH { get; set; }


        public string EmployeeName(int? medarbejderlønnr)
        {
            if (medarbejderlønnr == null)
            {
                return "Ingen medarbejder";
            }
            return _context.Person.FirstOrDefault(e => e.LønNr == medarbejderlønnr)?.FirstName + " " + _context.Person.FirstOrDefault(e => e.LønNr == medarbejderlønnr)?.LastName;
        }
        
        public async Task<IActionResult> OnGetTidTilbage(DateTime dato)
        {
            Shift = await _context.Shift.ToListAsync();
            Person = await _context.Person.ToListAsync();
            datePH = dato - TimeSpan.FromDays(7);
            date = datePH;
            return Page();
        }
        public async Task<IActionResult> OnTidFrem(DateTime dato)
        {
            Shift = await _context.Shift.ToListAsync();
            Person = await _context.Person.ToListAsync();
            datePH = dato.AddDays(7);
            date = datePH;
            return Page();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Shift = await _context.Shift.ToListAsync();
            Person = await _context.Person.ToListAsync();
            
            return Page();
        }

        public bool Vagt(int? medarbejdernr, DateTime kontroltid)
        {
            if (_context.Shift.FirstOrDefault(e => e.MedarbejderLønNr == medarbejdernr && e.StartTime.Date == kontroltid.Date) != null)
            {
                return true;
            }
            return false;
        }
        
        public int? GetShiftID(DateTime tid, int? medarbejdernr)
        {

            if (_context.Shift.FirstOrDefault(e => e.MedarbejderLønNr == medarbejdernr && e.StartTime.Date == tid.Date) != null)
            {
                Shift? medarbejdervagt = (Shift)_context.Shift.FirstOrDefault(e => e.MedarbejderLønNr == medarbejdernr && e.StartTime.Date == tid.Date);
                return medarbejdervagt.ShiftId;
            }
            return null;
        }
        
        

    }
}
