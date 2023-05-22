using Microsoft.Build.Framework;

namespace Time_Plan.dk.Models
{
    public class LogIn
    {
        [Required]
        public int LønNr { get; set; }

        [Required]
        public string? Password { get; set; }



    }
}
