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
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WAQS.DAL.Interfaces
{
    public class WAQSQueryValue : IWAQSQueryValue
    {
        public WAQSQueryValue(IWAQSQueryValue waqsQueryValue)
            : this(waqsQueryValue.WAQSQueryProvider, waqsQueryValue.DataContext, waqsQueryValue.Expression)
        {
        }	
        public WAQSQueryValue(WAQSQueryProvider waqsQueryProvider, IDataContext dataContext, Expression expression)
        {
            WAQSQueryProvider = waqsQueryProvider;
            DataContext = dataContext;
            Expression = expression;
        }
        
        private static Dictionary<Type, Type> _withTypes;
        protected internal static Dictionary<Type, Type> WithTypes
        {
            get { return _withTypes ?? (_withTypes = new Dictionary<Type, Type>()); }
        }
    
        public WAQSQueryProvider WAQSQueryProvider { get; private set; }
        public IDataContext DataContext { get; private set; }
        public Expression Expression { get; private set; }
        public IEnumerable<Func<IWAQSQueryBase, QueryableInclude>> QueryableIncludes { get; set; }
        public IEnumerable<string> WithSpecifications { get; set; }
        public Func<Expression, Expression> ExpressionTransformation
        {
            get { return WAQSQueryProvider.ExpressionTransformation; }
        }
        public bool FromQuery { get; set; }
    
        public object Execute()
        {
            return WAQSQueryProvider.Execute(Expression);
        }
    
        public Task<object> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return WAQSQueryProvider.ExecuteAsync(Expression, cancellationToken);
        }
    }
    public class WAQSQueryValue<T> : WAQSQueryValue, IWAQSQueryValue<T>
    {
        public WAQSQueryValue(IWAQSQueryValue<T> waqsQueryValue)
            : this(waqsQueryValue.WAQSQueryProvider, waqsQueryValue.DataContext, waqsQueryValue.Expression)
        {
        }	
        public WAQSQueryValue(WAQSQueryProvider waqsQueryProvider, IDataContext dataContext, Expression expression)
            : base(waqsQueryProvider, dataContext, expression)
        {
        }
    
        public new T Execute()
        {
            return WAQSQueryProvider.Execute<T>(Expression);
        }
    
        public new Task<T> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return WAQSQueryProvider.ExecuteAsync<T>(Expression, cancellationToken);
        }
    }
}
