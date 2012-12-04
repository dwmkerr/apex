using System.Windows;
#if SILVERLIGHT
using Apex.Consistency;
#endif

namespace Apex.Commands
{
    /// <summary>
    /// Collection of event bindings.
    /// </summary>
    public class EventBindingCollection : FreezableCollection<EventBinding>
    {
    }
}
