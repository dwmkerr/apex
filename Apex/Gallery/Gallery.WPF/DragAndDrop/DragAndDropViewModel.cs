using Apex.MVVM;
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
using Gallery.SearchTextBox;

namespace Gallery.DragAndDrop
{
    [ViewModel]
    public class DragAndDropViewModel : GalleryItemViewModel
    {
        public DragAndDropViewModel()
        {
            Title = "Drag & Drop";

            GalleryItems.Add(new CanvasSampleViewModel());
            GalleryItems.Add(new ItemsControlSampleViewModel());
        }
    }
}
