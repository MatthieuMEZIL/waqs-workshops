using System;

namespace WAQSWorkshopServer.Service
{
    class WithInvoiceDetail : WAQSWorkshopServer.InvoiceDetail
    {
        public WAQSWorkshopServer.InvoiceDetail InvoiceDetail { get; set; }
    }
}
