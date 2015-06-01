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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using WAQS.ClientContext;
using WAQS.ClientContext.Interfaces;
using WAQS.ClientContext.Interfaces.Errors;
using WAQS.ComponentModel;
using WAQS.Entities;
using WAQS.EntitiesTracking;

namespace WAQSWorkshopClient
{
    [DataContract(IsReference = true, Namespace = "http://Northwind/Entities")]
    [KnownType(typeof (OrderDetail))]
    public partial class Product : DynamicType, IEntityWithErrors
    {
#region DynamicType
        protected override ICustomTypeDescriptor CustomTypeDescriptor
        {
            get
            {
                return new DynamicType<Product>(this, CustomPropertyDescriptors);
            }
        }

        protected override IEnumerable<CustomPropertyDescriptor> CustomPropertyDescriptors
        {
            get
            {
                return DynamicType<Product>.CustomProperties;
            }
        }

#endregion
#region Simple Properties
        [DataMember]
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                OnIdPropertyChanging(ref value);
                if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                _id = value;
                if (!ChangeTracker.Saving)
                {
                    OnIdPropertyChanged(value);
                    OnPropertyChanged("Id");
                    ResetEntityKey();
                }
            }
        }

        private int _id;
        partial void OnIdPropertyChanging(ref int value);
        partial void OnIdPropertyChanged(int value);
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    if (!(IsDeserializing || ChangeTracker.Saving))
                        ValidateNameRequired(value);
                    return;
                }

                OnNamePropertyChanging(ref value);
                if (!(IsDeserializing || ChangeTracker.Saving))
                {
                    ValidateNameRequired(value);
                    ValidateNameMaxLength(value);
                }

                _name = value;
                if (!ChangeTracker.Saving)
                {
                    OnNamePropertyChanged(value);
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _name;
        partial void OnNamePropertyChanging(ref string value);
        partial void OnNamePropertyChanged(string value);
        protected virtual Error ValidateNameRequired(string value)
        {
            var errorInfo = Validators.ValidateRequiredStringProperty(value, () => Name, DataErrorInfo);
            var error = Errors.Name.FirstOrDefault(e => e.Key == "NameRequired");
            if (errorInfo == null)
            {
                if (error != null)
                    Errors.Name.Remove(error);
                return null;
            }

            if (error == null)
                Errors.Name.Add(error = new MetadataError
                {
                Criticity = Criticity.Mandatory, Key = "NameRequired", Message = errorInfo.Message, ErrorInfo = errorInfo
                }

                );
            return error;
        }

        protected virtual Error ValidateNameMaxLength(string value)
        {
            if (value == null)
                return null;
            var errorInfo = Validators.ValidateStringMaxLength(value, 40, () => Name, DataErrorInfo);
            var error = Errors.Name.FirstOrDefault(e => e.Key == "NameMaxLength");
            if (errorInfo == null)
            {
                if (error != null)
                    Errors.Name.Remove(error);
                return null;
            }

            if (error == null)
                Errors.Name.Add(error = new MetadataError
                {
                Criticity = Criticity.Error, Key = "NameMaxLength", Message = errorInfo.Message, ErrorInfo = errorInfo
                }

                );
            return error;
        }

        [DataMember]
        public Nullable<int> SupplierId
        {
            get
            {
                return _supplierId;
            }

            set
            {
                if (_supplierId == value)
                {
                    return;
                }

                OnSupplierIdPropertyChanging(ref value);
                _supplierId = value;
                if (!ChangeTracker.Saving)
                {
                    OnSupplierIdPropertyChanged(value);
                    OnPropertyChanged("SupplierId");
                }
            }
        }

        private Nullable<int> _supplierId;
        partial void OnSupplierIdPropertyChanging(ref Nullable<int> value);
        partial void OnSupplierIdPropertyChanged(Nullable<int> value);
        [DataMember]
        public Nullable<int> CategoryId
        {
            get
            {
                return _categoryId;
            }

            set
            {
                if (_categoryId == value)
                {
                    return;
                }

                OnCategoryIdPropertyChanging(ref value);
                _categoryId = value;
                if (!ChangeTracker.Saving)
                {
                    OnCategoryIdPropertyChanged(value);
                    OnPropertyChanged("CategoryId");
                }
            }
        }

        private Nullable<int> _categoryId;
        partial void OnCategoryIdPropertyChanging(ref Nullable<int> value);
        partial void OnCategoryIdPropertyChanged(Nullable<int> value);
        [DataMember]
        public string QuantityPerUnit
        {
            get
            {
                return _quantityPerUnit;
            }

            set
            {
                if (_quantityPerUnit == value)
                {
                    return;
                }

                OnQuantityPerUnitPropertyChanging(ref value);
                if (!(IsDeserializing || ChangeTracker.Saving))
                {
                    ValidateQuantityPerUnitMaxLength(value);
                }

                _quantityPerUnit = value;
                if (!ChangeTracker.Saving)
                {
                    OnQuantityPerUnitPropertyChanged(value);
                    OnPropertyChanged("QuantityPerUnit");
                }
            }
        }

        private string _quantityPerUnit;
        partial void OnQuantityPerUnitPropertyChanging(ref string value);
        partial void OnQuantityPerUnitPropertyChanged(string value);
        protected virtual Error ValidateQuantityPerUnitMaxLength(string value)
        {
            if (value == null)
                return null;
            var errorInfo = Validators.ValidateStringMaxLength(value, 20, () => QuantityPerUnit, DataErrorInfo);
            var error = Errors.QuantityPerUnit.FirstOrDefault(e => e.Key == "QuantityPerUnitMaxLength");
            if (errorInfo == null)
            {
                if (error != null)
                    Errors.QuantityPerUnit.Remove(error);
                return null;
            }

            if (error == null)
                Errors.QuantityPerUnit.Add(error = new MetadataError
                {
                Criticity = Criticity.Error, Key = "QuantityPerUnitMaxLength", Message = errorInfo.Message, ErrorInfo = errorInfo
                }

                );
            return error;
        }

        [DataMember]
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                if (_unitPrice == value)
                {
                    return;
                }

                OnUnitPricePropertyChanging(ref value);
                _unitPrice = value;
                if (!ChangeTracker.Saving)
                {
                    OnUnitPricePropertyChanged(value);
                    OnPropertyChanged("UnitPrice");
                }
            }
        }

        private double _unitPrice;
        partial void OnUnitPricePropertyChanging(ref double value);
        partial void OnUnitPricePropertyChanged(double value);
        [DataMember]
        public bool Discontinued
        {
            get
            {
                return _discontinued;
            }

            set
            {
                if (_discontinued == value)
                {
                    return;
                }

                OnDiscontinuedPropertyChanging(ref value);
                _discontinued = value;
                if (!ChangeTracker.Saving)
                {
                    OnDiscontinuedPropertyChanged(value);
                    OnPropertyChanged("Discontinued");
                }
            }
        }

        private bool _discontinued;
        partial void OnDiscontinuedPropertyChanging(ref bool value);
        partial void OnDiscontinuedPropertyChanged(bool value);
#endregion
#region Complex Properties
#endregion
#region Navigation Properties
        [DataMember]
        public TrackableCollection<OrderDetail> OrderDetails
        {
            get
            {
                if (!ChangeTracker.Saving)
                    OnGetOrderDetails();
                if (OnGetOrderDetailsAction != null)
                    OnGetOrderDetailsAction();
                if (_orderDetails == null)
                {
                    _orderDetails = new TrackableCollection<OrderDetail>();
                    SetFixupOrderDetails();
                    OnOrderDetailsPropertyChanging(null, _orderDetails);
                    OnOrderDetailsPropertyChanged(null, _orderDetails);
                }

                return _orderDetails;
            }

            set
            {
                if (ReferenceEquals(_orderDetails, value))
                    return;
                if (ChangeTracker.ChangeTrackingEnabled)
                    throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                var oldOrderDetails = _orderDetails;
                if (_orderDetails != null)
                {
                    _orderDetails.CollectionChanged -= FixupOrderDetails;
                }

                _orderDetails = value;
                if (_orderDetails != null)
                {
                    SetFixupOrderDetails();
                }

                OnOrderDetailsPropertyChanging(oldOrderDetails, _orderDetails);
                OnOrderDetailsPropertyChanged(oldOrderDetails, _orderDetails);
                OnNavigationPropertyChanged("OrderDetails");
            }
        }

        partial void OnGetOrderDetails();
        public Action OnGetOrderDetailsAction
        {
            get;
            set;
        }

        partial void OnOrderDetailsPropertyChanged(TrackableCollection<OrderDetail> oldValue, TrackableCollection<OrderDetail> newValue);
        private TrackableCollection<OrderDetail> _orderDetails;
        private void SetFixupOrderDetails()
        {
            _orderDetails.CollectionChanged += FixupOrderDetails;
            var orderDetailsAsITrackableCollection = (ITrackableCollection<OrderDetail>)_orderDetails;
            orderDetailsAsITrackableCollection.GetWhereExpression = e => e.ProductId == Id;
            orderDetailsAsITrackableCollection.GetClientContext = () =>
            {
                IClientEntitySet clientEntitySet = ClientEntitySetExtensions.GetClientEntitySet(this);
                return clientEntitySet == null || ChangeTracker.State == ObjectState.Detached ? null : clientEntitySet.Context;
            }

            ;
        }

        protected virtual void OnOrderDetailsPropertyChanging(TrackableCollection<OrderDetail> oldValue, TrackableCollection<OrderDetail> newValue)
        {
            if (OrderDetailsPropertyChanging != null)
                OrderDetailsPropertyChanging(oldValue, newValue);
        }

        protected internal event Action<TrackableCollection<OrderDetail>, TrackableCollection<OrderDetail>> OrderDetailsPropertyChanging;
#endregion
#region Specifications
        public virtual IEnumerable<Error> ValidateOnClient(bool force = false)
        {
            if (force || ChangeTracker.State == ObjectState.Added || ChangeTracker.State == ObjectState.Modified && ChangeTracker.ModifiedProperties.Contains("Name"))
            {
                Error error = ValidateNameRequired(Name);
                if (error != null)
                    yield return error;
                error = ValidateNameMaxLength(Name);
                if (error != null)
                    yield return error;
            }

            if (force || ChangeTracker.State == ObjectState.Added || ChangeTracker.State == ObjectState.Modified && ChangeTracker.ModifiedProperties.Contains("QuantityPerUnit"))
            {
                Error error = ValidateQuantityPerUnitMaxLength(QuantityPerUnit);
                if (error != null)
                    yield return error;
            }

            List<Error> errors = null;
            GetCustomValidation(ref errors);
            if (errors != null)
                foreach (var er in errors)
                    yield return er;
        }

        partial void GetCustomValidation(ref List<Error> errors);
#endregion
#region ChangeTracking
        protected virtual void AddValidationProperty(string propertyName)
        {
            if (!ChangeTracker.ValidationProperties.Contains(propertyName))
                ChangeTracker.ValidationProperties.Add(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool isTracked = true)
        {
            if (propertyName != "Id" && isTracked && ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && (ChangeTracker.State & ObjectState.Deleted) == 0)
            {
                if (!(IsDeserializing || ChangeTracker.ModifiedProperties.Contains(propertyName)))
                    ChangeTracker.ModifiedProperties.Add(propertyName);
                ChangeTracker.State = ObjectState.Modified;
            }

            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
            OnPropertyChangedExtension(propertyName);
        }

        partial void OnPropertyChangedExtension(string propertyName);
        protected virtual void OnNavigationPropertyChanged(string propertyName)
        {
            NotifyPropertyChanged.RaisePropertyChanged(propertyName);
            OnNavigationPropertyChangedExtension(propertyName);
            RaiseNavigationPropertyChanged(propertyName);
        }

        partial void OnNavigationPropertyChangedExtension(string propertyName);
        protected virtual void RaiseNavigationPropertyChanged(string propertyName)
        {
            if (NavigationPropertyChanged != null)
                NavigationPropertyChanged(this, propertyName);
        }

        public event Action<Product, string> NavigationPropertyChanged;
        private ObjectChangeTracker _changeTracker;
        [DataMember]
        [Display(AutoGenerateFilter = false, AutoGenerateField = false)]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanged += HandleObjectStateChanged;
                }

                return _changeTracker;
            }

            set
            {
                if (_changeTracker != null)
                    _changeTracker.ObjectStateChanged -= HandleObjectStateChanged;
                _changeTracker = value;
                if (_changeTracker != null)
                    _changeTracker.ObjectStateChanged += HandleObjectStateChanged;
            }
        }

        private void HandleObjectStateChanged(object sender, ObjectStateChangedEventArgs e)
        {
            switch (e.NewState)
            {
                case ObjectState.Deleted:
                case ObjectState.CascadeDeleted:
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        IsDeleting = true;
                        ClearNavigationProperties();
                        IsDeleting = false;
                    }

                    break;
                case ObjectState.Detached:
                    ClearNavigationProperties();
                    break;
            }

            OnStateChanged(e.NewState);
        }

        protected virtual void OnStateChanged(ObjectState state)
        {
            if (StateChanged != null)
                StateChanged(this, state);
        }

        public event Action<IObjectWithChangeTracker, ObjectState> StateChanged;
        private bool _isDeserializing;
        [Display(AutoGenerateFilter = false, AutoGenerateField = false)]
        public bool IsDeserializing
        {
            get
            {
                return _isDeserializing;
            }

            set
            {
                if (_isDeserializing == value)
                    return;
                _isDeserializing = value;
            }
        }

        [Display(AutoGenerateFilter = false, AutoGenerateField = false)]
        public bool IsInitializingRelationships
        {
            get;
            set;
        }

        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }

        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }

        public virtual void MarkAsModified()
        {
            ChangeTracker.ChangeTrackingEnabled = true;
            ChangeTracker.State = ObjectState.Modified;
            ChangeTracker.ModifiedProperties.Add("Id");
            ChangeTracker.ModifiedProperties.Add("Name");
            ChangeTracker.ModifiedProperties.Add("SupplierId");
            ChangeTracker.ModifiedProperties.Add("CategoryId");
            ChangeTracker.ModifiedProperties.Add("QuantityPerUnit");
            ChangeTracker.ModifiedProperties.Add("UnitPrice");
            ChangeTracker.ModifiedProperties.Add("Discontinued");
        }

        protected virtual void ClearNavigationProperties()
        {
            bool isInitializingRelationships = IsInitializingRelationships;
            IsInitializingRelationships = true;
            OrderDetails.Clear();
            IsInitializingRelationships = isInitializingRelationships;
        }

        public bool HasTemporaryKey
        {
            get
            {
                return ChangeTracker.State == ObjectState.Added;
            }
        }

        public virtual bool HasChanges
        {
            get
            {
                return ChangeTracker.State != ObjectState.Unchanged || ChangeTracker.ObjectsRemovedFromCollectionProperties.Any() || ChangeTracker.OriginalValues.Any() || ChangeTracker.ObjectsAddedToCollectionProperties.Any();
            }
        }

        private Guid? _uniqueIdentifier;
        Guid IObjectWithChangeTracker.UniqueIdentifier
        {
            get
            {
                return _uniqueIdentifier ?? (_uniqueIdentifier = Guid.NewGuid()).Value;
            }
        }

#endregion
#region Association Fixup
        private bool IsDeleting
        {
            get;
            set;
        }

        internal virtual void Detach()
        {
            ChangeTracker.State = ObjectState.Detached;
        }

        private void FixupOrderDetails(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing || OrderDetails.IsAttachingOrDetaching)
                return;
            if (e.NewItems != null)
            {
                foreach (OrderDetail item in e.NewItems)
                {
                    bool itemIsInitializingRelationships = item.IsInitializingRelationships;
                    if (IsInitializingRelationships)
                        item.IsInitializingRelationships = true;
                    item.Product = this;
                    if (!(IsInitializingRelationships || item.IsInitializingRelationships) && ChangeTracker.ChangeTrackingEnabled && (ChangeTracker.State == ObjectState.Added || item.ChangeTracker.State == ObjectState.Added || !(ChangeTracker.IsAttaching || item.ChangeTracker.IsAttaching)))
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                            item.MarkAsAdded();
                        ChangeTracker.RecordAdditionToCollectionProperties("OrderDetails", item);
                    }

                    item.IsInitializingRelationships = itemIsInitializingRelationships;
                }
            }

            if (e.OldItems != null)
            {
                foreach (OrderDetail item in e.OldItems)
                {
                    bool itemIsInitializingRelationships = item.IsInitializingRelationships;
                    if (IsInitializingRelationships)
                        item.IsInitializingRelationships = true;
                    if (ReferenceEquals(item.Product, this))
                        item.Product = null;
                    if (ChangeTracker.ChangeTrackingEnabled && !IsInitializingRelationships)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("OrderDetails", item);
                    }

                    item.IsInitializingRelationships = itemIsInitializingRelationships;
                }
            }
        }

#endregion
#region EntityKey
        private Guid? _dataTransferEntityKey;
        [DataMember]
        public virtual Guid DataTransferEntityKey
        {
            get
            {
                return _dataTransferEntityKey ?? (_dataTransferEntityKey = Guid.NewGuid()).Value;
            }

            set
            {
                _dataTransferEntityKey = value;
            }
        }

        private string _entityKey;
        public virtual string EntityKey
        {
            get
            {
                switch (ChangeTracker.State)
                {
                    case ObjectState.Added:
                        if (_entityKey == null)
                            _entityKey = "Product - IdentityKey = " + Guid.NewGuid().ToString();
                        return _entityKey;
                    case ObjectState.Detached:
                        if (_entityKey != null)
                            return _entityKey;
                        if (Id == default (int))
                            goto case ObjectState.Added;
                        break;
                    case ObjectState.Unchanged:
                    case ObjectState.Modified:
                    case ObjectState.CascadeDeleted:
                    case ObjectState.Deleted:
                        _entityKey = null;
                        break;
                }

                return string.Format("Product - Id={0};", Id);
            }

            set
            {
                _entityKey = value;
            }
        }

        public virtual void ResetEntityKey()
        {
            if (!IsDeserializing)
            {
                var previousEntityKey = _entityKey;
                _entityKey = null;
                OnEntityKeyChanged(previousEntityKey);
            }
        }

        protected virtual void OnEntityKeyChanged(string previousEntityKey)
        {
            if (EntityKeyChanged != null)
                EntityKeyChanged(this, previousEntityKey);
        }

        public event Action<Product, string> EntityKeyChanged;
        public virtual bool IsTemporaryKey
        {
            get
            {
                return _entityKey != null;
            }
        }

#endregion
#region Dependences
#endregion
#region UISpecifications
        static Product()
        {
            DynamicType<Product>.AddProperty("IdIsMandatory", e => e.UISpecifications.GetIdIsMandatory(e));
            DynamicType<Product>.AddProperty("IdMinValue", e => e.UISpecifications.GetIdMinValue(e));
            DynamicType<Product>.AddProperty("IdMaxValue", e => e.UISpecifications.GetIdMaxValue(e));
            DynamicType<Product>.AddProperty("NameIsMandatory", e => e.UISpecifications.GetNameIsMandatory(e));
            DynamicType<Product>.AddProperty("NameMaxLength", e => e.UISpecifications.GetNameMaxLength(e));
            DynamicType<Product>.AddProperty("NameMinLength", e => e.UISpecifications.GetNameMinLength(e));
            DynamicType<Product>.AddProperty("NamePattern", e => e.UISpecifications.GetNamePattern(e));
            DynamicType<Product>.AddProperty("SupplierIdIsMandatory", e => e.UISpecifications.GetSupplierIdIsMandatory(e));
            DynamicType<Product>.AddProperty("SupplierIdMinValue", e => e.UISpecifications.GetSupplierIdMinValue(e));
            DynamicType<Product>.AddProperty("SupplierIdMaxValue", e => e.UISpecifications.GetSupplierIdMaxValue(e));
            DynamicType<Product>.AddProperty("CategoryIdIsMandatory", e => e.UISpecifications.GetCategoryIdIsMandatory(e));
            DynamicType<Product>.AddProperty("CategoryIdMinValue", e => e.UISpecifications.GetCategoryIdMinValue(e));
            DynamicType<Product>.AddProperty("CategoryIdMaxValue", e => e.UISpecifications.GetCategoryIdMaxValue(e));
            DynamicType<Product>.AddProperty("QuantityPerUnitIsMandatory", e => e.UISpecifications.GetQuantityPerUnitIsMandatory(e));
            DynamicType<Product>.AddProperty("QuantityPerUnitMaxLength", e => e.UISpecifications.GetQuantityPerUnitMaxLength(e));
            DynamicType<Product>.AddProperty("QuantityPerUnitMinLength", e => e.UISpecifications.GetQuantityPerUnitMinLength(e));
            DynamicType<Product>.AddProperty("QuantityPerUnitPattern", e => e.UISpecifications.GetQuantityPerUnitPattern(e));
            DynamicType<Product>.AddProperty("UnitPriceIsMandatory", e => e.UISpecifications.GetUnitPriceIsMandatory(e));
            DynamicType<Product>.AddProperty("UnitPriceMinValue", e => e.UISpecifications.GetUnitPriceMinValue(e));
            DynamicType<Product>.AddProperty("UnitPriceMaxValue", e => e.UISpecifications.GetUnitPriceMaxValue(e));
            DynamicType<Product>.AddProperty("DiscontinuedIsMandatory", e => e.UISpecifications.GetDiscontinuedIsMandatory(e));
            DynamicType<Product>.AddProperty("AllErrors", e => e.Errors.AllErrors);
            DynamicType<Product>.AddProperty("IdErrors", e => e.Errors.Id);
            DynamicType<Product>.AddProperty("NameErrors", e => e.Errors.Name);
            DynamicType<Product>.AddProperty("SupplierIdErrors", e => e.Errors.SupplierId);
            DynamicType<Product>.AddProperty("CategoryIdErrors", e => e.Errors.CategoryId);
            DynamicType<Product>.AddProperty("QuantityPerUnitErrors", e => e.Errors.QuantityPerUnit);
            DynamicType<Product>.AddProperty("UnitPriceErrors", e => e.Errors.UnitPrice);
            DynamicType<Product>.AddProperty("DiscontinuedErrors", e => e.Errors.Discontinued);
            StaticInitializer();
        }

        static partial void StaticInitializer();
        private UISpecificationsInfo _uiSpecifications;
        private UISpecificationsInfo UISpecifications
        {
            get
            {
                return _uiSpecifications ?? (_uiSpecifications = CreateProductUISpecifications());
            }
        }

        protected virtual UISpecificationsInfo CreateProductUISpecifications()
        {
            return new UISpecificationsInfo();
        }

        public partial class UISpecificationsInfo
        {
            public virtual bool GetIdIsMandatory(Product entity)
            {
                return true;
            }

            public virtual int ? GetIdMinValue(Product entity)
            {
                return null;
            }

            public virtual int ? GetIdMaxValue(Product entity)
            {
                return null;
            }

            public virtual bool GetNameIsMandatory(Product entity)
            {
                return true;
            }

            public virtual int ? GetNameMaxLength(Product entity)
            {
                return 40;
            }

            public virtual int ? GetNameMinLength(Product entity)
            {
                return null;
            }

            public virtual string GetNamePattern(Product entity)
            {
                return null;
            }

            public virtual bool GetSupplierIdIsMandatory(Product entity)
            {
                return false;
            }

            public virtual int ? GetSupplierIdMinValue(Product entity)
            {
                return null;
            }

            public virtual int ? GetSupplierIdMaxValue(Product entity)
            {
                return null;
            }

            public virtual bool GetCategoryIdIsMandatory(Product entity)
            {
                return false;
            }

            public virtual int ? GetCategoryIdMinValue(Product entity)
            {
                return null;
            }

            public virtual int ? GetCategoryIdMaxValue(Product entity)
            {
                return null;
            }

            public virtual bool GetQuantityPerUnitIsMandatory(Product entity)
            {
                return false;
            }

            public virtual int ? GetQuantityPerUnitMaxLength(Product entity)
            {
                return 20;
            }

            public virtual int ? GetQuantityPerUnitMinLength(Product entity)
            {
                return null;
            }

            public virtual string GetQuantityPerUnitPattern(Product entity)
            {
                return null;
            }

            public virtual bool GetUnitPriceIsMandatory(Product entity)
            {
                return true;
            }

            public virtual double ? GetUnitPriceMinValue(Product entity)
            {
                return null;
            }

            public virtual double ? GetUnitPriceMaxValue(Product entity)
            {
                return null;
            }

            public virtual bool GetDiscontinuedIsMandatory(Product entity)
            {
                return true;
            }
        }

        private ErrorsSpecifications _errors;
        protected ErrorsSpecifications Errors
        {
            get
            {
                return _errors ?? (_errors = new ErrorsSpecifications());
            }
        }

        bool IEntityWithErrors.HasErrors
        {
            get
            {
                return Errors.AllErrors.Count != 0;
            }
        }

        event Action IEntityWithErrors.HasErrorsChanged
        {
            add
            {
                Errors.HasErrorChanged += value;
            }

            remove
            {
                Errors.HasErrorChanged += value;
            }
        }

        public partial class ErrorsSpecifications
        {
            private ObservableCollection<Error> _id;
            public ObservableCollection<Error> Id
            {
                get
                {
                    return _id ?? (_id = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _name;
            public ObservableCollection<Error> Name
            {
                get
                {
                    return _name ?? (_name = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _supplierId;
            public ObservableCollection<Error> SupplierId
            {
                get
                {
                    return _supplierId ?? (_supplierId = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _categoryId;
            public ObservableCollection<Error> CategoryId
            {
                get
                {
                    return _categoryId ?? (_categoryId = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _quantityPerUnit;
            public ObservableCollection<Error> QuantityPerUnit
            {
                get
                {
                    return _quantityPerUnit ?? (_quantityPerUnit = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _unitPrice;
            public ObservableCollection<Error> UnitPrice
            {
                get
                {
                    return _unitPrice ?? (_unitPrice = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _discontinued;
            public ObservableCollection<Error> Discontinued
            {
                get
                {
                    return _discontinued ?? (_discontinued = new ObservableCollection<Error>());
                }
            }

            private ObservableCollection<Error> _allErrors;
            public ObservableCollection<Error> AllErrors
            {
                get
                {
                    if (_allErrors == null)
                    {
                        _allErrors = new ObservableCollection<Error>();
                        NotifyCollectionChangedEventHandler errorsCollectionChanged = (_, e) =>
                        {
                            if (e.NewItems != null)
                                foreach (Error error in e.NewItems)
                                {
                                    if (!_allErrors.Any(er => er.Key == error.Key))
                                        _allErrors.Add(error);
                                }

                            if (e.OldItems != null)
                                foreach (Error error in e.OldItems)
                                    _allErrors.Remove(error);
                        }

                        ;
                        AddAllErrorsHandlers(errorsCollectionChanged);
                    }

                    return _allErrors;
                }
            }

            protected virtual void AddAllErrorsHandlers(NotifyCollectionChangedEventHandler errorsCollectionChanged)
            {
                NotifyCollectionChangedEventHandler specificErrorsCollectionChanged = (sender, e) =>
                {
                    errorsCollectionChanged(sender, e);
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            if (AllErrors.Count == e.NewItems.Count)
                                OnHasErrorChanged();
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            if (AllErrors.Count == 0)
                                OnHasErrorChanged();
                            break;
                    }
                }

                ;
                Id.CollectionChanged += specificErrorsCollectionChanged;
                Name.CollectionChanged += specificErrorsCollectionChanged;
                SupplierId.CollectionChanged += specificErrorsCollectionChanged;
                CategoryId.CollectionChanged += specificErrorsCollectionChanged;
                QuantityPerUnit.CollectionChanged += specificErrorsCollectionChanged;
                UnitPrice.CollectionChanged += specificErrorsCollectionChanged;
                Discontinued.CollectionChanged += specificErrorsCollectionChanged;
            }

            protected void OnHasErrorChanged()
            {
                if (HasErrorChanged != null)
                    OnHasErrorChanged();
            }

            public event Action HasErrorChanged;
        }
#endregion
    }
}
            