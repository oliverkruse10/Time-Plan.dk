using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using Time_Plan.dk.Data;

public class LoginModel : PageModel
{

    private readonly Time_PlandkContext _context;

    public LoginModel(Time_PlandkContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int LønNr { get; set; }

    [BindProperty]
    public string Password { get; set; }




    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(int lønNr, string password)
    {
        if (_context.Person.FirstOrDefault(e => e.LønNr == lønNr && e.Password == password) != null)
        {
            ViewData["Message"] = "There is a match";
            return Page();
        }
        else
        {
            ViewData["Message"] = "No match in the database";
            return Page();
        }
    }


    //    if (person != null && person.Password == password)
    //{

    //    return RedirectToPage("/Index");
    //}
    //else
    //{

    //    ModelState.AddModelError(string.Empty, "Invalid username or password.");
    //    return Page();
    //}
}

//public IActionResult OnPost(string username, string password)
//    {
//        // Check the username and password here
//        if (username == "admin" && password == "password")
//        {
//            return RedirectToPage("/Index");
//        }
//        else
//        {
//            return Page();
//        }
//    }





