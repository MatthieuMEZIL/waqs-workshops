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
using WAQS.ClientContext.Interfaces.Querying;

namespace WAQS.ClientContext
{
    internal class AsyncQueryable<T> : AsyncQueryableBase, IAsyncQueryable<T>
    {
        public AsyncQueryable(IClientContextBase context, SerializableExpression expression, ParameterMode parameterMode, IEnumerable<Func<IAsyncQueryableBase, AsyncQueryableInclude>> includes = null, IEnumerable<string> withSpecificationsProperties = null, IEnumerable<string> selectedProperties = null)
            : base(context, expression, parameterMode, includes, withSpecificationsProperties, selectedProperties)
        {
        }
    
        public async Task<IEnumerable<T>> ExecuteAsync(MergeOption? mergeOption = null, Func<bool> cancel = null)
        {
            return await Context.ExecuteQueryAsync<T>(this, mergeOption, cancel);
        }
    
        public async Task<QueryPage<T>> LoadPageAsync(int pageSize, params LoadPageParameter[] identifiers)
        {
            return await LoadPageInternalAsync(pageSize, null, identifiers, null);
        }
    
        public async Task<QueryPage<T>> LoadPageAsync(int pageSize, Func<bool> cancel, params LoadPageParameter[] identifiers)
        {
            return await LoadPageInternalAsync(pageSize, null, identifiers, cancel);
        }
    
        public async Task<QueryPage<T>> LoadPageAsync(int pageSize, MergeOption? mergeOption, params LoadPageParameter[] identifiers)
        {
            return await LoadPageInternalAsync(pageSize, mergeOption, identifiers, null);
        }
    
        public async Task<QueryPage<T>> LoadPageAsync(int pageSize, MergeOption? mergeOption, Func<bool> cancel, params LoadPageParameter[] identifiers)
        {
            return await LoadPageInternalAsync(pageSize, mergeOption, identifiers, cancel);
        }
    
        private async Task<QueryPage<T>> LoadPageInternalAsync(int pageSize, MergeOption? mergeOption, LoadPageParameter[] identifiers, Func<bool> cancel)
        {
            return await Context.LoadPageAsync<T>(pageSize, this, identifiers, mergeOption, cancel);
        }
    
        public async Task<IEnumerable<T>> LoadPageAsync(int pageSize, int pageIndex, MergeOption? mergeOption, Func<bool> cancel = null)
        {
            return await Context.LoadPageAsync(pageSize, this.Skip(pageIndex * pageSize).Take(pageSize), null, mergeOption, cancel);
        }
    
        public override Type Type
        {
            get { return typeof(T); }
        }
    }
}
