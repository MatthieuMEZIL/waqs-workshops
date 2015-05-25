using System.Linq;

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
    }
}