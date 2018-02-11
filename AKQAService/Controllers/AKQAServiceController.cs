using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AKQAService.Repository;
using Unity;
using Unity.Injection;

namespace AKQAService.Controllers
{
    public class AKQAServiceController : ApiController
    {
        /// <summary>
        /// Dependency injection using Unity container
        /// implements injection of converter to controller class
        /// </summary>
        INumberConverter _numConvertor;
        public AKQAServiceController(INumberConverter numconvertor) 
        {
            this._numConvertor = numconvertor;
        }

        /// <summary>
        /// Web api resource
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>converted amount in words</returns>
        [HttpGet]
        [ActionName("GetAmountValue")]
        public string ConvertAmount(string amount)
        {
            return _numConvertor.amountToString(amount, true);
        }
    }
}
