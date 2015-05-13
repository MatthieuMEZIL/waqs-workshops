using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using WAQSWorkshopClient;
using WAQSWorkshopClient.ClientContext;
using WAQSWorkshopClient.ClientContext.Interfaces;
using WAQSWorkshopClient.ClientContext.Interfaces.Errors;
using WAQS.ClientContext;
using WAQS.ClientContext.Interfaces;
using WAQS.ClientContext.Interfaces.Errors;
using WAQS.ClientContext.Interfaces.Querying;
using WAQS.ComponentModel;

namespace WAQSWorkshopClient
{
    public class MainWindowViewModel : ViewModelBase
    {
        private INorthwindClientContext _context;
        public MainWindowViewModel(INorthwindClientContext context) : base(context)
        {
            _context = context;
        }

        private IEnumerable<CustomerInfo> customers;
        public IEnumerable<CustomerInfo> Customers
        {
            get
            {
                if (customers == null)
                {
                    LoadCustomersAsync().ConfigureAwait(true);
                }
                return customers;
            }
            private set
            {
                customers = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(Customers));
            }
        }
        private async Task LoadCustomersAsync()
        {
            Customers = await (from c in _context.Customers.AsAsyncQueryable()
                               select new CustomerInfo
                               {
                                   CustomerName = c.CompanyName + " " + c.ContactName,
                                   TotalSpent = (double?)c.Orders.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice * (1 - od.Discount))) ?? 0
                               }).ExecuteAsync();
        }

        public class CustomerInfo
        {
            public string CustomerName { get; set; }
            public double TotalSpent { get; set; }
        }
    }
}