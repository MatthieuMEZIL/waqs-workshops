//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Collections;
using System.Collections.Generic;
using WAQSWorkshopServer.DAL.Interfaces;

namespace WAQSWorkshopServer.Service.L2E
{
    public partial class NorthwindSerializableExpressionConverter : WAQSWorkshopServer.Service.NorthwindSerializableExpressionConverter
    {
        public NorthwindSerializableExpressionConverter(INorthwindEntities context, NorthwindEntitiesFilters entitiesFilter)
            : base(context, entitiesFilter)
        {
        }
    
        public override Type GetTypeInLINQ(Type type)
        {
            Type resultType = type;
            GetTypeInLINQ(ref resultType);
            if (resultType != type)
                return resultType;
            if (type != typeof(string))
            {
                if (type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type) && type.GetGenericArguments().Length == 1)
                    return typeof(IEnumerable<>).MakeGenericType(type.GetGenericArguments()[0]);
                if (type.IsArray)
                    return typeof(IEnumerable<>).MakeGenericType(type.GetElementType());
            }
            return base.GetTypeInLINQ(type);
        }
        partial void GetTypeInLINQ(ref Type type);
    }
}
