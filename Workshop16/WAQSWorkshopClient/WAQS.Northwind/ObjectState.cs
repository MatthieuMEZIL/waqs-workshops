//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Runtime.Serialization;

namespace WAQS.EntitiesTracking
{
    [DataContract(Namespace = "http://WAQS/EntityTracking")]
    [Flags]
    public enum ObjectState
    {
    	[EnumMember]
    	Detached = 0,
    	[EnumMember]
    	Unchanged = 1,
    	[EnumMember]
    	Added = 2,
    	[EnumMember]
    	Modified = 4,
    	[EnumMember]
    	Deleted = 8,
    	[EnumMember]
    	CascadeDeleted = 0x18
    }
}