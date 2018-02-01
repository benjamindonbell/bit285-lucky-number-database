using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        // GET: LuckyNumber
        //public ActionResult Spin()
        //{

            //LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };

            //dbc.LuckyNumbers.Add(myLuck);
            //dbc.SaveChanges();

            //return View(myLuck);
           // return View( );
        //}

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
            int temp = 1; //(int)Session["currentID"]
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m => m.LuckyNumberID == temp ).First();
            //change the balance in the database
            //if (lucky.Balance>0)
            //{
            //lucky.Balance -= 1;
            //}
            if (databaseLuck.Balance > 0)
            {
                databaseLuck.Balance -= 1;

            }
            //update number in the database using the form submission value
            databaseLuck.Number = lucky.Number;
            dbc.SaveChanges();
            //return View(lucky);
            return View(databaseLuck);
        }
        [HttpPost]
        public ActionResult Index(LuckyNumber lucky)
        {
            dbc.LuckyNumbers.Add(lucky);
            dbc.SaveChanges();
            Session["currentID"] = lucky.LuckyNumberID;

            return RedirectToAction("Spin", lucky);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}