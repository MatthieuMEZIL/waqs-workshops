using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public class CustomerWindowViewModel : ViewModelBase
    {
        private INorthwindClientContext _context;
        private CustomerWindow _customerWindow; // using the window here is not good for an MVVM point of view

        public CustomerWindowViewModel(INorthwindClientContext context, string customerId, CustomerWindow customerWindow): base (context)
        {
            _context = context;
            _customerWindow = customerWindow;
            LoadAsync(customerId).ConfigureAwait(true);
        }

        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            private set
            {
                _customer = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(Customer));
            }
        }

        private async Task LoadAsync(string customerId)
        {
            Customer = await _context.Customers.AsAsyncQueryable().FirstOrDefault(c => c.Id == customerId).IncludeOrdersWithExpression(orders => orders.IncludeOrderDetails().WithHasInvoice()).ExecuteAsync();
            await _context.Products.AsAsyncQueryable().Select(p => new Product { Id = p.Id, FullName = p.FullName }).ExecuteAsync();
        }

        public IClientEntitySet<INorthwindClientContext, Product> Products
        {
            get { return _context.Products; }
        }

        private RelayCommand _saveCommand;
        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(() => SaveChangesAsync().ConfigureAwait(true))); }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                if (_selectedOrder != null)
                {
                    _selectedOrder.OrderDetails.CollectionChanged -= OrderDetailsCollectionChanged;
                }
                _selectedOrder = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(SelectedOrder));
                RefreshCreateInvoiceCanExecute();
                if (_selectedOrder != null)
                {
                    _selectedOrder.OrderDetails.CollectionChanged += OrderDetailsCollectionChanged;
                }
            }
        }

        private void OrderDetailsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var od in e.OldItems.Cast<OrderDetail>())
                {
                    _context.OrderDetails.Remove(od);
                }
            }
        }

        private RelayCommand _createInvoice;
        public ICommand CreateInvoice
        {
            get { return _createInvoice ?? (_createInvoice = new RelayCommand(() => CreateInvoiceAsync().ConfigureAwait(true), () => SelectedOrder != null && !SelectedOrder.HasInvoice)); }
        }
        private void RefreshCreateInvoiceCanExecute()
        {
            if (_createInvoice != null)
            {
                _createInvoice.RaiseCanExecuteChanged();
            }
        }

        private async Task CreateInvoiceAsync()
        {
            SelectedOrder.Specifications.HasInvoice = true;
            RefreshCreateInvoiceCanExecute();
            await _context.AddInvoiceAsync(SelectedOrder.Id);
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync(validate:true);
                _customerWindow.Close();
            }
            catch(ErrorException e)
            {
                System.Windows.MessageBox.Show(String.Join(Environment.NewLine, e.Errors.OrderByDescending(er => er.Criticity).Select(er => er.ErrorInfo.PropertyName + ": " + er.Message))); // this is not good for an MVVM point of view
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message); // this is not good for an MVVM point of view
            }
        }

        private RelayCommand _cancelCommand;
        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new RelayCommand(() => _customerWindow.Close())); }
        }
    }
}