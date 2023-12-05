

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripBuddy.Areas.Identity.Data;

namespace TripBuddy.Controllers
{
    public class TripController : Controller
    {
        private readonly TipBuddyDbContext _context;
        private readonly UserManager<TripBuddyUser> _userManager;
        protected double CalculateFuelNeeded(double distance, double fuelConsumption)
        {
            return (distance / 100) * fuelConsumption;
        }

        protected double CalculatePriceForTrip(double fuelNeeded, double fuelPrice)
        {
            return fuelNeeded * fuelPrice;
        }


        public TripController(TipBuddyDbContext context, UserManager<TripBuddyUser> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IActionResult TripIndex()
        {
            var carList = _context.Cars.ToList();

            ViewBag.carList = new SelectList(carList, "CarsID", "DisplayText");
            return View();
        }

        [HttpPost]
        public IActionResult TripIndex(int CarID, double distance, double Fuel_Price, int fuelConsumption=11)
        {
            Car car = new Car();
            var carList = _context.Cars.ToList();
            ViewBag.CarList = new SelectList(carList, "CarsID", "DisplayText");
            var selectedCar = _context.Cars.Find(CarID);

            double fuelNeeded = CalculateFuelNeeded(distance,selectedCar.FuelConsumption);
            double priceForTrip = CalculatePriceForTrip(fuelNeeded, Fuel_Price);
            ViewBag.fuelNeeded = fuelNeeded;
            ViewBag.priceForTrip = priceForTrip;

            Trip trip = new Trip
            {
                Distance = distance,
                Fuel_Price = Fuel_Price,
                Fuel_Needed = fuelNeeded,
                Price_For_Trip = priceForTrip,
                Car = selectedCar

                
            };
            if(selectedCar != null)
            {
                _context.Add(trip);
                _context.SaveChanges();
            }
          
            // Pass the Trip instance to the view
            return View(trip);
        }


    }



}