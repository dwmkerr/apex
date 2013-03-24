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
using Gallery.PathTextBox;
using Gallery.PivotControl;
using Gallery.SearchTextBox;

namespace Gallery.Behaviours
{
    [ViewModel]
    public class BehavioursViewModel : GalleryItemViewModel
    {
        public BehavioursViewModel()
        {
            Title = "Behaviours";

            GalleryItems.Add(new ListViewItemContextMenuBehaviourViewModel());
        }
    }
}
