using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void CreateListOfQuestions()
        {
            Questions = new Question[NumberOfQuestions];
            for(var i = 0; i < Questions?.Length; i++)
            {
                int choice;
                do
                {
                    Console.WriteLine("Please Enter the Type of Question (1 for MCQ | 2 For True or False)");
                } while (!(int.TryParse(Console.ReadLine(), out choice) && (choice is 1 or 2)));
                Console.Clear();


                if (choice == 1)
                {
                    Questions[i] = new McqQuestion();
                    Questions[i].AddAddQestion();

                }
                else
                {
                    Questions[i] = new TrueOrFalseQuestion();
                    Questions[i].AddAddQestion();

                }
            }
        }

        public override void ShowExam()
        {
            foreach(var question in Questions)
            {
                Console.WriteLine(question);

                for (int i = 0; i < question?.Answers?.Length; i++)
                    Console.WriteLine(question.Answers[i]);
                int userAnswerId;
                if (question?.GetType() == typeof(McqQuestion))
                {

                    do
                    {
                        Console.WriteLine("Please Enter The answer Id ");
                    } while (!(int.TryParse(Console.ReadLine(), out userAnswerId) && (userAnswerId is 1 or 2 or 3)));
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Please Enter The answer Id (1 For True | 2 For False) ");
                    } while (!(int.TryParse(Console.ReadLine(), out userAnswerId) && (userAnswerId is 1 or 2)));
                }

                question.UserAnswer.AnswerId = userAnswerId;

                question.UserAnswer.AnswerText = question.Answers[userAnswerId - 1].AnswerText;

            }

            Console.Clear();

            int grade = 0, totalMarks = 0;


            for (int i = 0; i < Questions?.Length; i++)
            {
                totalMarks += Questions[i].Mark;
                if (Questions[i].UserAnswer.AnswerId == Questions[i].CorrectAnswer.AnswerId)
                {
                    grade += Questions[i].Mark;
                }

                Console.WriteLine($"Question {i + 1} : {Questions[i].Body}");
                Console.WriteLine($"Your Answer => {Questions[i].UserAnswer.AnswerText}");
                Console.WriteLine($"Correct Answer => {Questions[i].CorrectAnswer.AnswerText}");
            }

            Console.WriteLine($"Your Grade is {grade} from {totalMarks}");
        }
    }
}