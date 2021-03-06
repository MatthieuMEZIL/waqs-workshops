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
using System.Threading.Tasks;
using WAQS.ClientContext.Interfaces.ExpressionSerialization;
using WAQS.ClientContext.Interfaces;

namespace WAQS.ClientContext
{
    internal class AsyncQueryableValue<T> : AsyncQueryableBase, IAsyncQueryableValue<T>
    {
        public AsyncQueryableValue(IClientContextBase context, SerializableExpression expression, ParameterMode parameterMode, IEnumerable<Func<IAsyncQueryableBase, AsyncQueryableInclude>> includes = null, IEnumerable<string> withSpecificationsProperties = null, IEnumerable<string> selectedProperties = null)
            : base(context, expression, parameterMode, includes, withSpecificationsProperties, selectedProperties)
        {
        }
    
        public async Task<T> ExecuteAsync(MergeOption? mergeOption = null, Func<bool> cancel = null)
        {
            return await Context.ExecuteQueryAsync<T>(this, mergeOption, cancel);
        }
    
        public override Type Type
        {
            get { return typeof(T); }
        }
    }
}
