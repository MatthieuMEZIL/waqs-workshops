//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WAQS.Common;
using WAQS.Entities;

namespace WAQS.DAL.Interfaces
{
    public class WAQSQueryProvider : IQueryProvider
    {
        private IDataContext _dataContext;
        
        public WAQSQueryProvider(IDataContext dataContext, IQueryProvider sourceProvider, IAsyncQueryProviderFactory asyncQueryProviderFactory, Func<Expression, Expression> expressionTransformation)
        {
            _dataContext = dataContext;
            WAQSQueryProvider waqsQueryProvider;
            while ((waqsQueryProvider = sourceProvider as WAQSQueryProvider) != null)
                sourceProvider = waqsQueryProvider.SourceProvider;
            SourceProvider = sourceProvider;
            AsyncQueryProviderFactory = asyncQueryProviderFactory;
            ExpressionTransformation = expressionTransformation;
        }
                         
        internal IQueryProvider SourceProvider { get; private set; }
        public IAsyncQueryProviderFactory AsyncQueryProviderFactory { get; private set; }
        public Func<Expression, Expression> ExpressionTransformation { get; private set; }   
                                
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new WAQSQuery<TElement>(_dataContext, SourceProvider.CreateQuery<TElement>(expression), AsyncQueryProviderFactory, ExpressionTransformation);
        }
                                
        public IQueryable CreateQuery(Expression expression)
        {
            return new WAQSQuery(_dataContext, SourceProvider.CreateQuery(expression), AsyncQueryProviderFactory, ExpressionTransformation);
        }
                        
        private TResult Execute<TResult>(Expression expression, Func<Expression, TResult> execute, Func<TResult, TResult> fromWith = null)
        {
            bool fromQuery = EntitiesInitializer.FromQuery;
            if (! fromQuery)
                EntitiesInitializer.FromQuery = true;
            var result = execute(expression);
            if (fromWith != null)
                result = fromWith(result);
            if (!fromQuery)
            {
                if (!(CurrentQuery == null || CurrentQuery.QueryableIncludes == null))
                    WAQSQuery.LoadIncludes(CurrentQuery, value: new TResult[] { result }, withValue: true);
                EntitiesInitializer.FromQuery = false;
            }
            return result;
        }
                            
        public TResult Execute<TResult>(Expression expression)
        {
            Func<TResult, TResult> fromWith = null;
            if (CurrentQuery != null && CurrentQuery.WithSpecifications != null && CurrentQuery.WithSpecifications.Any())
            {
                var query = ((WAQSQuery)CurrentQuery).ApplyWith();
                expression = Expression.Call(typeof(Queryable).GetMethods().First(m => m.Name == ((MethodCallExpression)expression).Method.Name && m.GetParameters().Length == 1).MakeGenericMethod(typeof(TResult)), query.Expression);
                fromWith = item =>
                {
                    WithType withType;
                    if (WAQSQuery.WithTypes.TryGetValue(typeof (TResult), out withType))
                        item = (TResult)withType.TransformToOriginalType(item);
                    return item;
                };
            }
            return Execute<TResult>(expression, e => SourceProvider.Execute<TResult>(e), fromWith);
        }
                                    
        public object Execute(Expression expression)
        {
            return Execute<object>(expression, e => SourceProvider.Execute(e));
        }
                        
        public IWAQSQuery CurrentQuery { get; set; }
                        
        private async Task<TResult> ExecuteAsync<TResult>(Expression expression, Func<Expression, Task<TResult>> executeAsync, Func<TResult, TResult> fromWith = null)
        {
            try
            {
                EntitiesInitializer.FromQuery = true;
                var result = await executeAsync(expression);
                EntitiesInitializer.FromQuery = false;
                if (fromWith != null)
                    result = fromWith(result);
                if (!(CurrentQuery == null || CurrentQuery.FromQuery || CurrentQuery.QueryableIncludes == null))
                    await WAQSQuery.LoadIncludesAsync(CurrentQuery, value: new TResult[] {result}, withValue: true);
                return result;
            }
            finally
            {
                EntitiesInitializer.FromQuery = false;
            }
        }
                            
        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            Func<TResult, TResult> fromWith = null;
            if (CurrentQuery != null && CurrentQuery.WithSpecifications != null && CurrentQuery.WithSpecifications.Any())
            {
                var query = ((WAQSQuery)CurrentQuery).ApplyWith();
                expression = Expression.Call(typeof(Queryable).GetMethods().First(m => m.Name == ((MethodCallExpression)expression).Method.Name && m.GetParameters().Length == 1).MakeGenericMethod(typeof(TResult)), query.Expression);
                fromWith = item =>
                {
                    WithType withType;
                    if (WAQSQuery.WithTypes.TryGetValue(typeof (TResult), out withType))
                        item = (TResult)withType.TransformToOriginalType(item);
                    return item;
                };
            }
            return ExecuteAsync<TResult>(expression, e => AsyncQueryProviderFactory.ExecuteAsync<TResult>(SourceProvider, e, cancellationToken), fromWith);
        }
                                    
        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExecuteAsync<object>(expression, e => AsyncQueryProviderFactory.ExecuteAsync(SourceProvider, e, cancellationToken));
        }
    }
}
