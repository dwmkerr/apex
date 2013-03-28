using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apex.MVVM;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.ImageCheckBox;
using Gallery.Controls.PaddedGrid;
using Gallery.Controls.SelectableItemsControl;
using Gallery.CueTextBox;
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
            GalleryItems.Add(new ImageCheckBoxViewModel());
            GalleryItems.Add(new PaddedGridViewModel());
            GalleryItems.Add(new SearchTextBoxViewModel());
            GalleryItems.Add(new SelectableItemsControlViewModel());
        }
    }
}
