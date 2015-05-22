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
    public class CustomerWindowViewModel : ViewModelBase
    {
        private INorthwindClientContext _context;
        private CustomerWindow _customerWindow; // using the window here is not good for an MVVM point of view

        public CustomerWindowViewModel(INorthwindClientContext context, string customerId, CustomerWindow customerWindow): base (context)
        {
            _context = context;
            _customerWindow = customerWindow;
            LoadCustomerAsync(customerId).ConfigureAwait(true);
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

        private async Task LoadCustomerAsync(string customerId)
        {
            Customer = await _context.Customers.AsAsyncQueryable().FirstOrDefault(c => c.Id == customerId).ExecuteAsync();
        }

        private RelayCommand _saveCommand;
        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(() => SaveChangesAsync().ConfigureAwait(true))); }
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _customerWindow.Close();
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