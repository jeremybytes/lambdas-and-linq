using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinSyntax
{
    public static class OrderReports
    {
        public static IEnumerable<dynamic> 
            OrderDatesByCustomer1(DateTime startDate, DateTime endDate)
        {
            var people = People.GetPeople();
            var orders = Orders.GetOrders();

            var orderDates =  from p in people
                              join o in orders on p.Id equals o.CustomerId
                              where o.OrderDate >= startDate &&
                                    o.OrderDate <= endDate
                              orderby o.OrderDate
                              select new { p.LastName, p.FirstName, o.OrderDate };
            
            return orderDates;
        }

        public static IEnumerable<dynamic> 
            OrderDatesByCustomer2(DateTime startDate, DateTime endDate)
        {
            var people = People.GetPeople();
            var orders = Orders.GetOrders();

            var orderDates = people.Join(
                    orders,
                    p => p.Id,
                    o => o.CustomerId,
                    (p, o) => new { p.LastName, p.FirstName, o.OrderDate })
                .Where(r => r.OrderDate >= startDate && r.OrderDate <= endDate)
                .OrderBy(r => r.OrderDate);

            return orderDates;
        }
    }
}
