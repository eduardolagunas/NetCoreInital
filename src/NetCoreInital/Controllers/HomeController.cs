using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreInital.Entities;
using NetCoreInital.Services;
using NetCoreInital.ViewModels;

namespace NetCoreInital.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel(); 
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var data = _restaurantData.Get(id);

            if (data == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(data);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _restaurantData.Get(id);

            if (data == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel restaurant)
        {
            var newRestaurant = _restaurantData.Get(id);
            newRestaurant.Name = restaurant.Name;
            newRestaurant.Cuisine = restaurant.Cuisine;

            _restaurantData.Commit();

            return RedirectToAction("Details", new { id = newRestaurant.Id });
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel restaurant)
        {
            var newRestaurant = new Restaurant();
            newRestaurant.Name = restaurant.Name;
            newRestaurant.Cuisine = restaurant.Cuisine;


            _restaurantData.Add(newRestaurant);

            _restaurantData.Commit();

            return RedirectToAction("Details", new { id = newRestaurant.Id });
        }
    }
}
