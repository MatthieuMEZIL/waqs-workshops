//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WAQS.EntitiesTracking
{
    public partial interface IEntityCollection<T> : ICollection<T>, INotifyCollectionChanged, IList
    {
    	void Attach(T item, bool attaching = false);
    	void Detach(T item);
    }
}
