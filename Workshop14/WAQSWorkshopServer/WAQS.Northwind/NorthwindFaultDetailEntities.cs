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
using WAQS.WCFService.Contract;

namespace WAQSWorkshopServer.WCFService.Contract
{
    [DataContract(Namespace = "http://Northwind/Fault")]
    [KnownType("GetKnownTypes")]
    public partial class NorthwindFaultDetailEntities : FaultDetail
    {
    	[DataMember]
    	public List<object> Entities { get; set; }
    
    	public static IEnumerable<Type> GetKnownTypes()
    	{
    		var value = new List<Type>();
    		value.Add(typeof(WAQSWorkshopServer.Category));
    		value.Add(typeof(WAQSWorkshopServer.Customer));
    		value.Add(typeof(WAQSWorkshopServer.Employee));
    		value.Add(typeof(WAQSWorkshopServer.Invoice));
    		value.Add(typeof(WAQSWorkshopServer.InvoiceDetail));
    		value.Add(typeof(WAQSWorkshopServer.Order));
    		value.Add(typeof(WAQSWorkshopServer.OrderDetail));
    		value.Add(typeof(WAQSWorkshopServer.Product));
    		AddKnownTypes(value);
    		return value;
    	}
    	static partial void AddKnownTypes(List<Type> types);
    }
}
