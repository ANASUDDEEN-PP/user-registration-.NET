//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;                            //import "DisplayName" package
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="This feild is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This feild is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This feild is Required")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
