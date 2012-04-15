using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace Apex.DragAndDrop
{
    /// <summary>
    /// The drag and drop event args.
    /// </summary>
    public class DragAndDropEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a value indicating whether this operation is allowed to continue.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the operation is allowed; otherwise, <c>false</c>.
        /// </value>
        public bool Allow 
        { 
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the drag source.
        /// </summary>
        /// <value>
        /// The drag source.
        /// </value>
        public FrameworkElement DragSource 
        { 
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the drag element.
        /// </summary>
        /// <value>
        /// The drag element.
        /// </value>
        public FrameworkElement DragElement 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the drag data.
        /// </summary>
        /// <value>
        /// The drag data.
        /// </value>
        public object DragData 
        { 
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the drop target.
        /// </summary>
        /// <value>
        /// The drop target.
        /// </value>
        public FrameworkElement DropTarget
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the drag adorner.
        /// </summary>
        /// <value>
        /// The drag adorner.
        /// </value>
        public Apex.Adorners.Adorner DragAdorner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the initial element offset.
        /// </summary>
        /// <value>
        /// The initial element offset.
        /// </value>
        public Point InitialElementOffset 
        { 
            get;
            set; 
        }
    }
}
