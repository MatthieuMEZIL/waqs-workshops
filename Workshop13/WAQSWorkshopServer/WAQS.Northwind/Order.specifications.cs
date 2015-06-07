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
    partial class Order
    {
        [Specifications]
        public bool GetHasInvoice()
        {
            return this.Invoice != null;
        }

        [Specifications]
        public Error ValidateOrderHasOrderLines()
        {
            if (ChangeTracker == null)
                return default (Error);
            if (!(ChangeTracker.State == ObjectState.Added))
                return null;
            if (this.OrderDetails == null)
                return default (Error);
            if (!this.OrderDetails.Any())
            {
                var @value = new Error
                {
                Criticity = Criticity.Error, Message = "Order must have detail", ErrorDetails = new ErrorDetail[]
                {
                new ErrorDetail
                {
                EntityKey = DataTransferEntityKey, PropertyName = "OrderDetails"
                }
                }

                , Key = "ValidateOrderHasOrderLines"
                }

                ;
                if (@value == null)
                    return default (Error);
                @value.Key = "ValidateOrderHasOrderLines";
                return @value;
            }

            return null;
        }

        [DataContract(Namespace = "http://Northwind/Entities")]
        public partial class OrderSpecifications
        {
            [DataMember]
            public double Total
            {
                get;
                set;
            }

            [DataMember]
            public bool HasTotal
            {
                get;
                set;
            }

            [DataMember]
            public string CustomerCompanyName
            {
                get;
                set;
            }

            [DataMember]
            public bool HasCustomerCompanyName
            {
                get;
                set;
            }

            [DataMember]
            public string CustomerContactName
            {
                get;
                set;
            }

            [DataMember]
            public bool HasCustomerContactName
            {
                get;
                set;
            }

            [DataMember]
            public bool HasInvoice
            {
                get;
                set;
            }

            [DataMember]
            public bool HasHasInvoice
            {
                get;
                set;
            }
        }

        [DataMember]
        public OrderSpecifications Specifications
        {
            get;
            set;
        }

        protected OrderSpecifications GetSpecifications()
        {
            return Specifications ?? (Specifications = GetSpecificationsOrder());
        }

        protected virtual OrderSpecifications GetSpecificationsOrder()
        {
            return new OrderSpecifications();
        }

        [Specifications]
        public bool HasInvoice
        {
            get
            {
                return GetSpecifications().HasHasInvoice ? GetSpecifications().HasInvoice : GetHasInvoice();
            }

            set
            {
                GetSpecifications().HasInvoice = value;
                GetSpecifications().HasHasInvoice = true;
            }
        }

        [Specifications]
        public double Total
        {
            get
            {
                return GetSpecifications().HasTotal ? GetSpecifications().Total : GetTotal();
            }

            set
            {
                GetSpecifications().Total = value;
                GetSpecifications().HasTotal = true;
            }
        }

        [Specifications]
        public double GetTotal()
        {
            if (this.OrderDetails == null)
                return default (double);
            return this.OrderDetails.Sum(od =>
            {
                if (od == null)
                    return default (double);
                return od.GetAmount();
            }

            );
        }

        public virtual IEnumerable<Error> ValidateOutTransaction(bool onlyError = true)
        {
            Error error;
            if ((error = ValidateOrderHasOrderLines()) != null)
                yield return error;
        }

        [Specifications]
        public string GetCustomerContactName()
        {
            if (this.Customer == null)
                return default (string);
            return this.Customer.ContactName;
        }

        [Specifications]
        public string CustomerCompanyName
        {
            get
            {
                return GetSpecifications().HasCustomerCompanyName ? GetSpecifications().CustomerCompanyName : GetCustomerCompanyName();
            }

            set
            {
                GetSpecifications().CustomerCompanyName = value;
                GetSpecifications().HasCustomerCompanyName = true;
            }
        }

        [Specifications]
        public string GetCustomerCompanyName()
        {
            if (this.Customer == null)
                return default (string);
            return this.Customer.CompanyName;
        }

        [Specifications]
        public string CustomerContactName
        {
            get
            {
                return GetSpecifications().HasCustomerContactName ? GetSpecifications().CustomerContactName : GetCustomerContactName();
            }

            set
            {
                GetSpecifications().CustomerContactName = value;
                GetSpecifications().HasCustomerContactName = true;
            }
        }
    }
}
            