using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppRestaurant.ViewModel
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Enter Item name")]
        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }

    }
}