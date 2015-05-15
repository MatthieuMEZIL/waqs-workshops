using System;

namespace WAQSWorkshopServer.Service
{
    class WithInvoice : WAQSWorkshopServer.Invoice
    {
        public WAQSWorkshopServer.Invoice Invoice { get; set; }
    }
}
