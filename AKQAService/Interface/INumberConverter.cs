using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQAService
{
    /// <summary>
    /// Interface: INumberConverter
    /// Contract to implement conversion functionality.
    /// </summary>
    public interface INumberConverter
    {
        string amountToString(string amount, bool isEnd);
    }
}
