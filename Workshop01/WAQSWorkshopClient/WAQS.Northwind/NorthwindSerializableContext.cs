//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WAQS.ClientContext.Interfaces;

namespace WAQSWorkshopClient.ClientContext.Interfaces.Serialization
{
    [DataContract(Namespace="http://Northwind/SerializableContext")]
    public partial class NorthwindSerializableContext : ISerializableContext
    {
        [DataMember]
        public List<WAQSWorkshopClient.Customer> Customers { get; set; }
    
        [DataMember]
        public List<WAQSWorkshopClient.Employee> Employees { get; set; }
    
        [DataMember]
        public List<WAQSWorkshopClient.InvoiceDetail> InvoiceDetails { get; set; }
    
        [DataMember]
        public List<WAQSWorkshopClient.Invoice> Invoices { get; set; }
    
        [DataMember]
        public List<WAQSWorkshopClient.OrderDetail> OrderDetails { get; set; }
    
        [DataMember]
        public List<WAQSWorkshopClient.Order> Orders { get; set; }
    
        [DataMember]
        public List<WAQSWorkshopClient.Product> Products { get; set; }
    
    }
}
