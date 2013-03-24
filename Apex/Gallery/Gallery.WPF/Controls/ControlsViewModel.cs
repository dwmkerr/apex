using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.FolderTextBox;
using Gallery.Controls.MultiBorder;
using Gallery.Controls.PaddedGrid;
using Gallery.Controls.TabbedDocumentInterface;
using Gallery.CueTextBox;
using Gallery.PathTextBox;
using Gallery.PivotControl;
using Gallery.SearchTextBox;

namespace Gallery.Controls
{
    [ViewModel]
    public class ControlsViewModel : GalleryItemViewModel
    {
        public ControlsViewModel()
        {
            Title = "Controls";

            GalleryItems.Add(new ApexGridViewModel());
            GalleryItems.Add(new CrossButtonViewModel());
            GalleryItems.Add(new CueTextBoxViewModel());
            GalleryItems.Add(new EnumComboBoxViewModel());
            GalleryItems.Add(new FolderTextBoxViewModel());
            GalleryItems.Add(new MultiBorderViewModel());
            GalleryItems.Add(new PaddedGridViewModel());
            GalleryItems.Add(new PathTextBoxViewModel());
            GalleryItems.Add(new PivotControlViewModel());
            GalleryItems.Add(new SearchTextBoxViewModel());
            GalleryItems.Add(new TabbedDocumentInterfaceViewModel());
        }
    }
}
