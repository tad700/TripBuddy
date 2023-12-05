using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripBuddy.Models;
using TripBuddy.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TripBuddy.Controllers
{
    [Authorize(Roles ="Admin")]

    public class CarController : Controller
    {
        private readonly TipBuddyDbContext? _context;
        public CarController(TipBuddyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IActionResult AddCar()
        {
            ViewBag.FuelTypeOptions = GetFuelTypeOptions();
            return View();
        }


        [HttpPost]
        public IActionResult AddCar(Car carModel)
        {
            if (ModelState.IsValid)
            {
                _context?.Cars.Add(carModel);
                _context?.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            ViewBag.FuelTypeOptions = GetFuelTypeOptions();
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(carModel);
            
        }
        private SelectList GetFuelTypeOptions()
        {
            return new SelectList(Enum.GetValues(typeof(FuelType)));
        }
        public IActionResult DeleteCar(string sortOrder)
        {
            // Retrieve the cars from the database
            var cars = _context.Cars.AsQueryable();

            // Apply sorting based on the sortOrder parameter
            switch (sortOrder)
            {
                case "Manufacturer_Desc":
                    cars = cars.OrderByDescending(c => c.Manufacturer);
                    break;
                case "Model":
                    cars = cars.OrderBy(c => c.Model);
                    break;
                case "Model_Desc":
                    cars = cars.OrderByDescending(c => c.Model);
                    break;
                // Add cases for other properties as needed
                default:
                    cars = cars.OrderBy(c => c.Manufacturer);
                    break;
            }

            // Pass the sorted cars to the view
            return View(cars.ToList());
        }

        [HttpPost]
        public IActionResult DeleteCar(List<int> selectedCars, string sortOrder)
        {
            if (selectedCars != null && selectedCars.Any())
            {
                foreach (var carId in selectedCars)
                {
                    var car = _context.Cars.Include(c => c.Trips).FirstOrDefault(c => c.CarsID == carId);

                    if (car != null)
                    {
                        // Remove associated trips
                        _context.Trips.RemoveRange(car.Trips);
                        _context.Cars.Remove(car);
                    }
                }

                // Save changes
                _context.SaveChanges();
            }

            // Redirect to the DeleteCar action with sorting parameter
            return RedirectToAction("DeleteCar", new { sortOrder });
        }
        public IActionResult UpdateCar()
        {
            var cars = _context.Cars.ToList();
            ViewBag.Cars = cars;    
            return View(cars);
        }

        [HttpPost]
        public IActionResult UpdateCar(Car updatedCar)
        {
            
            if (ModelState.IsValid)
            {
                var existingCar = _context.Cars.Find(updatedCar.CarsID);


                if (existingCar == null)
                {
                    return NotFound();
                }

                // Update properties with values from the form
                existingCar.Manufacturer = updatedCar.Manufacturer;
                existingCar.Model = updatedCar.Model;
                existingCar.YearOfProduction = updatedCar.YearOfProduction;
                existingCar.FuelConsumption = updatedCar.FuelConsumption;
                existingCar.FuelType = updatedCar.FuelType;
                existingCar.FuelTankCapacity = updatedCar.FuelTankCapacity;
                existingCar.HorsePower = updatedCar.HorsePower;

                // Update other properties similarly

                _context.SaveChanges();

                return RedirectToAction("UpdateCar");
            }

            // If ModelState is not valid, redisplay the form
            return View("UpdateCar", updatedCar);
        }





    }
}
