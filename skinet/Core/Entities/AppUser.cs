using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser // identity services
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Address? Address { get; set; }

}
