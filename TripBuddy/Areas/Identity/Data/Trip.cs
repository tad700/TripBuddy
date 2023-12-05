using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripBuddy.Areas.Identity.Data
{
    
    public class Trip
    {

        [Key]
        public int TripsId { get; set; }

        [Required]
        public double Distance { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double Fuel_Needed { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double Price_For_Trip { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double Fuel_Price { get; set; }
        [ForeignKey("CarID")]
        public int? CarID { get; set; }
        public Car Car { get; set; }

       


    }
}
