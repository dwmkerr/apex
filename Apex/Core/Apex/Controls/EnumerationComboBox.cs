using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using Apex.Extensions;

namespace Apex.Controls
{
    /// <summary>
    /// A EnumerationComboBox shows a selected enumeration value from a set of all available enumeration values.
    /// If the enumeration value has the 'Description' attribute, this is used.
    /// </summary>
    public class EnumerationComboBox : ComboBox
    {
        /// <summary>
        /// Handles the SelectionChanged event of the EnumerationComboBoxTemp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void EnumerationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  Get the new item.
            if (e.AddedItems.Count == 0 || e.AddedItems[0] is NameValue == false)
                return;

            //  Keep the selected enumeration up to date.
            NameValue nameValue = e.AddedItems[0] as NameValue;
            SelectedEnumeration = nameValue.Value;
        }

        /// <summary>
        /// Populates the items source.
        /// </summary>
        private void PopulateItemsSource()
        {
            //  We must have an items source and an item which is an enum.
            if (ItemsSource != null || SelectedEnumeration is Enum == false)
                return;

            //  Get the enum type.
            var enumType = SelectedEnumeration.GetType();

            //  Get the enum values. Use the helper rather than Enum.GetValues
            //  as it works in Silverlight too.
            var enumValues = Apex.Helpers.EnumHelper.GetValues(enumType);

            //  Create some enum value/descriptions.
            enumerations = new List<NameValue>();

            //  Go through each one.
            foreach (var enumValue in enumValues)
            {
                //  Add the enumeration item.
                enumerations.Add(new NameValue(((Enum)enumValue).GetDescription(), enumValue));
            }

            //  Set the items source.
            ItemsSource = enumerations;

            //  Initialise the control.
            Initialise();
        }

        /// <summary>
        /// Initialises this instance.
        /// </summary>
        private void Initialise()
        {
            //  Set the display member path and selected value path.
            DisplayMemberPath = "Name";

#if !WINDOWS_PHONE
            //  TODO: Check what we can do for WP7.
            SelectedValuePath = "Value";
#endif

            //  If we have enumerations and a selected enumeration, set the selected item.
            if (enumerations != null && SelectedEnumeration != null)
            {
                var selectedEnum = from enumeration in enumerations where enumeration.Value.ToString() == SelectedEnumeration.ToString() select enumeration;
                this.SelectedItem = selectedEnum.FirstOrDefault();
            }

            //  Wait for selection changed events.
            SelectionChanged += new SelectionChangedEventHandler(EnumerationComboBox_SelectionChanged);
        }

        /// <summary>
        /// The SelectedEnumerationProperty dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedEnumerationProperty =
          DependencyProperty.Register("SelectedEnumeration", typeof(object), typeof(EnumerationComboBox),
#if !SILVERLIGHT
 new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedEnumerationChanged)));
#else
        new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedEnumerationChanged)));
#endif

        /// <summary>
        /// Gets or sets the selected enumeration.
        /// </summary>
        /// <value>
        /// The selected enumeration.
        /// </value>
        public object SelectedEnumeration
        {
            get { return (object)GetValue(SelectedEnumerationProperty); }
            set { SetValue(SelectedEnumerationProperty, value); }
        }

        /// <summary>
        /// Called when the selected enumeration is changed.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSelectedEnumerationChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //  Get the combo box.
            EnumerationComboBox me = o as EnumerationComboBox;

            //  Populate the items source.
            me.PopulateItemsSource();
        }

        /// <summary>
        /// Gets or sets the enumerations.
        /// </summary>
        /// <value>
        /// The enumerations.
        /// </value>
        private List<NameValue> enumerations;
    }

    /// <summary>
    /// A name-value pair.
    /// </summary>
    internal class NameValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameValue"/> class.
        /// </summary>
        public NameValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public NameValue(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value
        {
            get;
            set;
        }
    }
}