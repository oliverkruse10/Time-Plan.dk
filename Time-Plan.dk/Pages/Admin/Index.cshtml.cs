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
    public class IndexModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public IndexModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            IQueryable<Person> personQuery = _context.Person;

            // Applying sorting based on the sortOrder parameter
            switch (sortOrder)
            {
                case "firstname_desc":
                    personQuery = personQuery.OrderByDescending(p => p.FirstName);
                    break;
                case "lastname_asc":
                    personQuery = personQuery.OrderBy(p => p.LastName);
                    break;
                case "lastname_desc":
                    personQuery = personQuery.OrderByDescending(p => p.LastName);
                    break;
                case "firstname_asc":
                default:
                    personQuery = personQuery.OrderBy(p => p.FirstName);
                    break;
            }

            Person = await personQuery.ToListAsync();
        }

    }
}
