using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;

namespace Gallery.PivotControl
{
    [ViewModel]
    public class PivotControlViewModel : GalleryItemViewModel
    {
        public PivotControlViewModel()
        {
            Title = "PivotControl";
        }
    }
}
