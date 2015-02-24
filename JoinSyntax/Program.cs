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

            var orderDates1 = 
                OrderReports.OrderDatesByCustomer1(startDate, endDate);

            foreach (var item in orderDates1)
                Console.WriteLine("{0:yyyy/MM/dd}: {1} {2}",
                    item.OrderDate, item.FirstName, item.LastName);

            Console.WriteLine("======================================");

            var orderDates2 =
                OrderReports.OrderDatesByCustomer2(startDate, endDate);

            foreach (var item in orderDates2)
                Console.WriteLine("{0:yyyy/MM/dd}: {1} {2}",
                    item.OrderDate, item.FirstName, item.LastName);
            
            Console.WriteLine("======================================");

            Console.ReadLine();
        }
    }
}
