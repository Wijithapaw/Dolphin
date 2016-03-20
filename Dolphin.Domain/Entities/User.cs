using Dolphin.Domain.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Domain.Entities
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser, IBaseEntity
    {
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public override string Email
        {
            get
            {
                return base.Email;
            }

            set
            {
                base.Email = value;
            }
        }

        //Need to add CreatedBy, CreatedDateUtc, LastUpdatedBy, LastUpdatedDate properties manually
        //due to unable to do multiple inheritance with BaseEntity
        public string CreatedBy { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDateUtc { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
