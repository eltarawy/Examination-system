using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class TrueOrFalseQuestion : Question
    {
        public override string Header => $"True | false question";
        public TrueOrFalseQuestion()
        {
            Answers = new Answer[2];
            Answers[0] = new Answer(1, "True");
            Answers[1] = new Answer(2, "False");
        }



        public override void AddAddQestion()
        {
            Console.WriteLine(Header);
            do
            {
                Console.WriteLine("Please Enter Question Body");
                Body = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(Body));

            int mark;
            do
            {
                Console.WriteLine("Please Enter Question Mark");
            } while (!(int.TryParse(Console.ReadLine(), out mark)&&(mark > 0)));

            Mark = mark;

            int correctAnswer;
            do
            {
                Console.WriteLine("Please Enter the right answer id (1 for true | 2 for false)");
            } while (!(int.TryParse(Console.ReadLine(), out correctAnswer) && (correctAnswer is 1 or 2)));

            CorrectAnswer.AnswerId = correctAnswer;
            CorrectAnswer.AnswerText = Answers[correctAnswer - 1].AnswerText;
            Console.Clear();
        }
    }
}
