using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace AKQAService.Repository
{
    /// <summary>
    /// Number conversion function class, Implements INumberConverter interface
    /// </summary>
    public class NumberConverter : INumberConverter
    {
        private string[] onesnTeens = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private string[] tens = { "Zero", "One", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        /// <summary>
        /// Number functionality logic.
        /// </summary>
        /// <param name="amount">String amount to convert.</param>
        /// <param name="isEnd">check to append decimal string</param>
        /// <returns>converted amount in words</returns>
        public string amountToString(string amount, bool isEnd)
        {
            int number = Convert.ToInt32(Math.Truncate(Convert.ToDouble(amount)));
            StringBuilder sb = new StringBuilder();
            int len = number.ToString().Length;
            int pos = 0;

            switch (len)
            {
                case 1:
                    sb.Append(onesnTeens[number] + " ");
                    break;

                case 2:
                    if (number > 9 && number < 20)
                        sb.Append(onesnTeens[number] + " ");
                    else
                    {
                        pos = (int)char.GetNumericValue(number.ToString().ToCharArray()[0]);
                        sb.Append(tens[pos] + " ");

                        if (number % 10 != 0)
                        {
                            pos = (int)char.GetNumericValue(number.ToString().ToCharArray()[1]);
                            sb.Append(onesnTeens[pos].ToLower() + " ");
                        }
                    }
                    break;

                case 3:
                    pos = (int)char.GetNumericValue(number.ToString().ToCharArray()[0]);
                    sb.Append(onesnTeens[pos] + " ");
                    sb.Append("hundred ");
                    number = number % 100;
                    if (number != 0)
                        sb.Append("and " + amountToString(number.ToString(), false) + " ");
                    break;

                case 4:
                case 5:
                case 6:
                    pos = int.Parse(number.ToString().Substring(0, number.ToString().Length - 3));
                    sb.Append(amountToString(pos.ToString(), false) + " ");
                    sb.Append("thousand ");
                    pos = int.Parse(number.ToString().Substring(number.ToString().Length - 3));
                    number = number % 1000;
                    if (number != 0)
                        sb.Append(amountToString(pos.ToString(), false).ToLower() + " ");
                    break;

                case 7:
                case 8:
                case 9:
                    pos = int.Parse(number.ToString().Substring(0, number.ToString().Length - 6));
                    sb.Append(amountToString(pos.ToString(), false) + " ");
                    sb.Append("million ");
                    pos = int.Parse(number.ToString().Substring(number.ToString().Length - 6));
                    number = number % 1000;
                    if (number != 0)
                        sb.Append(amountToString(pos.ToString(), false).ToLower() + " ");
                    break;

                case 10:
                case 11:
                case 12:
                    pos = int.Parse(number.ToString().Substring(0, number.ToString().Length - 9));
                    sb.Append(amountToString(pos.ToString(), false) + " ");
                    sb.Append("billion ");
                    pos = int.Parse(number.ToString().Substring(number.ToString().Length - 9));
                    number = number % 1000;
                    if (number != 0)
                        sb.Append(amountToString(pos.ToString(), false).ToLower() + " ");
                    break;
            }

            if (isEnd)
                sb.Append(len ==1 ? "dollar" : "dollars ");

            if (amount.Contains('.'))
            {
                decimal value = Convert.ToDecimal(amount);
                int res = (int)((value - (int)value) * 100);
                sb.Append("and " + amountToString(res.ToString(), false) + " cents");
            }

            return sb.ToString().Trim().ToUpper();
        }
    }
}