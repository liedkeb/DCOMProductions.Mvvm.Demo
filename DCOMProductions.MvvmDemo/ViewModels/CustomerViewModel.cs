﻿using DCOMProductions.MvvmDemo.Commands;
using DCOMProductions.MvvmDemo.Models;
using DCOMProductions.MvvmDemo.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace DCOMProductions.MvvmDemo.ViewModels
{
    internal class CustomerViewModel 
    {
        private Customer customer;
        private CustomerInfoViewModel customerInfoMessage;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        public CustomerViewModel()
        {
            customer = new Customer("Bartek");
            customerInfoMessage = new CustomerInfoViewModel ();
            UpdateCommand = new CustomerUpdateCommand(this);
        }

        /// <summary>
        /// Gets the customer instance
        /// </summary>
        public Customer Customer
        {
            get { return customer; }
            
        }

        /// <summary>
        /// Gets the UpdateCommand for the ViewModel.
        /// </summary>
        public ICommand UpdateCommand
        {
            get;
           
            private set;
        }

        /// <summary>
        /// Saves changes made to the Customer instance.
        /// </summary>
        public void SaveChanged()
        {
            CustomerInfoView view = new CustomerInfoView();
            view.DataContext = customerInfoMessage;
            customerInfoMessage.Info = Customer.Name + " was updated in the database.";

            view.ShowDialog();
        }


    }
}
