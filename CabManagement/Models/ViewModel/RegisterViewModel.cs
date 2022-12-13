﻿namespace CabManagement.Models.ViewModel
{

    public enum Roles
    {
        User,
        Driver
    }
    public class RegisterViewModel
    {




        [Required]
        [Display(Name = "Roles")]
        public Roles Roles { get; set; }



        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        
        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Required]
        [StringLength(25)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
