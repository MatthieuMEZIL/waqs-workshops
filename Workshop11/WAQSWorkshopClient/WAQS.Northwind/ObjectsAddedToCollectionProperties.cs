//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System.Runtime.Serialization;

namespace WAQS.EntitiesTracking
{
    [CollectionDataContract(Name = "ObjectsAddedToCollectionProperties", Namespace = "http://WAQS/EntityTracking", ItemName = "AddedObjectsForProperty", KeyName = "CollectionPropertyName", ValueName = "AddedObjects")]
    public class ObjectsAddedToCollectionProperties : ObservableDictionary<string, ObjectList>
    {
    }
}
