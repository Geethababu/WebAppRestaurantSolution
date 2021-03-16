using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRestaurant.Models;

namespace WebAppRestaurant.Controllers
{
    public class AdminController : Controller
    {
        RestaurantDBEntities3 objRestaurantDBEntities = new RestaurantDBEntities3();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Register(Register reg)
        {
            /* if (Session["session"] == null)
               {
                   return RedirectToAction("login", "Admin");
               }*/
            if (ModelState.IsValid) { 

            try { 
                objRestaurantDBEntities.Registers.Add(reg);
                objRestaurantDBEntities.SaveChanges();
                return RedirectToAction("login","Admin");
            }
            catch(Exception)
            {
                //return View(e);
                
                return RedirectToAction("Register", "Admin");
            }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
 public ActionResult Login(Register ui)
        {

                Register u = objRestaurantDBEntities.Registers.Where(x => x.UserName == ui.UserName && x.Password == ui.Password).SingleOrDefault();
             
                Session["session"] = u.UserName;
                if (u.role == "Super Admin")
                {
                    //Session["uid"] = u.u_id;
                    return RedirectToAction("Home_SuperAdmin", "Admin");
                 // ViewBag.Message = "Login Successfully";
                }
            else
                {
                    return RedirectToAction("Index", "Home");
                    //ViewBag.Message = "Invalid Password or Email Id";
                }
            }
          
          
        [HttpGet]
        public ActionResult Home_SuperAdmin()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }


    }
}
