//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace WAQS.ClientContext.Interfaces.ExpressionSerialization
{
    [DataContract(Namespace = "http://WAQS/QuerySerialization", IsReference = true)]
    public class SerializableBinaryExpression : SerializableExpression
    {
        public SerializableBinaryExpression()
        {
        }
        public SerializableBinaryExpression(SerializableExpression left, SerializableExpression right, ExpressionType nodeType)
            : this(left, right, Enum.GetName(typeof(ExpressionType), nodeType))
        {
        }
        public SerializableBinaryExpression(SerializableExpression left, SerializableExpression right, string nodeType)
        {
            Left = left;
            Right = right;
            NodeType = nodeType;
        }
    
        [DataMember]
        public SerializableExpression Left { get; set; }
        [DataMember]
        public SerializableExpression Right { get; set; }
        [DataMember]
        public string NodeType { get; set; }
    
        protected internal override SerializableExpression Visit(SerializableExpressionRewriter rewriter)
        {
            return rewriter.VisitBinary(this);
        }
    }
}
