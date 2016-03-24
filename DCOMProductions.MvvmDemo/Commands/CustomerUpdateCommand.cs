using DCOMProductions.MvvmDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DCOMProductions.MvvmDemo.Commands
{
    internal class CustomerUpdateCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the CustomerUpdateCommand class.
        /// </summary>
        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        private CustomerViewModel viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(viewModel.Customer.Error);
        }

        public void Execute(object parameter)
        {
            viewModel.SaveChanged();
        }
    }
}
