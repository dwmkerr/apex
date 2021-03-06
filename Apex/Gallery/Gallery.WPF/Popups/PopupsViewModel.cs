﻿using Apex.MVVM;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.MultiBorder;
using Gallery.Controls.PaddedGrid;
using Gallery.Controls.TabbedDocumentInterface;
using Gallery.CueTextBox;
using Gallery.DragAndDrop.CanvasSample;
using Gallery.DragAndDrop.ItemsControlSample;
using Gallery.PathTextBox;
using Gallery.PivotControl;
using Gallery.Popups.CustomisedPopup;
using Gallery.Popups.SimplePopup;
using Gallery.SearchTextBox;

namespace Gallery.Popups
{
    [ViewModel]
    public class PopupsViewModel : GalleryItemViewModel
    {
        public PopupsViewModel()
        {
            Title = "Popups";

            GalleryItems.Add(new SimplePopupViewModel());
            GalleryItems.Add(new CustomisedPopupViewModel());
        }
    }
}
