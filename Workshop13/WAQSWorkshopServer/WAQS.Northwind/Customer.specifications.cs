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
using System.Linq;
using System.Runtime.Serialization;
using WAQS.Entities;
using WAQS.Service.Interfaces;
using WAQS.Specifications;

namespace WAQSWorkshopServer
{
    partial class Customer
    {
        protected virtual Error ValidateRegionIsNullable()
        {
            if (ChangeTracker.State == ObjectState.Added || ChangeTracker.State == ObjectState.Modified && ChangeTracker.ModifiedProperties.Intersect(new[]
            {
            "Region", "Country"
            }

            ).Any())
            {
                bool metadata = this.Country != "USA";
                if (Region == null && !metadata)
                    return new Error
                    {
                    Criticity = Criticity.Mandatory, Key = "RegionIsNullable", Message = Error.GetIsNullableErrorMessage("Region"), ErrorDetails = new ErrorDetail[]
                    {
                    new ErrorDetail
                    {
                    EntityKey = DataTransferEntityKey, PropertyName = "Region"
                    }
                    }
                    }

                    ;
            }

            return null;
        }

        [Specifications]
        public string FullName
        {
            get
            {
                return GetSpecifications().HasFullName ? GetSpecifications().FullName : GetFullName();
            }

            set
            {
                GetSpecifications().FullName = value;
                GetSpecifications().HasFullName = true;
            }
        }

        [Specifications]
        public double GetTotalSpent()
        {
            if (this.Orders == null)
                return default (double);
            return this.Orders.Sum(o =>
            {
                if (o == null)
                    return default (double);
                return o.GetTotal();
            }

            );
        }

        [DataContract(Namespace = "http://Northwind/Entities")]
        public partial class CustomerSpecifications
        {
            [DataMember]
            public double TotalSpent
            {
                get;
                set;
            }

            [DataMember]
            public bool HasTotalSpent
            {
                get;
                set;
            }

            [DataMember]
            public string FullName
            {
                get;
                set;
            }

            [DataMember]
            public bool HasFullName
            {
                get;
                set;
            }
        }

        [DataMember]
        public CustomerSpecifications Specifications
        {
            get;
            set;
        }

        protected CustomerSpecifications GetSpecifications()
        {
            return Specifications ?? (Specifications = GetSpecificationsCustomer());
        }

        protected virtual CustomerSpecifications GetSpecificationsCustomer()
        {
            return new CustomerSpecifications();
        }

        [Specifications]
        public string GetFullName()
        {
            return this.CompanyName + " " + this.ContactName;
        }

        public virtual IEnumerable<Error> ValidateOutTransaction(bool onlyError = true)
        {
            Error error;
            if ((error = ValidateRegionIsNullable()) != null)
                yield return error;
            if ((error = ValidatePostalCodeDefinePattern()) != null)
                yield return error;
        }

        [Specifications]
        public double TotalSpent
        {
            get
            {
                return GetSpecifications().HasTotalSpent ? GetSpecifications().TotalSpent : GetTotalSpent();
            }

            set
            {
                GetSpecifications().TotalSpent = value;
                GetSpecifications().HasTotalSpent = true;
            }
        }

        protected virtual Error ValidatePostalCodeDefinePattern()
        {
            if (ChangeTracker.State == ObjectState.Added || ChangeTracker.State == ObjectState.Modified && ChangeTracker.ModifiedProperties.Intersect(new[]
            {
            "PostalCode", "Country"
            }

            ).Any())
            {
                string metadata = this.Country == "USA" ? "^[0-9]{5}(?:-[0-9]{4})?$" : this.Country == "France" ? @"^(?:\d{2}|(?:2(?:A|B)))\d{3}$" : null;
                if (metadata != null && !System.Text.RegularExpressions.Regex.IsMatch(PostalCode, metadata))
                    return new Error
                    {
                    Criticity = Criticity.Error, Key = "PostalCodeDefinePattern", Message = Error.GetDefinePatternErrorMessage("PostalCode", metadata), ErrorDetails = new ErrorDetail[]
                    {
                    new ErrorDetail
                    {
                    EntityKey = DataTransferEntityKey, PropertyName = "PostalCode"
                    }
                    }
                    }

                    ;
            }

            return null;
        }
    }
}
            