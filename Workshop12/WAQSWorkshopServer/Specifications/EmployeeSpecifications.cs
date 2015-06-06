using System.Linq;

namespace WAQSWorkshopServer.Specifications
{
    public static class EmployeeSpecifications
    {
        public static string GetFullName(this Employee employee)
        {
            return employee.FirstName + " " + employee.LastName;
        }

        public static bool AlreadySoldTo(this Employee employee, Customer customer)
        {
            return customer.Orders.Any(o => o.EmployeeId == employee.Id);
        }
    }
}