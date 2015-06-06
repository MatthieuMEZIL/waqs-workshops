using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (orderDetail.ProductId == 0)
            {
                ProductsPaginatedQuery.LoadPage();
            }
            else
            {
                ProductsPaginatedQuery.LoadPage(
                    new LoadPageParameter { PropertyName = "FullName", Value = orderDetail.ProductFullName },
                    new LoadPageParameter { PropertyName = "Id", Value = orderDetail.ProductId });
            }
        }

        private PaginatedQuery<Product> _productsPaginatedQuery;
        public PaginatedQuery<Product> ProductsPaginatedQuery
        {
            get
            {
                return _productsPaginatedQuery ?? (_productsPaginatedQuery =
                  (from p in _context.Products.AsAsyncQueryable()
                   let fullName = p.FullName
                   orderby fullName, p.Id
                   select new Product { Id = p.Id, FullName = fullName }).ToPaginatedQuery(10, callBack: () => NotifyPropertyChanged.RaisePropertyChanged(() => SelectedProduct)));
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