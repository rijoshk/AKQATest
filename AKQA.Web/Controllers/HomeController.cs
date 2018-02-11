using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AKQA.Web.Models;
using AKQA.Web.WebService;
using System.Threading.Tasks;
using System.Net.Http;

namespace AKQA.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Override “OnException” method, will display error page.
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };
        }

        public HomeController() { }

        /// <summary>
        /// Dependency injection
        /// implements injection of web service to controller class
        /// </summary>
        IApiService _service;
        public HomeController(IApiService service) 
        {
            this._service = service;
        }

        /// <summary>
        /// Intial load: will populate with empty model.
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            var userData = new UserData();
            return View(userData);
        }

        /// <summary>
        /// Index page posted from client with model information
        /// </summary>
        /// <param name="collection">contains form data</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            UserData data = new UserData();
            data.Name = collection.Get("Name");
            data.Amount = Convert.ToDecimal(collection.Get("Amount"));
            if (ModelState.IsValid)
            {
                _service = new ApiService();
                var amount = _service.GetAPIData(collection.Get("Amount").ToString());
                data.AmountInWords = amount;
                return View(data);
            }
            return View(data);
        }
    }
}
