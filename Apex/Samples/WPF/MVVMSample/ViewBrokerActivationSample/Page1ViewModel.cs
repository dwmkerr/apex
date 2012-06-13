using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace MVVMSample.ViewBrokerActivationSample
{
    [ViewModel]
    public class Page1ViewModel : ViewModel
    {
        public string Title
        {
            get { return "Page 1"; }
        }
    }
}
