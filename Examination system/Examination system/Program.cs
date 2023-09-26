using System.Diagnostics;

namespace Examination_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(1, "C#");

            sub1.CreateExam();
            Console.Clear();


            char Char;
            do
            {
                Console.WriteLine("Do you want to  Start Exam (Y|N)");

            } while (!(char.TryParse(Console.ReadLine(), out Char) && (Char == 'y' || Char == 'n')));


            if (Char == 'y')
            {
                Console.Clear();

                Stopwatch sw = new Stopwatch();

                sw.Start();

                sub1.Exam.ShowExam();

                sw.Stop();

                Console.WriteLine($"Time = {sw.Elapsed}");
            }

            Console.WriteLine("Thank you");
        }
    }
}