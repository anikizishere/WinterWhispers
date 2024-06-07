using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WinterWhispers.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WinterWhispersUser class
public class WinterWhispersUser : IdentityUser
{
    [PersonalData] /*annotation, ska kunna kunna laddas ner om användaren frågar efter det. */
    public int Birthyear { get; set; }
    
    [PersonalData]
    public string FirstName { get; set; }
    
    [PersonalData]
    public string LastName { get; set; }
    
    [PersonalData]
    public string? ProfileImagePath { get; set; }

    //[PersonalData]
    //public string ProfileImage { get; set; } ?
}

