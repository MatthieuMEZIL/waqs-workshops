using System.Linq;
using WAQSWorkshopServer.DTO;
using WAQSWorkshopServer.Service.Interfaces;

namespace WAQSWorkshopServer.Specifications
{
    public static class OrderSpecifications
    {
        public static double GetTotal(this Order order)
        {
            return order.OrderDetails.Sum(od => od.GetAmount());
        }

        public static string GetCustomerCompanyName(this Order order)
        {
            return order.Customer.CompanyName;
        }

        public static string GetCustomerContactName(this Order order)
        {
            return order.Customer.ContactName;
        }

        public static bool GetHasInvoice(this Order order)
        {
            return order.Invoice != null;
        }

        public static LastOrderDTO GetLastOrder(INorthwindService context)
        {
            return (from o in context.Orders
                    where o.EmployeeId.HasValue
                    orderby o.OrderDate descending
                    select new LastOrderDTO
                    {
                        OrderId = o.Id,
                        EmployeeId = o.EmployeeId.Value,
                        EmployeeFullName = o.Employee.GetFullName(),
                        Date = o.OrderDate,
                        Total = o.GetTotal()
                    }).FirstOrDefault();
        }
    }
}