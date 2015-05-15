using System;

namespace WAQSWorkshopServer.Service
{
    class WithEmployee : WAQSWorkshopServer.Employee
    {
        public WAQSWorkshopServer.Employee Employee { get; set; }
    }
}
