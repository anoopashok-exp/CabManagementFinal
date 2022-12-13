namespace CabManagement.Models
{
    public enum From
        {
            Phase1,
            Phase2
        }

        public enum To
        {
            
            Palarivattom,
            Edappally,
            VytilaHub,
            EkmRailway,
            CochinAirport
            
        }
        public class Booking
        {
            public int Id { get; set; }

            public From PickUp { get; set; }

            public To Destination { get; set; }

            public DateTime Time { get; set; }

        }
    }

