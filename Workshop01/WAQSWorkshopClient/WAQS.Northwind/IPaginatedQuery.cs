//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Copyright (c) Matthieu MEZIL.  All rights reserved.
// matthieu.mezil@live.fr

 
using System;
using System.ComponentModel;

namespace WAQS.ClientContext.Interfaces
{
    public interface IPaginatedQuery : INotifyPropertyChanged
    {
        int MaxPage { get; }
        int PageIndex { get; set; }
        event Action PageIndexChanged;
    }
}