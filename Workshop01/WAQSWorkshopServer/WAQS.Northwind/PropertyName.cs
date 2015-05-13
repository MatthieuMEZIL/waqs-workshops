//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace WAQS.Common
{
    public static class PropertyName
    {
        public static string GetPropertyName(LambdaExpression exp)
        {
            var memberExpression = exp.Body as MemberExpression;
            var sb = new StringBuilder();
            GetPropertyName(memberExpression, sb);
            return sb.ToString();
        }
    
        private static bool GetPropertyName(MemberExpression exp, StringBuilder sb)
        {
            if (exp == null || exp.Expression == null || exp.Member.MemberType != MemberTypes.Property)
                return false;
            if (GetPropertyName(exp.Expression as MemberExpression, sb))
                sb.Append(".");
            sb.Append(exp.Member.Name);
            return true;
        }
    
        public static string GetPropertyName<T>(Expression<Func<T>> exp)
        {
            return GetPropertyName((LambdaExpression)exp);
        }
    
        public static string GetPropertyName<T1, T2>(Expression<Func<T1, T2>> exp)
        {
            return GetPropertyName((LambdaExpression)exp);
        }
    }
}
