using System;

namespace WAQSWorkshopServer.Service
{
    class WithOrderDetail : WAQSWorkshopServer.OrderDetail
    {
        public WAQSWorkshopServer.OrderDetail OrderDetail { get; set; }
    }
}
