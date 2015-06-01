//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WAQS.ClientContext;
using WAQS.ClientContext.Interfaces;
using WAQS.ClientContext.Interfaces.ExpressionSerialization;
using WAQS.ClientContext.Interfaces.Querying;
using WAQS.ClientContext.Interfaces.Query;
using WAQS.ClientContext.QueryResult;
using WAQS.ComponentModel;
using WAQS.Entities;
using WAQSWorkshopClient.ClientContext.ServiceReference;
using WAQSWorkshopClient.ClientContext.QueryResult;

namespace WAQSWorkshopClient.ClientContext
{
    public abstract partial class NorthwindClientContextBase : IClientContextBase
    {
        public NorthwindClientContextBase(Func<INorthwindService> serviceFactory)
        {
            ServiceFactory = serviceFactory;
        }
        
        ~NorthwindClientContextBase()
        {
            Dispose(false);
        }
    
        public string Name 
        { 
            get { return "WAQSWorkshopClient.ClientContext.NorthwindClientContext"; } 
        }
    
        public string ServerEntitiesNamespace 
    	{ 
    		get { return "WAQSWorkshopServer"; } 
    	}
    
        public string ClientEntitiesNamespace 
    	{ 
    		get { return "WAQSWorkshopClient"; }
    	}
    
        protected Func<WAQSWorkshopClient.ClientContext.ServiceReference.INorthwindService> ServiceFactory { get; private set; }
        
        private Dictionary<object, object> _entitiesGot;
        protected Dictionary<object, object> EntitiesGot
        {
            get { return _entitiesGot ?? (_entitiesGot = new Dictionary<object, object>()); }
        }
    
        protected abstract WAQSWorkshopClient.Category GetEntity(WAQSWorkshopClient.Category entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.Customer GetEntity(WAQSWorkshopClient.Customer entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.Employee GetEntity(WAQSWorkshopClient.Employee entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.Invoice GetEntity(WAQSWorkshopClient.Invoice entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.InvoiceDetail GetEntity(WAQSWorkshopClient.InvoiceDetail entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.Order GetEntity(WAQSWorkshopClient.Order entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.OrderDetail GetEntity(WAQSWorkshopClient.OrderDetail entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
        protected abstract WAQSWorkshopClient.Product GetEntity(WAQSWorkshopClient.Product entity, bool applyState, MergeOption? mergeOption = null, bool applyDataTransfer = false);
    
    
        public virtual async Task<IEnumerable<T>> ExecuteQueryAsync<T>(IAsyncQueryable<T> query, MergeOption? mergeOption = null, Func<bool> cancel = null, GetEntityAsyncOption getEntityOption = GetEntityAsyncOption.NoTrackingOnly)
        {
            var value = await ExecuteQueryInternalAsync(query, mergeOption ?? MergeOption.NoTracking, cancel, getEntityOption);
            if (value == null)
                return new T[0];
            return ((IEnumerable<object>)value).Cast<T>();
        }
        
        public virtual async Task<T> ExecuteQueryAsync<T>(IAsyncQueryableValue<T> query, MergeOption? mergeOption = null, Func<bool> cancel = null, GetEntityAsyncOption getEntityOption = GetEntityAsyncOption.NoTrackingOnly)
        {
            var value = await ExecuteQueryInternalAsync(query, mergeOption ?? MergeOption.NoTracking, cancel, getEntityOption);
            return value == null ? default(T) : (T)value;
        }
    
        public virtual async Task<QueryPage<T>> LoadPageAsync<T>(int pageSize, IAsyncQueryable<T> query, LoadPageParameter[] identifiers, MergeOption? mergeOption = null, Func<bool> cancel = null, GetEntityAsyncOption getEntityOption = GetEntityAsyncOption.NoTrackingOnly)
        {
            if (identifiers.Length == 0)
                throw new InvalidOperationException();
            if (query.Includes.Any())
                throw new NotImplementedException();
            try
            {
                var result = await ProxyHelper.ExecuteFuncAsync(ServiceFactory, service => Task.Factory.FromAsync(service.BeginLoadPage(pageSize, query.Expression, query.WithSpecificationsProperties.ToArray(), identifiers, null, null), ar => service.EndLoadPage(ar)), 0);
                EntitiesGot.Clear();
                return new QueryPage<T>(result.PageIndex, ((IEnumerable<object>)InstanciateAndAttach(query, result.Result, mergeOption ?? MergeOption.NoTracking)).Cast<T>());
            }
            catch (Exception e)
            {
                if (IsDisposed)
                    return null;
                bool catched = false;
                CatchException(e, ref catched);
                if (catched)
                    return null;
                throw e;
            }
        }
    
        public Task<object[]> ExecuteQueriesAsync(params IAsyncQueryableBase[] queries)
        {
            return ExecuteQueriesAsync(queries.AsEnumerable());
        }
    
        public virtual async Task<object[]> ExecuteQueriesAsync(IEnumerable<IAsyncQueryableBase> queries, MergeOption? mergeOption = null, Func<bool> cancel = null, GetEntityAsyncOption getEntityOption = GetEntityAsyncOption.NoTrackingOnly)
        {
            if (mergeOption == null)
                mergeOption = MergeOption.NoTracking;
            ExecutingQueries(queries, mergeOption.Value);
            try
            {
                Queue<AsyncQueryableInclude> includes = null;
                var result = await ProxyHelper.ExecuteFuncAsync(ServiceFactory, service => Task.Factory.FromAsync(service.BeginExecuteMany(MakeQueriesSerialization(queries, out includes), null, null), ar => service.EndExecuteMany(ar)), 0);
                if (IsDisposed || cancel != null && cancel())
                    return null;
    
    			if (getEntityOption == GetEntityAsyncOption.AllMergeOption || (mergeOption.Value == MergeOption.NoTracking && (int)getEntityOption >= (int)GetEntityAsyncOption.NoTrackingOnly))
                {
    				return await Task.Factory.StartNew(() => GetQueriesResults(queries, includes, result, mergeOption.Value));
                }
                else
                {
                return GetQueriesResults(queries, includes, result, mergeOption.Value);
            }
            }
            catch (Exception e)
            {
                if (IsDisposed || cancel != null && cancel())
                    return null;
                bool catched = false;
                CatchException(e, ref catched);
                if (catched)
                    return null;
                throw e;
            }
        }
        partial void ExecutingQueries(IEnumerable<IAsyncQueryableBase> queries, MergeOption mergeOption);
    
        private object[] GetQueriesResults(IEnumerable<IAsyncQueryableBase> queries, Queue<AsyncQueryableInclude> includes, NorthwindQueriesResult result, MergeOption mergeOption)
        {
            EntitiesGot.Clear();
            var value = new object[queries.Count()];
            int mainQueryIndex = 0;
            int queryIndex = 0;
            foreach (var query in queries)
            {
                var queryValue = InstanciateAndAttach(query, result.QueryResults[queryIndex ++], mergeOption);
                LoadIncludes(query, queryValue, includes, result, mergeOption, ref queryIndex, new Dictionary<string,object[]>());
                value[mainQueryIndex ++] = queryValue;
            }
            return value;
        }
        
        private async Task<object> ExecuteQueryInternalAsync(IAsyncQueryableBase query, MergeOption mergeOption, Func<bool> cancel, GetEntityAsyncOption getEntityOption)
        {
            ExecutingQuery(query, mergeOption);
            if (IsDisposed || cancel != null && cancel())
                return null;
            try
            {
                if (query.Includes.Any())
                {
                    Queue<AsyncQueryableInclude> includes = null;
                    var result = await ProxyHelper.ExecuteFuncAsync(ServiceFactory, service => Task.Factory.FromAsync(service.BeginExecuteMany(MakeQueriesSerialization(query, out includes), null, null), ar => service.EndExecuteMany(ar)), 0);
                    if (IsDisposed || cancel != null && cancel())
                        return null;
                    EntitiesGot.Clear();
    				if (getEntityOption == GetEntityAsyncOption.AllMergeOption || (mergeOption == MergeOption.NoTracking && (int)getEntityOption >= (int)GetEntityAsyncOption.NoTrackingOnly))
    				{
    					return await Task.Factory.StartNew(() => 
    					{
                    var value = InstanciateAndAttach(query, result.QueryResults[0], mergeOption);
                    LoadIncludes(query, value, includes, result, mergeOption);
                    return value;
    					});
    				} else {
    					var value = InstanciateAndAttach(query, result.QueryResults[0], mergeOption);
    					LoadIncludes(query, value, includes, result, mergeOption);
    					return value;
                }
                }
                else
                {
                    var result = await ProxyHelper.ExecuteFuncAsync(ServiceFactory, service => Task.Factory.FromAsync(service.BeginExecute(MakeQuerySerialization(query), null, null), ar => service.EndExecute(ar)), 0);
                    EntitiesGot.Clear();
                    if (getEntityOption == GetEntityAsyncOption.AllMergeOption || (mergeOption == MergeOption.NoTracking && (int)getEntityOption >= (int)GetEntityAsyncOption.NoTrackingOnly)) 
    				{
    					return await Task.Factory.StartNew(() => InstanciateAndAttach(query, result, mergeOption));
    				} else {
                    return InstanciateAndAttach(query, result, mergeOption);
                }
            }
            }
            catch (Exception e)
            {
                if (IsDisposed || cancel != null && cancel())
                    return null;
                bool catched = false;
                CatchException(e, ref catched);
                if (catched)
                    return null;
                throw e;
            }
        }
        partial void ExecutingQuery(IAsyncQueryableBase query, MergeOption mergeOption);
        
        private QuerySerialization MakeQuerySerialization(IAsyncQueryableBase query)
        {
            return new QuerySerialization { Expression = query.Expression, SerializableType = new SerializableType(query.Type), WithSpecificationsProperties = query.WithSpecificationsProperties.ToList() };
        }
        
        private QueriesSerialization MakeQueriesSerialization(IEnumerable<IAsyncQueryableBase> queries, out Queue<AsyncQueryableInclude> includes)
        {
            var queriesSerialization = new QueriesSerialization();
            includes = new Queue<AsyncQueryableInclude>();
            foreach (var query in queries)
                MakeQueriesSerialization(query, queriesSerialization, includes, new HashSet<string>());
            return queriesSerialization;
        }
        
        private QueriesSerialization MakeQueriesSerialization(IAsyncQueryableBase query, out Queue<AsyncQueryableInclude> includes)
        {
            var queriesSerialization = new QueriesSerialization();
            includes = new Queue<AsyncQueryableInclude>();
            MakeQueriesSerialization(query, queriesSerialization, includes, new HashSet<string>());
            return queriesSerialization;
        }
        
        private void MakeQueriesSerialization(IAsyncQueryableBase query, QueriesSerialization queriesSerialization, Queue<AsyncQueryableInclude> includes, HashSet<string> includePathes, string includeBasePath = "", bool add = true)
        {
            if (add)
                queriesSerialization.QuerySerializations.Add(MakeQuerySerialization(query));
            foreach (var include in query.Includes)
            {
                var includeValue = include(query);
                string path = includeBasePath == null || includeValue.Path == null ? null : string.Concat(includeBasePath, ".", includeValue.Path);
                bool addIncludeQuery = ! (path == null || includePathes.Contains(path));
                if (addIncludeQuery)
                    includePathes.Add(path);
                includes.Enqueue(includeValue);
                foreach (var includeQuery in includeValue.Queries)
                    MakeQueriesSerialization(includeQuery, queriesSerialization, includes, includePathes, path, path == null || addIncludeQuery);
            }
        }
    
        private void LoadIncludes(IAsyncQueryableBase query, object parentEntities, Queue<AsyncQueryableInclude> includes, NorthwindQueriesResult result, MergeOption mergeOption)
        {
            int index = 1;
            LoadIncludes(query, parentEntities, includes, result, mergeOption, ref index, new Dictionary<string,object[]>());
        }
    
        private void LoadIncludes(IAsyncQueryableBase query, object parentEntities, Queue<AsyncQueryableInclude> includes, NorthwindQueriesResult result, MergeOption mergeOption, ref int index, Dictionary<string, object[]> includeValues, string includeBasePath = "")
        {
            var includesEnumerator = query.Includes.GetEnumerator();
            while (includesEnumerator.MoveNext())
            {
                var include = includes.Dequeue();
                string path = includeBasePath == null || include.Path == null ? null : string.Concat(includeBasePath, ".", include.Path);
                bool loadIncludeQuery = ! (path == null || includeValues.ContainsKey(path));
                var includeQueriesEnumerator = include.Queries.AsEnumerable().GetEnumerator();
                while (includeQueriesEnumerator.MoveNext())
                {
                    var values = new object[include.Queries.Length];
                    if (path == null || loadIncludeQuery)
                    {
                        for (int queryIndex = 0; queryIndex < include.Queries.Length; queryIndex++)
                        {
                            var includeQuery = includeQueriesEnumerator.Current;
                            var value = InstanciateAndAttach(includeQuery, result.QueryResults[index++], mergeOption);
                            LoadIncludes(includeQuery, value, includes, result, mergeOption, ref index, includeValues, path);
                            values[queryIndex] = value;
                            if (queryIndex < include.Queries.Length - 1)
                                includeQueriesEnumerator.MoveNext();
                        }
                        if (loadIncludeQuery)
                            includeValues.Add(path, values);
                        if (parentEntities != null)
                            include.Load(parentEntities, values, mergeOption);                        
                    }
                    else
                    {
                        values = includeValues[path];
                        for (int queryIndex = 0; queryIndex < include.Queries.Length; queryIndex++)
                        {
                            var includeQuery = includeQueriesEnumerator.Current;
                            var value = values == null ? null : values[queryIndex];
                            LoadIncludes(includeQuery, value, includes, result, mergeOption, ref index, includeValues, path);
                            if (queryIndex < include.Queries.Length - 1)
                                includeQueriesEnumerator.MoveNext();
                        }
                    }
                }
            }
        }
    
        protected virtual object InstanciateAndAttach(IAsyncQueryableBase query, NorthwindQueryResult queryResult, MergeOption mergeOption)
        {
            Func<object, Type, object> getEntity = null;
            getEntity = (value, type) =>
                {
                    WAQSWorkshopClient.Customer valueAsCustomer;
                    if ((valueAsCustomer = (value as WAQSWorkshopClient.Customer)) != null)
                        return GetEntity(valueAsCustomer, false, mergeOption);
                    var valueAsCustomers = value as IEnumerable<WAQSWorkshopClient.Customer>;
                    if (valueAsCustomers != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.Customer>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsCustomers.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsCustomers = valueAsCustomers.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsCustomers.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.Customer>))
                            return new TrackableCollection<WAQSWorkshopClient.Customer>(valueAsCustomers);
                        return valueAsCustomers.ToList();
                    }
                    WAQSWorkshopClient.Employee valueAsEmployee;
                    if ((valueAsEmployee = (value as WAQSWorkshopClient.Employee)) != null)
                        return GetEntity(valueAsEmployee, false, mergeOption);
                    var valueAsEmployees = value as IEnumerable<WAQSWorkshopClient.Employee>;
                    if (valueAsEmployees != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.Employee>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsEmployees.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsEmployees = valueAsEmployees.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsEmployees.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.Employee>))
                            return new TrackableCollection<WAQSWorkshopClient.Employee>(valueAsEmployees);
                        return valueAsEmployees.ToList();
                    }
                    WAQSWorkshopClient.InvoiceDetail valueAsInvoiceDetail;
                    if ((valueAsInvoiceDetail = (value as WAQSWorkshopClient.InvoiceDetail)) != null)
                        return GetEntity(valueAsInvoiceDetail, false, mergeOption);
                    var valueAsInvoiceDetails = value as IEnumerable<WAQSWorkshopClient.InvoiceDetail>;
                    if (valueAsInvoiceDetails != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.InvoiceDetail>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsInvoiceDetails.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsInvoiceDetails = valueAsInvoiceDetails.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsInvoiceDetails.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.InvoiceDetail>))
                            return new TrackableCollection<WAQSWorkshopClient.InvoiceDetail>(valueAsInvoiceDetails);
                        return valueAsInvoiceDetails.ToList();
                    }
                    WAQSWorkshopClient.Invoice valueAsInvoice;
                    if ((valueAsInvoice = (value as WAQSWorkshopClient.Invoice)) != null)
                        return GetEntity(valueAsInvoice, false, mergeOption);
                    var valueAsInvoices = value as IEnumerable<WAQSWorkshopClient.Invoice>;
                    if (valueAsInvoices != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.Invoice>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsInvoices.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsInvoices = valueAsInvoices.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsInvoices.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.Invoice>))
                            return new TrackableCollection<WAQSWorkshopClient.Invoice>(valueAsInvoices);
                        return valueAsInvoices.ToList();
                    }
                    WAQSWorkshopClient.OrderDetail valueAsOrderDetail;
                    if ((valueAsOrderDetail = (value as WAQSWorkshopClient.OrderDetail)) != null)
                        return GetEntity(valueAsOrderDetail, false, mergeOption);
                    var valueAsOrderDetails = value as IEnumerable<WAQSWorkshopClient.OrderDetail>;
                    if (valueAsOrderDetails != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.OrderDetail>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsOrderDetails.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsOrderDetails = valueAsOrderDetails.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsOrderDetails.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.OrderDetail>))
                            return new TrackableCollection<WAQSWorkshopClient.OrderDetail>(valueAsOrderDetails);
                        return valueAsOrderDetails.ToList();
                    }
                    WAQSWorkshopClient.Order valueAsOrder;
                    if ((valueAsOrder = (value as WAQSWorkshopClient.Order)) != null)
                        return GetEntity(valueAsOrder, false, mergeOption);
                    var valueAsOrders = value as IEnumerable<WAQSWorkshopClient.Order>;
                    if (valueAsOrders != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.Order>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsOrders.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsOrders = valueAsOrders.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsOrders.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.Order>))
                            return new TrackableCollection<WAQSWorkshopClient.Order>(valueAsOrders);
                        return valueAsOrders.ToList();
                    }
                    WAQSWorkshopClient.Product valueAsProduct;
                    if ((valueAsProduct = (value as WAQSWorkshopClient.Product)) != null)
                        return GetEntity(valueAsProduct, false, mergeOption);
                    var valueAsProducts = value as IEnumerable<WAQSWorkshopClient.Product>;
                    if (valueAsProducts != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.Product>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsProducts.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsProducts = valueAsProducts.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsProducts.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.Product>))
                            return new TrackableCollection<WAQSWorkshopClient.Product>(valueAsProducts);
                        return valueAsProducts.ToList();
                    }
                    WAQSWorkshopClient.Category valueAsCategory;
                    if ((valueAsCategory = (value as WAQSWorkshopClient.Category)) != null)
                        return GetEntity(valueAsCategory, false, mergeOption);
                    var valueAsCategories = value as IEnumerable<WAQSWorkshopClient.Category>;
                    if (valueAsCategories != null)
                    {
                        var ctor = value.GetType().GetConstructor(new Type[] { typeof(IEnumerable<WAQSWorkshopClient.Category>) });
                        if (ctor != null)
                            return ctor.Invoke(new object[] { valueAsCategories.Select(e => GetEntity(e, false, mergeOption)) });
                        valueAsCategories = valueAsCategories.Select(e => GetEntity(e, false, mergeOption));
                        if (type.IsArray)
                            return valueAsCategories.ToArray();
                        if (type == typeof(TrackableCollection<WAQSWorkshopClient.Category>))
                            return new TrackableCollection<WAQSWorkshopClient.Category>(valueAsCategories);
                        return valueAsCategories.ToList();
                    }
                    if (type == typeof(string))
                        return value;
                    if (type == typeof(byte[]))
                        return value;
                    Type iEnumerable = null;
                    if (type.IsArray || type.IsGenericType && (iEnumerable = type).GetGenericTypeDefinition().Name == "IEnumerable`1" && type.GetGenericTypeDefinition().Namespace == "System.Collections.Generic" || (iEnumerable = type.GetInterfaces().FirstOrDefault(i => i.Name == "IEnumerable`1" && i.Namespace == "System.Collections.Generic")) != null)
                        return ((object[])value).Select(v => getEntity(v, iEnumerable == null ? iEnumerable.GetGenericArguments()[0] : type.GetElementType())).ToArray();
                    return value;
                };
            Func<string, Type, object> readFromSerialization = (serializedValue, type) =>
                {
                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(serializedValue)))
                    {
                        var dataContractSerializer = new DataContractSerializer(type);
                        var value = dataContractSerializer.ReadObject(stream);
                        return getEntity(value, type);
                    }
                };
            Func<QueryResultRecord, Type, object> instanciateAndAttach = null;
            instanciateAndAttach = (record, type) =>
                {
                    if (record == null)
                        return null;
                    if (record.SerializedValue != null)
                        return readFromSerialization(record.SerializedValue, type);
                    ConstructorInfo ctor;
                    Func<QueryResultProperty, Type, object> instanciateWithConstructorWithParameters = (property, propertyType) => 
                    {
                        if (property.SerializedValue != null)
                            return readFromSerialization(property.SerializedValue, propertyType);
                        if (property.Value != null)
                            return instanciateAndAttach(property.Value, propertyType);
                        if (property.Values != null)
                        {
                            if (propertyType.IsArray)
                            {
                                Type propertyArrayType = propertyType.GetElementType();
                                var cast = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(propertyArrayType);
                                var toArray = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(propertyArrayType);
                                return toArray.Invoke(null, new object[] { cast.Invoke(null, new object[] { property.Values.Select(v => instanciateAndAttach(v, propertyType.GetElementType())) }) });
                            }
                            else if (propertyType.IsGenericType && propertyType.GetGenericArguments().Length == 1)
                            {
                                Type propertyListType = propertyType.GetGenericArguments()[0];
                                var cast = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(propertyListType);
                                var value = cast.Invoke(null, new object[] { property.Values.Select(v => instanciateAndAttach(v, propertyListType)) });
                                ConstructorInfo collectionCtor;
                                ParameterInfo[] parametersInfo;
                                Type parameterType;
                                if ((collectionCtor = propertyType.GetConstructors().FirstOrDefault(c => (parametersInfo = c.GetParameters()).Length == 1 && (parameterType = parametersInfo[0].ParameterType).IsGenericType && parameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>))) != null)
                                    return collectionCtor.Invoke(new object[] { value });
                                if (propertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                    return value; 
                            }
                        }
                        return null;
                    };
                    if (type.Name.StartsWith("<>f__AnonymousType"))
                    {
                        ctor = type.GetConstructors().First();
                        object[] parameters = record.Properties.Select((property, index) => instanciateWithConstructorWithParameters(property, type.GetProperties()[index].PropertyType)).ToArray();
                        return ctor.Invoke(parameters);
                    }
                    else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IGrouping<,>))
                    {
                        ctor = typeof(Grouping<,>).MakeGenericType(type.GetGenericArguments()).GetConstructors().First();
                        object[] parameters = new object[] { instanciateWithConstructorWithParameters(record.Properties[0], type.GetGenericArguments()[0]), instanciateWithConstructorWithParameters(record.Properties[1], typeof(List<>).MakeGenericType(type.GetGenericArguments()[1])) };
                        return ctor.Invoke(parameters);
                    }
                    else if ((ctor = type.GetConstructor(new Type[0])) != null)
                    {
                        var value = ctor.Invoke(new object[0]);
                        for (int rpi = 0 ; rpi < record.Properties.Count ; rpi++)
                        {
    						var recordProperty = record.Properties[rpi];
                            var prop = type.GetProperty(recordProperty.PropertyName);
                            prop.SetValue(value, instanciateWithConstructorWithParameters(recordProperty, prop.PropertyType), null);
                        }
                        return value;
                    }
                    throw new NotImplementedException();
                };
    
            return InstanciateAndAttach(() =>
                {
                    if (queryResult.Value != null)
                        return getEntity(queryResult.Value, query.Type);
                    if (queryResult.Values != null)
                        return ((IEnumerable)queryResult.Values).Cast<object>().Select(o => o == null ? null : getEntity(o, query.Type)).ToList();
                    if (queryResult.Record != null)
                        return instanciateAndAttach(queryResult.Record, query.Type);
                    if (queryResult.Records != null)
                        return queryResult.Records.Select(r => instanciateAndAttach(r, query.Type)).ToList();
                    return null;
                }, mergeOption);
        }
    
        protected virtual object InstanciateAndAttach(Func<object> getValue, MergeOption? mergeOption)
        {
            return getValue();
        }
    
        partial void CustomCatchException(Exception e, ref bool catched);
        protected virtual void CatchException(Exception e, ref bool catched)
        {
            CustomCatchException(e, ref catched);
        }
    
    	private List<KeyValuePair<Type, Func<PropertyDescriptor>>> _customPropertyDescriptors;
    	protected List<KeyValuePair<Type, Func<PropertyDescriptor>>> CustomPropertyDescriptors
    	{
    		get { return _customPropertyDescriptors ?? (_customPropertyDescriptors = new List<KeyValuePair<Type,Func<PropertyDescriptor>>>()); }
    	}
    	public void AddProperty<T>(string name, object value)
    		where T : IBindableObject, IDynamicType
    	{
    		CustomPropertyDescriptors.Add(new KeyValuePair<Type, Func<PropertyDescriptor>>(typeof(T), () => new DynamicType<T>.CustomPropertyDescriptor<object>(name, value)));
    	}
    	public void AddProperty<T, PropertyT>(string name, Func<T, PropertyT> get, Action<T, PropertyT> set = null, string[] properties = null)
    		where T : IBindableObject, IDynamicType
    	{
    		CustomPropertyDescriptors.Add(new KeyValuePair<Type, Func<PropertyDescriptor>>(typeof(T), () => new DynamicType<T>.CustomPropertyDescriptor<PropertyT>(name, get, set, properties)));
    	}
    
    	protected virtual void AddPropertyDescriptorToEntity(object entity)
    	{
    		var dynamicType = entity as IDynamicType;
    		if (dynamicType != null && _customPropertyDescriptors != null)
    			foreach (var propertyDescriptor in _customPropertyDescriptors.Where(cpd => cpd.Key.IsAssignableFrom(entity.GetType())))
    					dynamicType.AddOrReplacePropertyDescriptor(propertyDescriptor.Value());
    	}
    
    	protected virtual void RemovePropertyDescriptorToEntity(object entity)
    	{
    		var dynamicType = entity as IDynamicType;
    		if (dynamicType != null && _customPropertyDescriptors != null)
    			foreach (var propertyDescriptor in _customPropertyDescriptors.Where(cpd => cpd.Key.IsAssignableFrom(entity.GetType())))
    				dynamicType.RemovePropertyDescriptor(propertyDescriptor.Value());
    	}
    	
    
        IExpressionTransformer IClientContextBase.GetTransformer()
        {
            return new NorthwindExpressionTransformer();
        }
    
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected bool IsDisposed { get; set; }
        protected abstract void Dispose(bool disposing);
    }
}
