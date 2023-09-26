using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new McqQuestion[NumberOfQuestions];
            for (int i = 0; i < Questions?.Length; i++)
            {
                Questions[i] = new McqQuestion();
                Questions[i].AddAddQestion();
            }

            Console.Clear();
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine(question);

                for (int i = 0; i < NumberOfQuestions; i++)
                    Console.WriteLine(question.Answers[i]);
                Console.WriteLine("-------------------------------");
                int userAnswerId;
                do
                {
                    Console.WriteLine("Please Enter The answer Id ");
                } while (!(int.TryParse(Console.ReadLine(), out userAnswerId) && (userAnswerId is 1 or 2 or 3)));

                question.UserAnswer.AnswerId = userAnswerId;
                question.UserAnswer.AnswerText = question.Answers[userAnswerId - 1].AnswerText;
            }
            Console.Clear();

            Console.WriteLine("Right Answers");
            for (int i = 0; i < Questions?.Length; i++)
            {
                Console.WriteLine($"Question Number {i + 1} : {Questions[i].Body}");

                Console.WriteLine($"Right Answer => {Questions[i].CorrectAnswer.AnswerText}");

                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
