

public class Person
{
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    private int SocialSecurityNumber { get; set; }
    public bool DriversLicense { get; set; }
    public bool DriversLicenseWithTrailer { get; set; }
    private string Password { get; set; }
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











