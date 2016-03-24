namespace DCOMProductions.MvvmDemo.Models
{
    using System;
    using System.ComponentModel;

    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name;

        /// <summary>
        /// Initializes a new instance of the Customer class
        /// </summary>
        public Customer(String customerName)
        {
            Name = customerName;
        }

        /// <summary>
        /// Gets or sets the Customer's name
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
        #endregion

        #region IDataErrorInfor Members

        public string this[string propertyName]
        {
            get
            {
                Error = GetValidationError(propertyName);
                return Error;
            }
        }

        public string Error {
            get; private set;
            
        }
        #endregion

        #region Validation

        static readonly string[] ValidateProperties =
        {
            "Name"
        };
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidateProperties)
                    if (GetValidationError(property) != null)
                        return false;
                return true;
            }
        }
        string GetValidationError(String propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Name":
                    error = ValidateName();
                    break;
            }
            return error;
        }
        private string ValidateName()
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return "Customer name cannot be empty.";
            }
            return null;
        }
        #endregion
    }
}
