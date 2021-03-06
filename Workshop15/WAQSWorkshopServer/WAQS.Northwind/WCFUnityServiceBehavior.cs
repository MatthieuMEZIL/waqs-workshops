//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WAQS.WCFService
{
    public class WCFUnityServiceBehavior : IServiceBehavior
    {
    	public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    	{
    	}
    
    	public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    	{
    		foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
    		{
    			var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
    			if (channelDispatcher != null)
    				foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
    					endpointDispatcher.DispatchRuntime.InstanceProvider = new WCFUnityInstanceProvider(serviceDescription.ServiceType);
    		}
    	}
    
    	public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    	{
    	}
    }
}
