//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;

namespace WAQS.EntitiesTracking
{
    public static class ObjectWithChangeTrackerExtensions
    {
    	public static T MarkAsDeleted<T>(this T trackingItem) where T : class, IObjectWithChangeTracker
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    
    		trackingItem.ChangeTracker.ChangeTrackingEnabled = true;
    		trackingItem.ChangeTracker.State = ObjectState.Deleted;
    		return trackingItem;
    	}
    
    	public static T MarkAsCascadeDeleted<T>(this T trackingItem) where T : class, IObjectWithChangeTracker
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    
    		trackingItem.ChangeTracker.ChangeTrackingEnabled = true;
    		trackingItem.ChangeTracker.State = ObjectState.CascadeDeleted;
    		return trackingItem;
    	}
    
    	public static T MarkAsAdded<T>(this T trackingItem) where T : class, IObjectWithChangeTracker
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    	
    		trackingItem.ChangeTracker.ChangeTrackingEnabled = true;
    		trackingItem.ChangeTracker.State = ObjectState.Added;
    		return trackingItem;
    	}
    	
    	public static T MarkAsUnchanged<T>(this T trackingItem) where T : class, IObjectWithChangeTracker
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    	
    		trackingItem.ChangeTracker.ChangeTrackingEnabled = true;
    		trackingItem.ChangeTracker.State = ObjectState.Unchanged;
    		return trackingItem;
    	}
    	
    	public static void StartTracking(this IObjectWithChangeTracker trackingItem)
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    	
    		trackingItem.ChangeTracker.ChangeTrackingEnabled = true;
    	}
    	
    	public static void StopTracking(this IObjectWithChangeTracker trackingItem)
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    	
    		trackingItem.ChangeTracker.ChangeTrackingEnabled = false;
    	}
    	
    	public static void AcceptChanges(this IObjectWithChangeTracker trackingItem)
    	{
    		if (trackingItem == null)
    			throw new ArgumentNullException("trackingItem");
    	
    		trackingItem.ChangeTracker.AcceptChanges();
    	}
    }
}
