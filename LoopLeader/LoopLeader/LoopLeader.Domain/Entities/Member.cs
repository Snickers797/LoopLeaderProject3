using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopLeader.Domain.Entities
{
    public class Member
    {
        [HiddenInput(DisplayValue = false)]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Please enter a Login Name")]
        [StringLength(25)]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an Email Address")]
        public string Email { get; set; }
    }
}
