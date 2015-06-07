using System;

namespace WAQSWorkshopServer.Service
{
    class WithCustomer : WAQSWorkshopServer.Customer
    {
        public WAQSWorkshopServer.Customer Customer { get; set; }
    }
}
