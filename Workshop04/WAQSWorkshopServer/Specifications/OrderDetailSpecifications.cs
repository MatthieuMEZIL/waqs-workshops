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
    }
}