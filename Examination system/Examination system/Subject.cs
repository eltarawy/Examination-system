using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Exam Exam { get; set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            int examType, time, numberOfQuestions;

            Console.WriteLine("Welcome to the Exam Creator!");
            do
            {
                Console.WriteLine("Please Enter the type of Exam (1 for Practical | 2 for Final)");
            } while (!(int.TryParse(Console.ReadLine(), out examType) && (examType is 1 or 2)));

            do
            {
                Console.WriteLine("Please Enter the Time For Exam From (30 min to 180 min))");
            } while (!(int.TryParse(Console.ReadLine(), out time) && (time >= 30 && time <= 180)));

            do
            {
                Console.WriteLine("Please Enter the Number of questions");
            } while (!(int.TryParse(Console.ReadLine(), out numberOfQuestions) && (numberOfQuestions > 0)));

            if (examType == 1)
                Exam = new PracticalExam(time, numberOfQuestions);
            else
                Exam = new FinalExam(time, numberOfQuestions);
            Console.Clear();
            Exam.CreateListOfQuestions();
        }
    }
}
