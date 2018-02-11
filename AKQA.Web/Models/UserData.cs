using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AKQA.Web.Models
{
    public class UserData
    {
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter amount.")]
        [DataType(DataType.Currency)]
        [Range(1, 1000000000, ErrorMessage = "Price must be greater than 0.00 and less than 1 billion.")]
        public decimal Amount { get; set; }

        public string AmountInWords { get; set; }
    }
}