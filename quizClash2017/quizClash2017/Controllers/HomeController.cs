using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace quizClash2017.Controllers
{
    public class HomeController : Controller
    {
        Dictionary<string, string[]> data;

       
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {
            myData();
            Random rnd = new Random();
            int val = rnd.Next(4); //should be unique random number 
            ViewBag.question = data.ElementAt(val).Key;
            ViewBag.options = data.ElementAt(val).Value;
            return View(ViewBag.options);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Questions(string button)
        {
            System.Diagnostics.Debug.WriteLine(button);
            myData();
            Random rnd = new Random();
            int val= rnd.Next(4); //should be unique random number 
            ViewBag.question = data.ElementAt(val).Key;
            ViewBag.options = data.ElementAt(val).Value;
            return View("About", ViewBag.options);
        }
        
        public void myData()
        {
            data = new Dictionary<string, string[]>();
            data.Add("Q.Name of the screen that recognizes touch input is :", new string[] { "Recog screen", "Point Screen", "Touch Screen", "Android Screen" });
            data.Add("Q1. This is Test Question1?", new string[] { "ONE1", "TWO1", "ONE0", "TWO0" });
            data.Add("Q2. This is Test Question2?", new string[] { "ONE2", "TWO2" , "ONE0", "TWO0" });
            data.Add("Q3. This is Test Question3?", new string[] { "ONE3", "TWO3", "ONE0", "TWO0" });
        }
        public int UniqueRandomNumber()
        {
            // return unique random number

            return 0;
        }
        public bool CorrectAnswer()
        {
            //return corrct answer
            return true;
        }
    }
}