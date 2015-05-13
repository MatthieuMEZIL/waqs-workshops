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
using System.ServiceModel;
using WAQS.ClientContext.Fault;

namespace WAQSWorkshopClient.ClientContext.Fault
{
    [DataContract(Namespace = "http://Northwind/Fault")]
    [KnownType("GetKnownTypes")]
    public partial class NorthwindFaultDetailEntities : FaultDetail
    {
        [DataMember]
        public object[] Entities { get; set; }
    
        public static IEnumerable<Type> GetKnownTypes()
        {
            var value = new List<Type>();
            value.Add(typeof(WAQSWorkshopClient.Customer));
            value.Add(typeof(WAQSWorkshopClient.Employee));
            value.Add(typeof(WAQSWorkshopClient.Invoice));
            value.Add(typeof(WAQSWorkshopClient.InvoiceDetail));
            value.Add(typeof(WAQSWorkshopClient.Order));
            value.Add(typeof(WAQSWorkshopClient.OrderDetail));
            value.Add(typeof(WAQSWorkshopClient.Product));
            AddKnownTypes(value);
            return value;
        }
        static partial void AddKnownTypes(List<Type> types);
    }
}
