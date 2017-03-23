using System;
using System.Web.Mvc;
using MenuApp.Services.QuestionService;
using MenuApp.Core.Entities;
using MenuApp.Services.BigDataService;
using MenuApp.Services.HomeService;


namespace MenuApp.Web.Controllers
{

    public class HomeController : Controller
    {
        private IBigDataService _bigDataService;
        private IQuestionService _questionService;
        private IHomeSerivce _homeSerivce;
        public HomeController(IQuestionService questionService, IBigDataService bigDataService, IHomeSerivce homeSerivce)
        {
            _homeSerivce = homeSerivce;
            _questionService = questionService;
            _bigDataService = bigDataService;
        }

        [HttpPost]
        [Route("Home/AddIp/{key}")]
        //[ConditionalAttribute("DEBUG")]
        public void AddIp(string key)
        {

           _bigDataService.IPinfoSave(key);

        }
        // GET: Home
        public ActionResult Index()
        {
            return View("Breakfast1");
            ////var timeOfDay = _homeSerivce.TimeOfDay();
            ////if (timeOfDay == "Breakfast")
            ////{
            ////    return RedirectToAction("Breakfast");
            ////}
            ////if (timeOfDay == "Lunch")
            ////{
            ////    return RedirectToAction("Lunch");
            ////}
            ////if (timeOfDay == "Coffe")
            ////{
            ////    return RedirectToAction("Coffee");
            ////}
            ////return RedirectToAction("Dinner");
        }

        public ViewResult Breakfast()
        {
            var rand = new Random();
            var random = rand.Next(0, 100);

            if (random < 33)
            {
                return View("Breakfast1");
            }

            if (random < 66)
            {
                return View("Breakfast2");
            }
            return View("Breakfast3");

        }
        public ViewResult Coffee()
        {
            var rand = new Random();
            var random = rand.Next(0, 100);

            if (random < 33)
            {
                return View("Coffee1");
            }

            if (random < 66)
            {
                return View("Coffee2");
            }
            return View("Coffee3");

        }
        public ViewResult Lunch()
        {
            var rand = new Random();
            var random = rand.Next(0, 100);

            if (random < 33)
            {
                return View("Lunch1");
            }

            if (random < 66)
            {
                return View("Lunch2");
            }
            return View("Lunch3");

        }
        public ViewResult Dinner()
        {
            var rand = new Random();
            var random = rand.Next(0, 100);

            if (random < 33)
            {
                return View("Dinner1");
            }

            if (random < 66)
            {
                return View("Dinner2");
            }
            return View("Dinner3");

        }


        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.IsActive = true;
                _questionService.Contact(contact);
            }
            return View();
        }
        public ActionResult MenuShow(string foodCateogry)
        {
            return View(_homeSerivce.FoodCateogry(foodCateogry));
        }
    }
}