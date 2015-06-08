using System;

namespace WAQSWorkshopServer.Service
{
    class WithOrder : WAQSWorkshopServer.Order
    {
        public WAQSWorkshopServer.Order Order { get; set; }
    }
}
