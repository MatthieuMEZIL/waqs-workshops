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
    public class MainWindowViewModel : ViewModelBase
    {
        private INorthwindClientContext _context;

        public MainWindowViewModel(INorthwindClientContext context) : base(context)
        {
            _context = context;
        }

        private IEnumerable<CustomerInfo> _customers;
        public IEnumerable<CustomerInfo> Customers
        {
            get
            {
                if (_customers == null)
                {
                    LoadCustomersAsync().ConfigureAwait(true);
                }
                return _customers;
            }
            private set
            {
                _customers = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(Customers));
            }
        }

        public async Task LoadCustomersAsync()
        {
            Customers = await (from c in _context.Customers.AsAsyncQueryable()
                               let totalSpent = c.Orders.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice * (1 - od.Discount)))
                               orderby totalSpent descending
                               select new CustomerInfo
                               {
                                   Id = c.Id,
                                   Name = c.CompanyName + " " + c.ContactName,
                                   TotalSpent = (double?)totalSpent ?? 0
                               }).ExecuteAsync();
        }

        public async Task RefreshAsync()
        {
            await LoadCustomersAsync();
        }

        private RelayCommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand(c =>
                  {
                      var customerWindow = new CustomerWindow(); // this is not good for an MVVM point of view
                      var customerWindowViewModel = new CustomerWindowViewModel(ClientContextFactory<INorthwindClientContext>.Create(), ((CustomerInfo)c).Id, customerWindow);
                      customerWindow.DataContext = customerWindowViewModel;
                      customerWindow.Show();
                  }));
            }
        }

        public class CustomerInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public double TotalSpent { get; set; }
        }
    }
}