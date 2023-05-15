using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Time_Plan.dk.Data;

public class LoginModel : PageModel
{

    private readonly Time_PlandkContext _context;

    public LoginModel(Time_PlandkContext context)
    {
        _context = context;
    }




    public void OnGet()
    {
    }

    //public async Task<IActionResult> OnPostAsync(string lønNr, string password)
    //{
    //    var person = await _context.Person.FirstOrDefaultAsync(p => p.LønNr == lønNr);

    //    if (person != null && person.Password == password)
    //    {
    //        // Successful login, redirect to the home page or another protected page
    //        return RedirectToPage("/Index");
    //    }
    //    else
    //    {
    //        // Invalid credentials, display an error message
    //        ModelState.AddModelError(string.Empty, "Invalid username or password.");
    //        return Page();
    //    }
    //}

    public IActionResult OnPost(string username, string password)
    {
        // Check the username and password here
        if (username == "admin" && password == "password")
        {
            return RedirectToPage("/Index");
        }
        else
        {
            return Page();
        }
    }




}
