using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;

namespace WebAppRestaurant.Repositories
{
    public class ItemRepository
    {
        private RestaurantDBEntities3 objRestaurantDBEntities;
        public ItemRepository()
        {
            objRestaurantDBEntities = new RestaurantDBEntities3();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRestaurantDBEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = false
                                  }).ToList();
            return objSelectListItems;
        }
    }
}