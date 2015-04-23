using System;
using System.Linq;

namespace JoinSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            DateTime endDate = new DateTime(2014, 12, 31);

            var queryOrderDates = 
                QueryReports.OrderDatesByCustomer(startDate, endDate);

            foreach (var item in queryOrderDates)
                Console.WriteLine(item);

            Console.WriteLine("======================================");

            var fluentOrderDates =
                FluentReports.OrderDatesByCustomer(startDate, endDate);

            foreach (var item in fluentOrderDates)
                Console.WriteLine(item);
            
            Console.WriteLine("======================================");

            Console.ReadLine();
        }
    }
}
