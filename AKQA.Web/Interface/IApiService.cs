using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Web.WebService
{
    /// <summary>
    /// api Interface to consumed by web service.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Interface function to be implemented by service
        /// </summary>
        /// <param name="param">holds Amount value</param>
        /// <returns>Converted amount in words</returns>
        string GetAPIData(string param);
    }
}

