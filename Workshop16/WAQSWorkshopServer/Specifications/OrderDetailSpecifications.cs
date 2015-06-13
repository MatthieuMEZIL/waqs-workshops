using WAQS.Specifications;

namespace WAQSWorkshopServer.Specifications
{
    public static class OrderDetailSpecifications
    {
        public static double GetAmount(this OrderDetail orderDetail)
        {
            return orderDetail.UnitPrice * orderDetail.Quantity * (1 - orderDetail.Discount);
        }

        public static string GetProductFullName(this OrderDetail orderDetail)
        {
            return orderDetail.Product.GetFullName();
        }

        public static void DefineMetadata()
        {
            Metadata<OrderDetail>.DefineMinValue(c => c.Discount, 0);
            Metadata<OrderDetail>.DefineMaxValue(c => c.Discount, 1);
        }
    }
}