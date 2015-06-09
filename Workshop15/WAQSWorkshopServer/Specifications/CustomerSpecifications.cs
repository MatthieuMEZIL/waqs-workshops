using System.Linq;
using WAQS.Specifications;

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

        public static void DefineMetadata()
        {
            Metadata<Customer>.IsNullable(c => c.Region, c => c.Country != "USA");
            Metadata<Customer>.DefinePattern(c => c.PostalCode, c => c.Country == "USA" ? "^[0-9]{5}(?:-[0-9]{4})?$" : 
                                                                 c.Country == "France" ? @"^(?:\d{2}|(?:2(?:A|B)))\d{3}$" : 
                                                                 null);
        }
    }
}