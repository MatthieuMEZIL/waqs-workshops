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

namespace WAQS.SerializableExpressions
{
    [DataContract(Namespace = "http://WAQS/QuerySerialization", IsReference = true)]
    [KnownType(typeof(int))]
    [KnownType(typeof(uint))]
    [KnownType(typeof(short))]
    [KnownType(typeof(ushort))]
    [KnownType(typeof(byte))]
    [KnownType(typeof(long))]
    [KnownType(typeof(ulong))]
    [KnownType(typeof(decimal))]
    [KnownType(typeof(double))]
    [KnownType(typeof(char))]
    [KnownType(typeof(DateTime))]
    [KnownType(typeof(DateTimeOffset))]
    [KnownType(typeof(TimeSpan))]
    [KnownType(typeof(int?))]
    [KnownType(typeof(uint?))]
    [KnownType(typeof(short?))]
    [KnownType(typeof(ushort?))]
    [KnownType(typeof(byte?))]
    [KnownType(typeof(long?))]
    [KnownType(typeof(ulong?))]
    [KnownType(typeof(decimal?))]
    [KnownType(typeof(double?))]
    [KnownType(typeof(char?))]
    [KnownType(typeof(DateTime?))]
    [KnownType(typeof(DateTimeOffset?))]
    [KnownType(typeof(TimeSpan?))]
    [KnownType(typeof(string))]
    [KnownType(typeof(int[]))]
    [KnownType(typeof(uint[]))]
    [KnownType(typeof(short[]))]
    [KnownType(typeof(ushort[]))]
    [KnownType(typeof(byte[]))]
    [KnownType(typeof(long[]))]
    [KnownType(typeof(ulong[]))]
    [KnownType(typeof(decimal[]))]
    [KnownType(typeof(double[]))]
    [KnownType(typeof(char[]))]
    [KnownType(typeof(DateTime[]))]
    [KnownType(typeof(DateTimeOffset[]))]
    [KnownType(typeof(TimeSpan[]))]
    [KnownType(typeof(int?[]))]
    [KnownType(typeof(uint?[]))]
    [KnownType(typeof(short?[]))]
    [KnownType(typeof(ushort?[]))]
    [KnownType(typeof(byte?[]))]
    [KnownType(typeof(long?[]))]
    [KnownType(typeof(ulong?[]))]
    [KnownType(typeof(decimal?[]))]
    [KnownType(typeof(double?[]))]
    [KnownType(typeof(char?[]))]
    [KnownType(typeof(DateTime?[]))]
    [KnownType(typeof(DateTimeOffset?[]))]
    [KnownType(typeof(TimeSpan?[]))]
    [KnownType(typeof(string[]))]
    public class SerializableConstantExpression : SerializableExpression
    {
        [DataMember]
        public object Value { get; set; }
        [DataMember]
        public SerializableType Type { get; set; }
    
        protected internal override void Visit(SerializableExpressionVisitor visitor)
        {
            visitor.VisitConstant(this);
        }
    }
}
