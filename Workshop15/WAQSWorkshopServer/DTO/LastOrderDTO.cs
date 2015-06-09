using System;

namespace WAQSWorkshopServer.DTO
{
    public class LastOrderDTO
    {
        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
    }
}