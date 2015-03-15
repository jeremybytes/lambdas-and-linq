using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapturedVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = People.GetPeople();
            BadCapture(people);
            GoodCapture(people);
            Console.ReadLine();
        }

        // Captured variables have the value at the time of *use*
        // not the value at the time of capture.
        private static void BadCapture(List<Person> people)
        {
            Task[] tasks = new Task[people.Count()];
            for(int i = 0; i < people.Count(); i++)
            {
                // The indexer (i) is captured. This will have
                // a value of "7", the value of the indexer 
                // at the end of the "for" loop.
                tasks[i] = Task.Run(() => OutputPerson(people, i));
            }
            Task.WaitAll(tasks);
        }

        private static void GoodCapture(List<Person> people)
        {
            Task[] tasks = new Task[people.Count()];
            for (int i = 0; i < people.Count(); i++)
            {
                // A local variable that has a copy of the 
                // indexer (i) is captured. This creates a 
                // different variable for each iteration of 
                // the "for" loop, and the expected value is 
                // captured.
                int capturedIndex = i;
                tasks[i] = Task.Run(() => OutputPerson(people, capturedIndex));
            }
            Task.WaitAll(tasks);
        }

        private static void OutputPerson(List<Person> people, int index)
        {
            try
            {
                Console.WriteLine(people[index].ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Argument out of range. Actual value: {0}", index);
            }
        }
    }
}
