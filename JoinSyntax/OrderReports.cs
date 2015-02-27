using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinSyntax
{
    public class CustomerOrderDates
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public static class OrderReports
    {
        public static IEnumerable<CustomerOrderDates>
            OrderDatesByCustomer1(DateTime startDate, DateTime endDate)
        {
            var people = People.GetPeople();
            var orders = Orders.GetOrders();

            var orderDates = from p in people
                             join o in orders on p.Id equals o.CustomerId
                             where o.OrderDate >= startDate &&
                                   o.OrderDate <= endDate
                             orderby o.OrderDate
                             select new CustomerOrderDates
                               {
                                   LastName = p.LastName,
                                   FirstName = p.FirstName,
                                   OrderDate = o.OrderDate
                               };

            return orderDates;
        }

        public static IEnumerable<CustomerOrderDates>
            OrderDatesByCustomer2(DateTime startDate, DateTime endDate)
        {
            var people = People.GetPeople();
            var orders = Orders.GetOrders();

            var orderDates = people.Join(
                    orders,
                    p => p.Id,
                    o => o.CustomerId,
                    (p, o) => new CustomerOrderDates
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
