using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppRestaurant.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
       // [Required(ErrorMessage ="Enter name")]
        public string CustomerName { get; set; }
    }
}