using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdventureWorks.Models.Models
{
    public class ErrorsModel : INotifyDataErrorInfo
    {
        public bool HasErrors => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
