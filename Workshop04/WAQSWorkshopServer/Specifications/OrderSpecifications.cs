using System.Linq;

namespace WAQSWorkshopServer.Specifications
{
    public static class OrderSpecifications
    {
        public static double GetTotal(this Order order)
        {
            return order.OrderDetails.Sum(od => od.GetAmount());
        }
    }
}