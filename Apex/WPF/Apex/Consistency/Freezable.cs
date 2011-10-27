using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Consistency
{
#if SILVERLIGHT

    public class Freezable : System.Windows.DependencyObject
    {
        protected virtual Freezable CreateInstanceCore()
        {
            return null;
        }
    }

    public class FreezableCollection<T> : System.Collections.ObjectModel.Collection<T>
    {
    }

#endif
}
