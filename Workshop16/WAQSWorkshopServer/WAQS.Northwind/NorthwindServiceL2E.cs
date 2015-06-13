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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WAQSWorkshopServer.DAL.Interfaces;
using WAQSWorkshopServer.Service.Interfaces;
using WAQS.SerializableExpressions;
using WAQS.Service.Interfaces;
using WAQS.Service;

namespace WAQSWorkshopServer.Service
{
    public class NorthwindServiceL2E : NorthwindService
    {
        public NorthwindServiceL2E(Func<INorthwindEntities> contextFactory, Func<INorthwindEntities, ISerializableExpressionProvider> serializableExpressionProviderFactory, Func<NorthwindServiceL2E> serviceFactory)
            : base(contextFactory, serializableExpressionProviderFactory, serviceFactory)
        {
        }
    
        public NorthwindServiceL2E(INorthwindEntities context)
            : base(context, () => new NorthwindServiceL2E(context))
        {
        }
    
        public NorthwindServiceL2E(Func<INorthwindEntities> contextFactory)
            : this(contextFactory, () => new NorthwindServiceL2E(contextFactory))
        {
        }
    
        protected NorthwindServiceL2E(Func<INorthwindEntities> contexFactory, Func<NorthwindServiceL2E> serviceFactory)
            : base (contexFactory, serviceFactory)
        {
        }
    
        public static NorthwindServiceL2E Create<DataContextT>()
            where DataContextT : INorthwindEntities, new()
        {
            return new NorthwindServiceL2E(() => new DataContextT { UseWAQSProvider = true });
        }
    
        public override NorthwindQueryResultPage LoadPage(int pageSize, SerializableExpression querySerializableExpression, IEnumerable<string> withSpecificationsProperties, LoadPageParameter[] identifiersSerializableExpression)
        {
            if (identifiersSerializableExpression.Length == 0)
                throw new InvalidOperationException();
    
            var queryExpression = SerializableExpressionProvider(Context).ToExpression(querySerializableExpression, withSpecificationsProperties);
            Expression exp = Expression.Constant(1);
            var queryType = GetGenericType(queryExpression.Type);
            var parameterExp = Expression.Parameter(queryType);
            foreach (var identifierSerializableExpression in identifiersSerializableExpression.Reverse())
                exp = Expression.Condition(GetLogicalBinaryExpression(parameterExp, queryType, identifierSerializableExpression.Descending ? ExpressionType.GreaterThan : ExpressionType.LessThan, identifierSerializableExpression), Expression.Constant(1), Expression.Condition(GetLogicalBinaryExpression(parameterExp, queryType, identifierSerializableExpression.Descending ? ExpressionType.LessThan : ExpressionType.GreaterThan, identifierSerializableExpression), Expression.Constant(0), exp));
            var provider = ((IQueryable)Context.Customers).Provider;
            int rowIndex = (int)provider.Execute(Expression.Call(typeof(Queryable).GetMethods().First(m => m.Name == "Sum" && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType.GetGenericArguments()[0].GetGenericArguments()[1] == typeof(int)).MakeGenericMethod(new Type[] { queryType }), queryExpression, Expression.Lambda(exp, parameterExp)));
            int pageIndex = rowIndex / pageSize;
            if (rowIndex % pageSize != 0)
                pageIndex++;
            return new NorthwindQueryResultPage { PageIndex = pageIndex - 1, Result = new NorthwindQueryResult { Records = ((IEnumerable)provider.CreateQuery(Expression.Call(typeof(Queryable).GetMethod("Take").MakeGenericMethod(queryType), Expression.Call(typeof(Queryable).GetMethod("Skip").MakeGenericMethod(queryType), queryExpression, Expression.Constant((pageIndex - 1) * pageSize)), Expression.Constant(pageSize)))).Cast<object>().Select(o => GetQueryResult(queryType, o)).ToList()}};
        }
    
        private Expression GetLogicalBinaryExpression(ParameterExpression parameterExp, Type type, ExpressionType expressionType, LoadPageParameter loadPageParameter)
        {
            PropertyInfo prop = type.GetProperty(loadPageParameter.PropertyName);
            Type valueType = prop.PropertyType;
            Expression valueExpression = SerializableExpressionToLINQExpressionConverter.GetConstantExpression(loadPageParameter.Value, valueType);
            Expression propExpression = Expression.MakeMemberAccess(parameterExp, prop);
            bool nullable = false;
            if (valueType == typeof(string))
                switch (expressionType)
                {
                    case ExpressionType.LessThan:
                        return Context.LessThanString(propExpression, valueExpression);
                    case ExpressionType.GreaterThan:
                        return Context.GreaterThanString(propExpression, valueExpression);
                    default:
                        throw new NotImplementedException();
                }
            else if (typeof(Enum).IsAssignableFrom(valueType) || (nullable = valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Nullable<>) && typeof(Enum).IsAssignableFrom(valueType.GetGenericArguments()[0])))
            {
                Type intType = nullable ? typeof(int?) : typeof(int);
                return Expression.MakeBinary(expressionType, Expression.Convert(propExpression, intType), Expression.Convert(valueExpression, intType));
            }
            else
                return Expression.MakeBinary(expressionType, propExpression, valueExpression);
        }
    
        private Expression GetExpression<T>(T value)
        {
            Expression<Func<T>> exp = () => value;
            return exp;
        }
    }
}
