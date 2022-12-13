namespace CabManagement.Models.ViewModel
{
    
    public class BookingViewModel
    {
       

        [Required]
    
        [Display(Name = "PickUp Location")]
        public From PickUp { get; set; }

        [Required]
      
        [Display(Name = "Destination")]
        public To Destination { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public IEnumerable<BookingViewModel>? Bookings { get; set; }

    }
}
