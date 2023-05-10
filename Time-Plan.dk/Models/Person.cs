

using System.ComponentModel.DataAnnotations;

public class Person
{
    
    public string Role { get; set; }

    
    [RegularExpression(@"^[a-zA-ZæøåÆØÅ\-]+( [a-zA-ZæøåÆØÅ\-]+)*$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(60, MinimumLength = 2)]
    [Required(ErrorMessage = "Fornavn er nødvendigt at udfylde")]
    public string FirstName { get; set; }

    
    [RegularExpression(@"^[a-zA-ZæøåÆØÅ]*$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(20, MinimumLength = 2)]
    [Required(ErrorMessage = "Efternavn er nødvendigt at udfylde")]
    public string LastName { get; set; }

    
    [RegularExpression(@"^[a-zA-Z0-9æøåÆØÅ.,\s-]+$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(60, MinimumLength = 2)]
    [Required(ErrorMessage = "Adresse er nødvendigt at udfylde")]
    public string Address { get; set; }

    
    [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [Required(ErrorMessage = "Telefon nummer er nødvendigt at udfylde")]
    public int PhoneNumber { get; set; }

   
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(60, MinimumLength = 2)]
    [Required(ErrorMessage = "Adresse er nødvendigt at udfylde")]
    public string Email { get; set; }


    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [Required(ErrorMessage = "CPR-nummer er nødvendigt at udfylde")]
    public int SocialSecurityNumber { get; set; }

    
    public bool DriversLicense { get; set; }

    public bool DriversLicenseWithTrailer { get; set; }
    public string? Password { get; set; }

    [Range(1, 99, ErrorMessage = "Venligst udfyld i korrekt format")]
    [Required(ErrorMessage = "Lønnummer er nødvendigt at udfylde")]
    public int LønNr { get; set; }

    public int ID { get; set; }

    public Person(string role, string firstName, string lastName, string address, int phoneNumber,
                  string email, int socialSecurityNumber, bool driversLicense, bool driversLicenseWithTrailer,
                  string password, int lønNr)
    {
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        SocialSecurityNumber = socialSecurityNumber;
        DriversLicense = driversLicense;
        DriversLicenseWithTrailer = driversLicenseWithTrailer;
        Password = password;
        LønNr = lønNr;
    }

    public void SetDefaultPassword()
    {
        this.Password = this.LønNr.ToString();
    }

    public Person()
    {
        
    }

    private static List<Person> employees = new List<Person>();

    

    public static void CreateEmployee(string firstName, string lastName, string address, int phoneNumber,
                                      string email, int socialSecurityNumber, bool driversLicense,
                                      bool driversLicenseWithTrailer, string password, int lønNr, string role)
    {
        //if (userRole != Role.Admin)
        //{
        //    Console.WriteLine("Error: Only users with the Admin role can create new employees.");
        //    return;
        //}

        Person newEmployee = new Person
        {
            Role = role,
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            PhoneNumber = phoneNumber,
            Email = email,
            SocialSecurityNumber = socialSecurityNumber,
            DriversLicense = driversLicense,
            DriversLicenseWithTrailer = driversLicenseWithTrailer,
            Password = password,
            LønNr = lønNr
        };

        employees.Add(newEmployee);
    }
}











