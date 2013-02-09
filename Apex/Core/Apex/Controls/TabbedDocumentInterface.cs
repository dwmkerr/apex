using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
    //  TODO IList for the documents.

    [TemplatePart(Name = "PART_DocumentsTabControl", Type = typeof(TabControl))]
    [TemplatePart(Name = "PART_ContentControl", Type = typeof(ContentControl))]
    public class TabbedDocumentInterface : ContentControl
    {
        /// <summary>
        /// Initializes the <see cref="CueTextBox"/> class.
        /// </summary>
#if !SILVERLIGHT
        static TabbedDocumentInterface()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabbedDocumentInterface), new FrameworkPropertyMetadata(typeof(TabbedDocumentInterface)));
        }
#else
        public TabbedDocumentInterface()
        {
            //  Override the default style.
            DefaultStyleKey = typeof(TabbedDocumentInterface);
        }
#endif
        /// <summary>
        /// Is called when a control template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            try
            {
                documentsTabControl = (TabControl)GetTemplateChild("PART_DocumentsTabControl");
                contentControl = (ContentControl)GetTemplateChild("PART_ContentControl");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the TabbedDocumentInterface.");
            }

            //  If we already have documents, wire up the handler.
            WireUpCollectionChangedEventHandler(null, Documents);

            //  If we have any documents, add them.
            if(Documents != null && Documents.Count > 0)
            {
                foreach (var document in Documents)
                {
                    AddDocumentTab(document);
                }
            }

            //  Update the visiblity of the tabs.
            UpdateTabsVisibility();
        }

        private void UpdateTabsVisibility()
        {
            //  The tabs are visbile only if we have documents.
            bool showTabs = Documents != null && Documents.Count > 0;
            documentsTabControl.Visibility = showTabs ? Visibility.Visible : Visibility.Collapsed;
            contentControl.Visibility = showTabs ? Visibility.Collapsed : Visibility.Visible;
        }

        private void WireUpCollectionChangedEventHandler(object oldValue, object newValue)
        {
            if (oldValue is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)(oldValue)).CollectionChanged -= TabbedDocumentInterface_DocumentsCollectionChanged;
            }
            if (newValue is INotifyCollectionChanged)
            {
                ((INotifyCollectionChanged)(newValue)).CollectionChanged -= TabbedDocumentInterface_DocumentsCollectionChanged;
                ((INotifyCollectionChanged)(newValue)).CollectionChanged += TabbedDocumentInterface_DocumentsCollectionChanged;
            }
        }

        private static void OnDocumentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TabbedDocumentInterface)d).WireUpCollectionChangedEventHandler(e.OldValue, e.NewValue);
        }

        private void AddDocumentTab(object document)
        {
            //  Create a tab item.
            documentsTabControl.Items.Add(document);
        }

        void TabbedDocumentInterface_DocumentsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(var newDocument in e.NewItems)
                        AddDocumentTab(newDocument);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //  Make sure the tabs visbility is correct.
            UpdateTabsVisibility();    
        }

        public static IList GetDocuments(DependencyObject obj)
        {
            return (IList)obj.GetValue(DocumentsProperty);
        }

        public static void SetDocuments(DependencyObject obj, ObservableCollection<DateTime> value)
        {
            obj.SetValue(DocumentsProperty, value);
        }

        public IList Documents
        {
            get { return (IList) GetValue(DocumentsProperty); }
            set{ SetValue(DocumentsProperty, value);}
        }

        public static readonly DependencyProperty DocumentsProperty =
            DependencyProperty.RegisterAttached("Documents", typeof(IList),
                                                typeof (TabbedDocumentInterface), new UIPropertyMetadata(null, OnDocumentsChanged));

        private TabControl documentsTabControl;
        private ContentControl contentControl;

        
        /// <summary>
        /// The DependencyProperty for the TabHeaderTemplate property.
        /// </summary>
        public static readonly DependencyProperty TabHeaderTemplateProperty =
          DependencyProperty.Register("TabHeaderTemplate", typeof(DataTemplate), typeof(TabbedDocumentInterface),
          new PropertyMetadata(default(DataTemplate), new PropertyChangedCallback(OnTabHeaderTemplateChanged)));

        /// <summary>
        /// Gets or sets TabHeaderTemplate.
        /// </summary>
        /// <value>The value of TabHeaderTemplate.</value>
        public DataTemplate TabHeaderTemplate
        {
            get { return (DataTemplate)GetValue(TabHeaderTemplateProperty); }
            set { SetValue(TabHeaderTemplateProperty, value); }
        }

        /// <summary>
        /// Called when TabHeaderTemplate is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTabHeaderTemplateChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            TabbedDocumentInterface me = o as TabbedDocumentInterface;
        }

        
        /// <summary>
        /// The DependencyProperty for the TabContentTemplate property.
        /// </summary>
        public static readonly DependencyProperty TabContentTemplateProperty =
          DependencyProperty.Register("TabContentTemplate", typeof(DataTemplate), typeof(TabbedDocumentInterface),
          new PropertyMetadata(default(DataTemplate), new PropertyChangedCallback(OnTabContentTemplateChanged)));

        /// <summary>
        /// Gets or sets TabContentTemplate.
        /// </summary>
        /// <value>The value of TabContentTemplate.</value>
        public DataTemplate TabContentTemplate
        {
            get { return (DataTemplate)GetValue(TabContentTemplateProperty); }
            set { SetValue(TabContentTemplateProperty, value); }
        }

        /// <summary>
        /// Called when TabContentTemplate is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTabContentTemplateChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            TabbedDocumentInterface me = o as TabbedDocumentInterface;
        }
    }
}