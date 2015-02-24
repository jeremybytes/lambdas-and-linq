using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinSyntax
{
    public static class Orders
    {
        public static IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>
            {
                new Order() { Id=1, CustomerId=3,
                    OrderDate = new DateTime(2014, 11, 17), TotalDue=25.23M },
                new Order() { Id=2, CustomerId=5,
                    OrderDate = new DateTime(2014, 11, 23), TotalDue=138.28M },
                new Order() { Id=3, CustomerId=6,
                    OrderDate = new DateTime(2014, 11, 24), TotalDue=98.75M },
                new Order() { Id=4, CustomerId=3,
                    OrderDate = new DateTime(2014, 11, 26), TotalDue=153.65M },
                new Order() { Id=5, CustomerId=1,
                    OrderDate = new DateTime(2014, 11, 26), TotalDue=200.01M },
                new Order() { Id=6, CustomerId=6,
                    OrderDate = new DateTime(2014, 11, 26), TotalDue=56.72M },
                new Order() { Id=7, CustomerId=2,
                    OrderDate = new DateTime(2014, 11, 26), TotalDue=56.56M },
                new Order() { Id=8, CustomerId=3,
                    OrderDate = new DateTime(2014, 12, 02), TotalDue=335.43M },
                new Order() { Id=9, CustomerId=7,
                    OrderDate = new DateTime(2014, 12, 10), TotalDue=202.00M },
                new Order() { Id=10, CustomerId=2,
                    OrderDate = new DateTime(2014, 12, 10), TotalDue=198.21M },
                new Order() { Id=11, CustomerId=3,
                    OrderDate = new DateTime(2014, 12, 11), TotalDue=90.98M },
                new Order() { Id=12, CustomerId=5,
                    OrderDate = new DateTime(2014, 12, 13), TotalDue=47.21M },
                new Order() { Id=13, CustomerId=6,
                    OrderDate = new DateTime(2014, 12, 13), TotalDue=49.90M },
                new Order() { Id=14, CustomerId=3,
                    OrderDate = new DateTime(2014, 12, 17), TotalDue=89.20M },
                new Order() { Id=15, CustomerId=3,
                    OrderDate = new DateTime(2014, 12, 18), TotalDue=20.34M },
                new Order() { Id=16, CustomerId=1,
                    OrderDate = new DateTime(2014, 12, 18), TotalDue=79.37M },
                new Order() { Id=17, CustomerId=4,
                    OrderDate = new DateTime(2014, 12, 18), TotalDue=99.99M },
                new Order() { Id=18, CustomerId=4,
                    OrderDate = new DateTime(2014, 12, 20), TotalDue=123.45M },
                new Order() { Id=19, CustomerId=1,
                    OrderDate = new DateTime(2015, 1, 3), TotalDue=28.30M },
                new Order() { Id=20, CustomerId=3,
                    OrderDate = new DateTime(2015, 1, 5), TotalDue=24.25M },
            };
            return orders;
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalDue { get; set; }
    }
}
