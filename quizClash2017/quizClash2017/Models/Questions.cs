

namespace quizClash2017.Models
{
    public class Questions
    {
        public int questionNo { get; set; }         // number of the question
        public string questionText { get; set; }    // text of question
        public string[] options { get; set; }       // available options of the specific question
        public string answer { get; set; }          // correct answer of the specific question

        // Constructor of this class with all of its properties
        public Questions(int quesNo, string quesTxt, string[] optns, string ans)
        {
            questionNo = quesNo;
            questionText = quesTxt;
            options = optns;
            answer = ans;
        }
        
        //Default constructor
        public Questions()
        {

        }
    }
}