//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WAQS.EntitiesTracking
{
    public class ObservableDictionary<K, T> : Dictionary<K, T>, INotifyCollectionChanged 
    {
    	public new void Add(K key, T value)
    	{
    		base.Add(key, value);
    		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<K, T>(key, value), 0 /*index does not make sense with Dictionary*/));
    	}
    
    	public new void Remove(K key)
    	{
    		base.Remove(key);
    		OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, key, 0 /*index does not make sense with Dictionary*/));
    	}
    
    	public new void Clear()
    	{
    		base.Clear();
    		CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    	}
    
    	protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
    	{
    		if (CollectionChanged != null)
    			CollectionChanged(this, args);
    	}
    	public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
