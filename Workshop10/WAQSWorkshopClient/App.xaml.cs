using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using Microsoft.Practices.Unity;
using WAQS.ComponentModel;
using WAQS.Controls;
using WAQSWorkshopClient.ClientContext.Interfaces;
using WAQSWorkshopClient.ClientContext;
using WAQSWorkshopClient.ClientContext.ServiceReference;

namespace WAQSWorkshopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IMessageBoxService, MessageBoxService>();
            DispatcherUnhandledException += (sender, ex) =>
            {
                unityContainer.Resolve<IMessageBoxService>().ShowError(ex.Exception.Message);
                ex.Handled = true;
            }

            ;
            TaskScheduler.UnobservedTaskException += (sender, ex) =>
            {
                unityContainer.Resolve<IMessageBoxService>().ShowError(ex.Exception.InnerException.Message);
                ex.SetObserved();
            }

            ;
            InitWAQSModules(unityContainer);
            UIThread.Dispatcher = Application.Current.Dispatcher;
            UIThread.TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            unityContainer.Resolve<WAQSWorkshopClient.MainWindow>().Show();
        }

        private void InitWAQSModules(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<INorthwindService, NorthwindServiceClient>(new InjectionConstructor());
            unityContainer.RegisterType<INorthwindClientContext, NorthwindClientContext>();
        }
    }
}