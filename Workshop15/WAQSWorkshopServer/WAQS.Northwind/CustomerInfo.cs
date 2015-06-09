namespace WAQSWorkshopServer.WAQSDTO
{
    [System.Runtime.Serialization.DataContractAttribute(IsReference = true, Namespace = "http://Northwind/DTO")]
    public partial class CustomerInfo
    {
        [System.Runtime.Serialization.DataMemberAttribute]
        public string Id
        {
            get;
            set;
        }

        [System.Runtime.Serialization.DataMemberAttribute]
        public string Name
        {
            get;
            set;
        }

        [System.Runtime.Serialization.DataMemberAttribute]
        public double TotalSpent
        {
            get;
            set;
        }
    }
}
