using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cimob.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Answer { get; set; } //A New Email Address field
        
        

        [ForeignKey("Question")]
        public int QuestionID { get; set; } //A New Email Address field
        public virtual Question Question{ get; set; }
        [ForeignKey("ProfileType")]
        public int ProfileTypeID { get; set; } //A New Email Address field
        public virtual ProfileType ProfileType { get; set; }

        public string Name { get; set; }

        public byte[] AvatarImage { get; set; }

    }
}
