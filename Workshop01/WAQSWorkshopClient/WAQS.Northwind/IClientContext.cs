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
using WAQS.EntitiesTracking;
using WAQS.ClientContext.Interfaces.Errors;

namespace WAQS.ClientContext.Interfaces
{
    public interface IClientContext : IClientContextBase
    {
        MergeOption MergeOption { get; set; }
        IAsyncQueryable<T> GetClientEntitySetAsyncQueryable<T>(ParameterMode? parameterMode = null) where T : IObjectWithChangeTracker;
        IEnumerable<Error> ValidateOnClient();
        Task SaveChangesAsync(bool validate = false);
        void AcceptChanges();
        bool HasChanges { get; }
        void SavingChanges(bool validate = false);
        ISerializableContext GetModifiedEntities();
        ISerializableContext GetSerializableContext(ISerializableContext modifiedEntities);
        Task<ISerializableContext> TrySavingAsync(Func<Task<ISerializableContext>> saveChangesAsync);
        void Refresh(ISerializableContext originalSerializableContext, ISerializableContext newSerializableContext);
        void SavedChanges();
    }
    
    public interface IClientContext<TClientContext> : IClientContext
        where TClientContext : IClientContext<TClientContext>
    {
        IClientEntitySet<TClientContext, TEntity> GetClientEntitySet<TEntity>()
            where TEntity : IObjectWithChangeTracker;
    }
}
