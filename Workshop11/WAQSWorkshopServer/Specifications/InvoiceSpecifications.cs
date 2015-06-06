using System;
using WAQS.DAL.Interfaces;
using WAQS.Specifications;
using WAQSWorkshopServer.Service;
using WAQSWorkshopServer.Service.Interfaces;

namespace WAQSWorkshopServer.Specifications
{
    public static class InvoiceSpecifications
    {
        public static Invoice AddInvoice(int orderId, INorthwindService context)
        {
            var order = context.Orders.IncludeOrderDetails().WithCustomerCompanyName().WithCustomerContactName().FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new ArgumentException("The is no order for this id", "orderId");
            }
            Invoice invoice = new Invoice
            {
                OrderId = order.Id,
                CustomerId = order.CustomerId,
                CustomerCompanyName = order.CustomerCompanyName,
                CustomerContactName = order.CustomerContactName,
                Total = order.GetTotal()
            };
            foreach (var od in order.OrderDetails)
            {
                invoice.InvoiceDetails.Add(CreateInvoiceDetail(od));
            }
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return invoice;
        }

        [NotApplicableOnClient]
        public static InvoiceDetail CreateInvoiceDetail(this OrderDetail od)
        {
            return new InvoiceDetail
            {
                OrderDetailId = od.Id,
                Quantity = od.Quantity,
                UnitPrice = od.UnitPrice,
                Discount = od.Discount,
                Amount = od.GetAmount()
            };
        }
    }
}