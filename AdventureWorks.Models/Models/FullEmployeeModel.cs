using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace AdventureWorks.Models.Models
{
    public class FullEmployeeModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();

        public string this[string columnName] => this._propertyErrors.TryGetValue(columnName, out var error) ? error : null;

        public string Error => null;

        public event PropertyChangedEventHandler PropertyChanged;


        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, errorMessage);
            }
            else
            {
                _propertyErrors[propertyName] = errorMessage;
            }

            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FullEmployeeModel()
        {
            this.Validate();
        }



        private int _businessEntityId;

        public int BusinessEntityID
        {
            get { return _businessEntityId; }
            set
            {
                _businessEntityId = value;
                OnPropertyChanged(nameof(BusinessEntityID));
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;

                Validate();

                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;

                Validate();

                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _jobTitle;

        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;

                Validate();

                OnPropertyChanged(nameof(JobTitle));
            }
        }

        private string _loginId;

        public string LoginID
        {
            get { return _loginId; }
            set 
            { 
                _loginId = value;

                Validate();

                OnPropertyChanged(nameof(LoginID));
            }
        }

        private string _nationalIdNumber;

        public string NationalIDNumber
        {
            get { return _nationalIdNumber; }
            set 
            { 
                _nationalIdNumber = value;

                Validate();

                OnPropertyChanged(nameof(NationalIDNumber));
            }
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_firstName))
            {
                AddError(nameof(FirstName), "This field is required.");
            }
            else
            {
                ClearError(nameof(FirstName));
            }

            if (string.IsNullOrWhiteSpace(_lastName))
            {
                AddError(nameof(LastName), "This field is required.");
            }
            else
            {
                ClearError(nameof(LastName));
            }

            if (string.IsNullOrWhiteSpace(_jobTitle))
            {
                AddError(nameof(JobTitle), "This field is required.");
            }
            else
            {
                ClearError(nameof(JobTitle));
            }

            if (string.IsNullOrWhiteSpace(_loginId))
            {
                AddError(nameof(LoginID), "This field is required.");
            }
            else
            {
                ClearError(nameof(LoginID));
            }

            if (string.IsNullOrWhiteSpace(_nationalIdNumber))
            {
                AddError(nameof(NationalIDNumber), "This field is required.");
            }
            else
            {
                ClearError(nameof(NationalIDNumber));
            }
        }

        private void ClearError(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
            }
        }
    }
}
