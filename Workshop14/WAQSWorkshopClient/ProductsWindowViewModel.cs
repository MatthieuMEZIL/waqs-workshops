using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WAQS.ClientContext;
using WAQS.ClientContext.Interfaces;
using WAQS.ClientContext.Interfaces.Errors;
using WAQS.ClientContext.Interfaces.Querying;
using WAQS.ComponentModel;
using WAQSWorkshopClient;
using WAQSWorkshopClient.ClientContext;
using WAQSWorkshopClient.ClientContext.Interfaces;
using WAQSWorkshopClient.ClientContext.Interfaces.Errors;

namespace WAQSWorkshopClient
{
    public class ProductsWindowViewModel : ViewModelBase
    {
        private INorthwindClientContext _context;
        private OrderDetail _orderDetail;

        public ProductsWindowViewModel(INorthwindClientContext context, OrderDetail orderDetail) : base(context)
        {
            _context = context;
            _orderDetail = orderDetail;
        }

        private string _fullNameSearch;
        public string FullNameSearch
        {
            get { return _fullNameSearch; }
            set
            {
                _fullNameSearch = value;
                if (ProductsByStepQuery != null)
                {
                    ProductsByStepQuery.Completed -= ProductsByStepQueryCompleted;
                    ProductsByStepQuery.Cancel();
                }
                if (string.IsNullOrEmpty(value))
                {
                    ProductsByStepQuery = null;
                }
                else
                {
                    ProductsByStepQuery =
                        (from p in _context.Products.AsAsyncQueryable()
                         let fullName = p.FullName
                         where fullName.Contains(value)
                         orderby fullName, p.Id
                         select new Product { Id = p.Id, FullName = fullName }).ToByStepQuery(10);
                    ProductsByStepQuery.Completed += ProductsByStepQueryCompleted;
                    ProductsByStepQuery.Load();
                    RefreshStopSearchCommandCanExecute();
                }
            }
        }

        private ByStepQuery<Product> _productsByStepQuery;
        public ByStepQuery<Product> ProductsByStepQuery
        {
            get { return _productsByStepQuery; }
            private set
            {
                _productsByStepQuery = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(ProductsByStepQuery));
            }
        }

        private void ProductsByStepQueryCompleted()
        {
            ProductsByStepQuery.Completed -= ProductsByStepQueryCompleted;
            RefreshStopSearchCommandCanExecute();
        }

        private RelayCommand _stopSearchCommand;
        public ICommand StopSearchCommand
        {
            get
            {
                return _stopSearchCommand ??
                    (_stopSearchCommand = new RelayCommand(
                        () => ProductsByStepQuery.Cancel(),
                        () => ProductsByStepQuery != null && !ProductsByStepQuery.IsCompleted));
            }
        }

        private void RefreshStopSearchCommandCanExecute()
        {
            if (_stopSearchCommand != null)
            {
                _stopSearchCommand.RaiseCanExecuteChanged();
            }
        }

        public Product SelectedProduct
        {
            get { return _orderDetail.Product; }
            set
            {
                _orderDetail.Product = value;
                if (value != null)
                {
                    _orderDetail.ProductFullName = value.FullName;
                }
                NotifyPropertyChanged.RaisePropertyChanged(nameof(SelectedProduct));
            }
        }
    }
}