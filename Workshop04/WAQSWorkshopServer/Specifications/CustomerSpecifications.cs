using System.Linq;

namespace WAQSWorkshopServer.Specifications
{
    public static class CustomerSpecifications
    {
        public static double GetTotalSpent(this Customer customer)
        {
            return customer.Orders.Sum(o => o.GetTotal());
        }

        public static string GetFullName(this Customer customer)
        {
            return customer.CompanyName + " " + customer.ContactName;
        }
    }
}