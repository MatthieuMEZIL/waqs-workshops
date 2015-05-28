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
        private Func<INorthwindClientContext> _contextFactory;

        public MainWindowViewModel(INorthwindClientContext context, Func<INorthwindClientContext> contextFactory) : base(context)
        {
            _context = context;
            _contextFactory = contextFactory;
            LoadEmployeesAsync().ConfigureAwait(true);
        }

        private IEnumerable<Employee> _employees;
        public IEnumerable<Employee> Employees
        {
            get { return _employees; }
            private set
            {
                _employees = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(Employees));
            }
        }

        private async Task LoadEmployeesAsync()
        {
            Employees = await _context.Employees.AsAsyncQueryable().Select(e => new Employee { Id = e.Id, FullName = e.FullName }).ExecuteAsync();
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(SelectedEmployee));
                LoadCustomersAsync().ConfigureAwait(true);
            }
        }

        private IEnumerable<CustomerInfo> _customers;
        public IEnumerable<CustomerInfo> Customers
        {
            get { return _customers; }
            private set
            {
                _customers = value;
                NotifyPropertyChanged.RaisePropertyChanged(nameof(Customers));
            }
        }

        public async Task LoadCustomersAsync()
        {
            Customers = null;
            var selectedEmployee = SelectedEmployee;
            if (selectedEmployee != null)
            {
                var customers = await (from c in _context.Customers.AsAsyncQueryable()
                                        where selectedEmployee.AlreadySoldTo(c)
                                        let totalSpent = c.TotalSpent
                                        orderby totalSpent descending
                                        select new CustomerInfo
                                        {
                                            Id = c.Id,
                                            Name = c.FullName,
                                            TotalSpent = totalSpent
                                        }).ExecuteAsync();
                if (selectedEmployee == SelectedEmployee)
                {
                    Customers = customers;
                }
            }
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
                      var customerWindowViewModel = new CustomerWindowViewModel(_contextFactory(), ((CustomerInfo)c).Id, customerWindow);
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