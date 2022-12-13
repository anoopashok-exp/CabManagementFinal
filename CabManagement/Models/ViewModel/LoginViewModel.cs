namespace CabManagement.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Enter your Registered Email Id")]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

}
