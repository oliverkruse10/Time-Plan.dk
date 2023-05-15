using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

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
        public DateTime date { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? dato { get; set; }





        public string EmployeeName(int? medarbejderlønnr)
        {

            return _context.Person.FirstOrDefault(e => e.LønNr == medarbejderlønnr)?.FullName ?? "Ingen medarbejder";
        }
        public async Task<IActionResult> GetTidFremAsync(string dato)
        {
            Shift = await _context.Shift.ToListAsync();
            Person = await _context.Person.ToListAsync();
            date = Service.Helper.StringToDate(dato);
            return Page();
        }


        public async Task<IActionResult> GetTidTilbageAsync(string dato)
        {
            Shift = await _context.Shift.ToListAsync();
            Person = await _context.Person.ToListAsync();
            date = Service.Helper.StringToDate(dato);
            return Page();
        }

        public async Task<IActionResult> OnGetAsync(string? dato)
        {
            Shift = await _context.Shift.ToListAsync();
            Person = await _context.Person.ToListAsync();
            if (dato != null)
            {
                date = Service.Helper.StringToDate(dato);
            }
            if (date == default)
            {
                date = DateTime.Now;
            }
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

        public List<Shift> GetShiftIDs(DateTime tid, int? medarbejdernr)
        {
            if (_context.Shift.FirstOrDefault(e => e.MedarbejderLønNr == medarbejdernr && ( e.StartTime.Date == tid.Date))!= null)
            {
                List<Shift> shiftlist = new List<Shift>();
                foreach (Shift shift in Shift)
                {
                    shiftlist = Shift.Where(e => e.MedarbejderLønNr == medarbejdernr && (e.StartTime.Date == tid.Date)).ToList();
                }
                return shiftlist;

            }
            return null;


        }
    }
}
