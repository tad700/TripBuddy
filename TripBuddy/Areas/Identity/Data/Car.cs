using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripBuddy.Areas.Identity.Data
{
    public enum FuelType
    {
        Gasoline,
        Diesel,
        LPG
    }
    public class Car
    {
        [Key]
        public int CarsID {  get; set; }
        [NotMapped] // Not mapped to the database
        public string DisplayText => $"{Manufacturer} {Model} {FuelType} {FuelConsumption}l/100km";

        [Required]
        public string Manufacturer { get; set; } = null!;
        [Required]
        public string Model { get; set; }=null!;
        [Range(1900,2023)]
        public int YearOfProduction { get; set; }
        [Range(0,100)]
        public int FuelConsumption { get; set; }
        [Required]
        public string FuelType { get; set; }
        public int FuelTankCapacity { get; set; }
        public int HorsePower { get; set; }
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
