namespace WAQSWorkshopServer.Specifications
{
    public static class ProductSpecifications
    {
        public static string GetFullName(this Product product)
        {
            return product.Name + " (" + product.Category.Name + ")";
        }
    }
}