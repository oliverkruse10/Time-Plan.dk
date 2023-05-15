using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    public void OnGet()
    {
    }

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
