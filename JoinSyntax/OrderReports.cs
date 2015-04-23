using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinSyntax
{
    public class CustomerOrderDate
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return string.Format("{0:yyyy/MM/dd}: {1} {2}",
                    OrderDate, FirstName, LastName);
        }
    }

    public static class QueryReports
    {
        public static IEnumerable<CustomerOrderDate>
            OrderDatesByCustomer(DateTime startDate, DateTime endDate)
        {
            var people = People.GetPeople();
            var orders = Orders.GetOrders();

            var orderDates = from p in people
                             join o in orders on p.Id equals o.CustomerId
                             where o.OrderDate >= startDate &&
                                   o.OrderDate <= endDate
                             orderby o.OrderDate
                             select new CustomerOrderDate
                               {
                                   LastName = p.LastName,
                                   FirstName = p.FirstName,
                                   OrderDate = o.OrderDate
                               };

            return orderDates;
        }
    }

    public static class FluentReports
    {
        public static IEnumerable<CustomerOrderDate>
            OrderDatesByCustomer(DateTime startDate, DateTime endDate)
        {
            var people = People.GetPeople();
            var orders = Orders.GetOrders();

            var orderDates = people.Join(
                    orders,
                    p => p.Id,
                    o => o.CustomerId,
                    (p, o) => new CustomerOrderDate
                    {
                        LastName = p.LastName,
                        FirstName = p.FirstName,
                        OrderDate = o.OrderDate
                    })
                .Where(r => r.OrderDate >= startDate && r.OrderDate <= endDate)
                .OrderBy(r => r.OrderDate);

            return orderDates;
        }
    }
}
