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

namespace WAQS.ClientContext.Interfaces.Errors
{
    public partial class SavingException : ServerException
    {
        public SavingException(IEnumerable<object> entities, string errorType, string errorMessage)
            : base(errorType, errorMessage)
        {
            Entities = entities;
        }
    
        public IEnumerable<object> Entities { get; private set; }
    
        public static SavingException Throw(IEnumerable<object> entities, string errorType, string errorMessage)
        {
            var exception = new SavingException(entities, errorType, errorMessage);
            CustomThrowServerException(exception);
            throw exception;
        }
        protected static void CustomThrowServerException(SavingException exception)
        {
            CustomThrow(exception);
            ServerException.CustomThrowServerException(exception);
        }
        static partial void CustomThrow(ServerException exception);
    }
}
