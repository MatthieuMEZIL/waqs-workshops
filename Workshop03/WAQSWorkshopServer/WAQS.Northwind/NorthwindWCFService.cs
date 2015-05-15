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
using System.Linq;
using System.ServiceModel.Activation;
using WAQS.Common;
using WAQS.SerializableExpressions;
using WAQS.Service.Interfaces;
using WAQS.WCFService;
using WAQS.WCFService.Contract;
using WAQSWorkshopServer;
using WAQSWorkshopServer.Service.Interfaces;
using WAQSWorkshopServer.WCFService.Contract;

namespace WAQSWorkshopServer.WCFService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public partial class NorthwindWCFService : INorthwindWCFService
    {	
    	private Func<INorthwindService> _serviceFactory;
    	private Dictionary<Type, IExceptionDetailFactory> _exceptionDetailFactories;
    
    	public NorthwindWCFService(Func<INorthwindService> serviceFactory, WAQS.Common.IExceptionDetailFactory[] exceptionDetailFactories)
    	{
    		_serviceFactory = serviceFactory;
    		_exceptionDetailFactories = exceptionDetailFactories.ToDictionary(ed => ed.Type);
    	}
    	
    	private void TryRethrowFault(Action action)
    	{
    		Action<Action> metaRethrow = null;
    		TryMetaRethrow(ref metaRethrow);
    		if (metaRethrow == null)
    			WAQS.WCFService.WCFService.TryRethrowFault(action, _exceptionDetailFactories, CreateFaultDetail, fd => DefineFaultDetail(fd));
    		else
    			metaRethrow(() => WAQS.WCFService.WCFService.TryRethrowFault(action, _exceptionDetailFactories, CreateFaultDetail, fd => DefineFaultDetail(fd)));
    	}
    	partial void TryMetaRethrow(ref Action<Action> action);
    	
    	private T TryRethrowFault<T>(Func<T> action)
    	{
    		Func<Func<T>, T> metaRethrow = null;
    		TryMetaRethrow(ref metaRethrow);
    		if (metaRethrow == null)
    			return WAQS.WCFService.WCFService.TryRethrowFault(action, _exceptionDetailFactories, CreateFaultDetail, fd => DefineFaultDetail(fd));
    		return metaRethrow(() => WAQS.WCFService.WCFService.TryRethrowFault(action, _exceptionDetailFactories, CreateFaultDetail, fd => DefineFaultDetail(fd)));
    	}
    	partial void TryMetaRethrow<T>(ref Func<Func<T>, T> action);
    
    	private FaultDetail CreateFaultDetail(WAQS.Common.IExceptionDetail exceptionDetail)
    	{
    		var entities = exceptionDetail.Entities.ToList();
    		if (entities.Count == 0)
    			return new FaultDetail { ErrorMessage = exceptionDetail.Message };
    		return new NorthwindFaultDetailEntities { ErrorMessage = exceptionDetail.Message, Entities = entities };
    	}
    
    	partial void DefineFaultDetail(FaultDetail faultDetail);
    
    
    	public NorthwindQueryResult Execute(QuerySerialization query)
    	{
    		Executing(query);
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Execute(query);
    				}
    			});
    	}
    	partial void Executing(QuerySerialization query);
    
    	public NorthwindQueriesResult ExecuteMany(QueriesSerialization queries)
    	{
    		Executing(queries);
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.ExecuteMany(queries);
    				}
    			});
    	}
    	partial void Executing(QueriesSerialization queries);
    
    	public NorthwindQueryResultPage LoadPage(int pageSize, SerializableExpression queryExpression, string[] withSpecificationsProperties, LoadPageParameter[] identifiers)
    	{
    		LoadingPage(pageSize, queryExpression, withSpecificationsProperties, identifiers);
    		return TryRethrowFault(() =>
    		{
    			using (var service = _serviceFactory())
    			{
    				return service.LoadPage(pageSize, queryExpression, withSpecificationsProperties, identifiers);
    			}
    		});
    	}
    	partial void LoadingPage(int pageSize, SerializableExpression queryExpression, string[] withSpecificationsProperties, LoadPageParameter[] identifiers);
    
    	public DateTime GetDbDateTime()
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.GetDbDateTime();
    				}
    			});
    	}
    
    	public NorthwindSerializableContext SaveChanges(NorthwindSerializableContext clientContext)
    	{
    		SavingChanges(clientContext);
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					foreach (var entity in clientContext.Customers)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.Employees)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.InvoiceDetails)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.Invoices)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.OrderDetails)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.Orders)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.Products)
    						service.ApplyChanges(entity);
    					foreach (var entity in clientContext.Categories)
    						service.ApplyChanges(entity);
    					service.SaveChanges();
    					return clientContext;
    				}
    			});
    	}
    	partial void SavingChanges(NorthwindSerializableContext clientContext);
    
    	public List<Error> Validate(Customer entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(Employee entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(InvoiceDetail entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(Invoice entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(OrderDetail entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(Order entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(Product entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    
    	public List<Error> Validate(Category entity)
    	{
    		return TryRethrowFault(() => 
    			{
    				using (var service = _serviceFactory())
    				{
    					return service.Validate(entity).ToList();
    				}
    			});
    	}
    }
    
}