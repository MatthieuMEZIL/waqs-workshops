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
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using WAQS.Service.Interfaces;

namespace WAQS.WCFService.Contract
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public partial class StandardFaultsAttribute : Attribute, IContractBehavior
    {
    	protected virtual List<Type> GetFaultTypes()
    	{
    		var value = new List<Type>() { typeof(FaultDetail), typeof(Error), typeof(ErrorCollection) };
    		GetFaultTypes(ref value);
    		return value;
    	}
    
    	partial void GetFaultTypes(ref List<Type> types);
    
    	public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    	{
    	}
    
    	public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    	{
    	}
    
    	public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
    	{
    	}
    
    	public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)    
    	{
    		foreach (OperationDescription op in contractDescription.Operations)
    			foreach (Type fault in GetFaultTypes())
    			{
    				if (! op.Faults.Any(f => f.Name == fault.Name))
    					op.Faults.Add(MakeFault(fault));
    				if (! op.KnownTypes.Contains(fault))
    					op.KnownTypes.Add(fault);
    			}
    	}
    
    	private FaultDescription MakeFault(Type detailType)
    	{
    		string action = detailType.Name;
    		DescriptionAttribute description = (DescriptionAttribute)Attribute.GetCustomAttribute(detailType, typeof(DescriptionAttribute));
    		if (description != null)
    			action = description.Description;
    		return new FaultDescription(action) { DetailType = detailType, Name = detailType.Name };
    	}
    }
}