//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.Specialized;

namespace WAQS.EntitiesTracking
{
    [CollectionDataContract(Name = "OriginalValuesDictionary", Namespace = "http://WAQS/EntityTracking", ItemName = "OriginalValues", KeyName = "Name", ValueName = "OriginalValue")]
    public class OriginalValuesDictionary : ObservableDictionary<string, object>
    {
    }
}
