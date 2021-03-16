using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;
using WebAppRestaurant.Repositories;
using WebAppRestaurant.ViewModel;

namespace WebAppRestaurant.Controllers
{
    public class HomeController : Controller
    {
         RestaurantDBEntities3 objRestaurantDBEntities = new RestaurantDBEntities3();
       /* public HomeController()
        {
            objRestaurantDBEntities
        }*/
        public ActionResult Index()
        {

            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                        (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRestaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json("Your Order has been Successfully Placed", JsonRequestBehavior.AllowGet);
        }

        



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}