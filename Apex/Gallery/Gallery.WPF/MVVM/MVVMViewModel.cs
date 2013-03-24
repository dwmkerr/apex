using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using Gallery.Behaviours.ListViewItemContextMenuBehaviour;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.MultiBorder;
using Gallery.Controls.PaddedGrid;
using Gallery.Controls.TabbedDocumentInterface;
using Gallery.CueTextBox;
using Gallery.MVVM.CommandingSample;
using Gallery.MVVM.SimpleSample;
using Gallery.MVVM.ViewBrokerActivationSample;
using Gallery.MVVM.ViewBrokerSample;
using Gallery.PathTextBox;
using Gallery.PivotControl;
using Gallery.SearchTextBox;

namespace Gallery.MVVM
{
    [ViewModel]
    public class MVVMViewModel : GalleryItemViewModel
    {
        public MVVMViewModel()
        {
            Title = "MVVM";

            GalleryItems.Add(new SimpleExampleViewModel());
            GalleryItems.Add(new CommandingSampleViewModel());
            GalleryItems.Add(new ViewBrokerSampleViewModel());
            GalleryItems.Add(new ViewBrokerActivationSampleViewModel());
        }
    }
}
