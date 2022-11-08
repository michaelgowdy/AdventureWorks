using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AdventureWorks.Models.Validation
{
    public class UserValidation : IDataErrorInfo
    {
        private readonly Dictionary<string, string> _propertyErrors = new Dictionary<string, string>();

        public string this[string columnName] => this._propertyErrors.TryGetValue(columnName, out var error) ? error : null;

        public bool HasErrors => _propertyErrors.Any();

        public string Error => null;

        //public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, errorMessage);
            }
            else
            {
                _propertyErrors[propertyName] = errorMessage;
            }

            OnErrorChanged(propertyName);
        }

        public void ClearError(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
            }
        }

        private void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }



        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
