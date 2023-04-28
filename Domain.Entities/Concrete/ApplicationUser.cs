using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Cinemagnesia.Domain.Domain.Entities.Concrete;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [MaxLength(40)]
    public string FirstName { get; set; }

    [MaxLength(40)]
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime AccountCreationDate { get; set; }
    public string ProfilePicture { get; set; }
    public ICollection<Movie> RatedMovies { get; set; }
    public ICollection<MovieComment> MovieComments { get; set; }
    public string? CompanyId { get; set; }
    public Company? Company { get; set; }
    public ICollection<UserRestriction> Restrictions { get; set; }

}

