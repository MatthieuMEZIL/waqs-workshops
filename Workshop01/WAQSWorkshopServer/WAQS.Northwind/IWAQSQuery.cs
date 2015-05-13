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
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WAQS.DAL.Interfaces
{
    public interface IWAQSQuery : IWAQSQueryBase, IQueryable, IOrderedQueryable
    {
        IAsyncQueryProviderFactory AsyncQueryProviderFactory { get; }
        Task ForeachAsync(Action<object> action, CancellationToken cancellationToken = default(CancellationToken));
    }
    public interface IWAQSQuery<out T> : IWAQSQuery, IQueryable<T>, IOrderedQueryable<T>
    {
        Task ForeachAsync(Action<T> action, CancellationToken cancellationToken = default(CancellationToken));
    }
}
