using System;
using System.Collections.Generic;
using System.Web.Mvc;
using quizClash2017.Models;

namespace quizClash2017.Controllers
{
    public class HomeController : Controller
    {
        static List<Questions> questionsList = defaultQuestions();      //This will load the default questions
        static int score = 0;
        static int numberOfQuestions = 5;
        static List<int> randomList = UniqueRandomNumber(numberOfQuestions);    //This will give a list of unique numbers, lenght of list will be equal to total number of questions
        static int index = 0;


        /// <summary>
        /// Following method is for loading first view of site
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {            
            return View();
        }


        /// <summary>
        /// Following method view the first question and its option under Quiz Page
        /// </summary>
        /// <returns>
        /// returns the view containing question and its options
        /// </returns>
        [HttpGet]
        public ActionResult Quiz()
        {
            populateViewBeg(ViewBag);
            return View(ViewBag.options);
        }

        [HttpGet]
        public ActionResult Score()
        {
            ViewBag.score = score;
            score = 0;
            index = 0;
            return View();
        }


        /// <summary>
        /// Followig method is called when any option is selected from form
        /// it validates the answer
        /// </summary>
        /// <param name="button"> selected answer</param>
        /// <param name="answer"> actual answer</param>
        /// <returns>score view if its last question else same view</returns>
        [HttpPost]
        public ActionResult Quiz(string button, string answer)
        {
            CheckAnswer(button, answer);

            if ((index) == numberOfQuestions)
            {
                return RedirectToAction("Score", "Home");
            }

            populateViewBeg(ViewBag);
            
            return View("Quiz", ViewBag.options);
        }


        /// <summary>
        /// Following method just populate the received viewbag with question(which is unique)
        /// </summary>
        /// <param name="viewBag">Viewbag received from page</param>
        private void populateViewBeg(dynamic viewBag)
        {
            Questions question = getUniqueQuestion();
            ViewBag.question = question.questionText;
            ViewBag.options = question.options; ;
            ViewBag.answer = question.answer;
        }


        /// <summary>
        /// Following method just setting some default questions as for now we have hard coded them till we dont have DB
        /// </summary>
        /// <returns> List of questions </returns>
        static public List<Questions> defaultQuestions()
        {
            List<Questions> list = new List<Questions> { };
            Questions question;
            question = new Questions(0, "Name of the screen that recognizes touch input is?", new string[] { "Recog screen", "Point Screen", "Touch Screen", "Android Screen" }, "Point Screen");
            list.Add(question);
            question = new Questions(1, "Which is capital city of Pakistan?", new string[] { "Lahore", "Karachi", "Islamabad", "Pishawar" }, "Islamabad");
            list.Add(question);
            question = new Questions(2, "Which of the following landforms is different from other three on the basis of the mode of origin?", new string[] { "Nappes", "Anticline", "Fold", "Rift Valley" }, "Rift Valley");
            list.Add(question);
            question = new Questions(3, "Two places on the same meridian must have the same—", new string[] { "Latitude", "Solar time", "Length of summer", "Length of winter" }, "Solar time");
            list.Add(question);
            question = new Questions(4, "Which of the following latitudes is the longest?", new string[] { "0°", "66°N", "80°N", "23°N" }, "0°");
            list.Add(question);

            return list;
        }


        /// <summary>
        /// Following method will use randomList and according to index gets its value
        /// then it will get the question which number is equal to the random value got by the randomList
        /// </summary>
        /// <returns>Unique question every time</returns>
        private Questions getUniqueQuestion()
        {
            int val = randomList[index];
            index++;
            foreach (Questions item in questionsList)
            {
                if (item.questionNo == val)
                    return item;
            }
            return questionsList[0];
        }


        /// <summary>
        /// Following method will give a list containing random unique numbers to each index. the size of this list will be the same as range provided as parameter
        /// </summary>
        /// <param name="range">its the range from 0, by which you want random numbers list </param>
        /// <returns>List of unique numbers</returns>
        static private List<int> UniqueRandomNumber(int range)
        {
            List<int> randomList = new List<int>();
            Random a = new Random();
            int MyNumber = 0;
            while (!randomList.Count.Equals(range))
            {
                MyNumber = a.Next(0, range);
                if (!randomList.Contains(MyNumber))
                    randomList.Add(MyNumber);
            }
            return randomList;
        }


        /// <summary>
        /// Following method just compares the provided answer with actual answer and increment one in score
        /// </summary>
        /// <param name="option">selected answer</param>
        /// <param name="answer">actual answer</param>
        private void CheckAnswer(string option, string answer)
        {
            if (option.Equals(answer))
            {
                score++;
            }          
        }
    }
}