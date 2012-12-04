using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Apex.Extensions;
using System.Collections.ObjectModel;
using Apex.MVVM;
using Apex.DragAndDrop;

namespace Apex.Controls
{
    /// <summary>
    /// Interaction logic for PivotControl.xaml
    /// </summary>
    [TemplatePart(Name = "PART_ItemsControl", Type = typeof (ItemsControl))]
    [TemplatePart(Name = "PART_PivotScrollViewer", Type = typeof (AnimatedScrollViewer))]
    [ContentProperty("PivotItems")]
    public partial class PivotControl : ContentControl
    {

#if !SILVERLIGHT
        /// <summary>
        /// Initializes the <see cref="PivotControl"/> class.
        /// </summary>
        static PivotControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (PivotControl), new FrameworkPropertyMetadata(typeof (PivotControl)));
        }
#else
    /// <summary>
    /// Initializes the <see cref="PivotControl"/> class.
    /// </summary>
        public PivotControl()
        {
            this.DefaultStyleKey = typeof(DragAndDropHost);
        }
#endif

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            try
            {
                itemsControl = (ItemsControl) GetTemplateChild("PART_ItemsControl");
                pivotScrollViewer = (AnimatedScrollViewer) GetTemplateChild("PART_PivotScrollViewer");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the Pivot control.");
            }
            selectPivotItemCommand = new Command(SelectPivotItem, true);

            SizeChanged += new SizeChangedEventHandler(PivotControl_SizeChanged);

            Loaded += new RoutedEventHandler(PivotControl_Loaded);

        }

        private void PivotControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedPivotItem == null && PivotItems.Count > 0)
            {
                foreach (var pivotItem in PivotItems)
                {
                    if (pivotItem.IsInitialPage)
                    {
                        SelectedPivotItem = pivotItem;
                        break;
                    }
                }
                if (SelectedPivotItem == null)
                    SelectedPivotItem = PivotItems[0];
            }
        }

        private ItemsControl itemsControl;
        private AnimatedScrollViewer pivotScrollViewer;

        private void PivotControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //  Go through each pivot item and set the size.
            foreach (var pivotItem in PivotItems)
            {
                if (pivotItem.Content is FrameworkElement)
                {
                    FrameworkElement frameworkElement = pivotItem.Content as FrameworkElement;
                    frameworkElement.Width = pivotScrollViewer.ActualWidth;
                    frameworkElement.Height = pivotScrollViewer.ActualHeight;
                }
            }
            UpdatePositioning(true);
        }

        /// <summary>
        /// Selects the pivot item.
        /// </summary>
        /// <param name="pivotItem">The pivot item.</param>
        public void SelectPivotItem(object pivotItem)
        {
            //  Deselect all items.
            foreach (var pitem in PivotItems)
                pitem.IsSelected = false;

            PivotItem item = pivotItem as PivotItem;
            if (item != null)
                item.IsSelected = true;

            SelectedPivotItem = item;
        }

        /// <summary>
        /// PivotItems dependency property.
        /// </summary>
        public static readonly DependencyProperty PivotItemsProperty = DependencyProperty.Register("PivotItems",
                                                                                                   typeof (ObservableCollection<PivotItem>), typeof (PivotControl), new PropertyMetadata(new ObservableCollection<PivotItem>()));

        /// <summary>
        /// SelectedPivotItem dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedPivotItemProperty = DependencyProperty.Register("SelectedPivotItem",
                                                                                                          typeof (PivotItem), typeof (PivotControl), new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedPivotItemChanged)));

        private Command selectPivotItemCommand = null;


        /// <summary>
        /// Gets or sets the pivot items.
        /// </summary>
        /// <value>
        /// The pivot items.
        /// </value>
        public ObservableCollection<PivotItem> PivotItems
        {
            get { return GetValue(PivotItemsProperty) as ObservableCollection<PivotItem>; }
            set { SetValue(PivotItemsProperty, value); }
        }


        /// <summary>
        /// Gets or sets the selected pivot item.
        /// </summary>
        /// <value>
        /// The selected pivot item.
        /// </value>
        public PivotItem SelectedPivotItem
        {
            get { return GetValue(SelectedPivotItemProperty) as PivotItem; }
            set { SetValue(SelectedPivotItemProperty, value); }
        }

        /// <summary>
        /// Gets the select pivot item command.
        /// </summary>
        public ICommand SelectPivotItemCommand
        {
            get { return selectPivotItemCommand; }
        }

        /// <summary>
        /// Called when [selected pivot item changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnSelectedPivotItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  Get the pivot control and pivot item.
            PivotControl me = d as PivotControl;
            PivotItem item = e.NewValue as PivotItem;

            //  Continue only if we have non-null objects.
            if (me == null || item == null)
                return;

            me.PivotControl_SizeChanged(me, null);
            me.UpdatePositioning(e.OldValue == null ? true : false);
        }

        private void UpdatePositioning(bool immediate)
        {
            if (SelectedPivotItem == null || SelectedPivotItem.Content is FrameworkElement == false)
                return;

            //  Get the pivot content.
            FrameworkElement pivotContent = ((FrameworkElement) SelectedPivotItem.Content);

            itemsControl.UpdateLayout();
            Point relativePoint = pivotContent.TransformToAncestor(this).Transform(new Point(0, 0));

            //  We'll actually move the item to the centre of the screen.
            relativePoint.X += (pivotContent.ActualWidth/2) - (ActualWidth/2);

            DoubleAnimation horzAnim = new DoubleAnimation();
            horzAnim.From = pivotScrollViewer.HorizontalOffset;
            horzAnim.To = pivotScrollViewer.HorizontalOffset + relativePoint.X;
            horzAnim.DecelerationRatio = .8;
            horzAnim.Duration = new Duration(TimeSpan.FromMilliseconds(immediate ? 0 : 300));

            Storyboard sb = new Storyboard();
            sb.Children.Add(horzAnim);

            Storyboard.SetTarget(horzAnim, pivotScrollViewer);
            Storyboard.SetTargetProperty(horzAnim, new PropertyPath(AnimatedScrollViewer.CurrentHorizontalOffsetProperty));

            sb.Begin();
        }


        private static readonly DependencyProperty ShowPivotHeadingsProperty =
            DependencyProperty.Register("ShowPivotHeadings", typeof (bool), typeof (PivotControl),
                                        new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether [show pivot headings].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show pivot headings]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowPivotHeadings
        {
            get { return (bool) GetValue(ShowPivotHeadingsProperty); }
            set { SetValue(ShowPivotHeadingsProperty, value); }
        }
    }
}