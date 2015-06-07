using System;

namespace WAQSWorkshopServer.WAQSDTO
{
    [System.Runtime.Serialization.DataContractAttribute(IsReference = true, Namespace = "http://Northwind/DTO")]
    public partial class LastOrderDTO
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        public int OrderId
        {
            get;
            set;
        }

        [System.Runtime.Serialization.DataMemberAttribute]
        public int EmployeeId
        {
            get;
            set;
        }

        [System.Runtime.Serialization.DataMemberAttribute]
        public string EmployeeFullName
        {
            get;
            set;
        }

        [System.Runtime.Serialization.DataMemberAttribute]
        public DateTime Date
        {
            get;
            set;
        }

        [System.Runtime.Serialization.DataMemberAttribute]
        public double Total
        {
            get;
            set;
        }
    }
}
