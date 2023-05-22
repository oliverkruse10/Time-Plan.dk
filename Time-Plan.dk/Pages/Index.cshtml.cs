using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using System.Security.Cryptography;
using Time_Plan.dk.Data;

public class IndexModel : PageModel
{

    private readonly Time_PlandkContext _context;

    public IndexModel(Time_PlandkContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int LønNr { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public int Role { get; set; }


    public async Task<IActionResult> OnGet()
    {
        if (User.Identity.IsAuthenticated)
            {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/LogOut/LogOutPage");
            }


        return Page();
      
    }





    public async Task<IActionResult> OnPostAsync()
    {
        var user = _context.Person.FirstOrDefault(e => e.LønNr == LønNr && e.Password == Password);

        if (user != null)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.LønNr.ToString())
        };

            if (user.Role == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToPage("/AShift/Oversigt");
        }
        else
        {
            ViewData["Message"] = "Forkert løn nummer, password eller rolle";
            return Page();
        }
    }






}