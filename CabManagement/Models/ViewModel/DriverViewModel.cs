namespace CabManagement.Models.ViewModel
{
    public class DriverViewModel
    {


        [StringLength(10)]
        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Car Number")]
        public string CarNumber { get; set; }

        
        [Required]
        [StringLength(10)]
        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }

       

    }
}
