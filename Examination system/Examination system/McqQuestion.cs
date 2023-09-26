using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class McqQuestion : Question
    {
        public override string Header => "MCQ Question";
        public McqQuestion() 
        {
            Answers = new Answer[3];
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
            } while (!(int.TryParse(Console.ReadLine(), out mark) && (mark > 0)));


            Console.WriteLine("Choices Of Question");
            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = new Answer() { AnswerId = i + 1 };

                do
                {
                    Console.WriteLine($"Please Enter Choice number {i + 1}");
                    Answers[i].AnswerText = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(Answers[i].AnswerText));
            }

            int rightAnswerId;
            do
            {
                Console.WriteLine("Please Enter the right answer id ");
            } while (!(int.TryParse(Console.ReadLine(), out rightAnswerId) && (rightAnswerId is 1 or 2 or 3)));
            CorrectAnswer.AnswerId = rightAnswerId;
            CorrectAnswer.AnswerText = Answers[rightAnswerId - 1].AnswerText;

            Console.Clear();
        }
    }
}
