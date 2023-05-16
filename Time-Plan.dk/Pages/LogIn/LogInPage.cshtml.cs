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
    public int L�nNr { get; set; }

    [BindProperty]
    public string Password { get; set; }




    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (_context.Person.FirstOrDefault(e => e.L�nNr == L�nNr && e.Password == Password) != null)
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





