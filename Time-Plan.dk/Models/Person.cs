﻿

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Person
{
    [Display(Name = "Rolle")]
    public string Role { get; set; }

    
    [RegularExpression(@"^[a-zA-ZæøåÆØÅ\-]+( [a-zA-ZæøåÆØÅ\-]+)*$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(60, MinimumLength = 2)]
    [Required(ErrorMessage = "Fornavn er nødvendigt at udfylde")]
    [Display(Name = "Fornavn")]
    public string FirstName { get; set; }

    
    [RegularExpression(@"^[a-zA-ZæøåÆØÅ]*$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(20, MinimumLength = 2)]
    [Required(ErrorMessage = "Efternavn er nødvendigt at udfylde")]
    [Display(Name = "Efternavn")]
    public string LastName { get; set; }

    
    [RegularExpression(@"^[a-zA-Z0-9æøåÆØÅ.,\s-]+$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(60, MinimumLength = 2)]
    [Required(ErrorMessage = "Adresse er nødvendigt at udfylde")]
    [Display(Name = "Adresse")]
    public string Address { get; set; }

    
    [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [Required(ErrorMessage = "Telefon nummer er nødvendigt at udfylde")]
    [Display(Name = "Telefon nummer")]
    public int PhoneNumber { get; set; }

   
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [StringLength(60, MinimumLength = 2)]
    [Required(ErrorMessage = "Adresse er nødvendigt at udfylde")]
  
    public string Email { get; set; }


    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Venligst udfyld i korrekt format")]
    [Required(ErrorMessage = "CPR-nummer er nødvendigt at udfylde")]
    [Display(Name = "CPR-nummer")]
    public string SocialSecurityNumber { get; set; }


    [Display(Name = "Kørekort")]
    public bool DriversLicense { get; set; }
    [Display(Name = "Kørekort med trailer")]
    public bool DriversLicenseWithTrailer { get; set; }
    
    public string? Password { get; set; }

    [Range(1, 99, ErrorMessage = "Venligst udfyld i korrekt format")]
    [Required(ErrorMessage = "Lønnummer er nødvendigt at udfylde")]
    public int LønNr { get; set; }

    public int ID { get; set; }

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public Person(string role, string firstName, string lastName, string address, int phoneNumber,
                  string email, string socialSecurityNumber, bool driversLicense, bool driversLicenseWithTrailer,
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

   
}











