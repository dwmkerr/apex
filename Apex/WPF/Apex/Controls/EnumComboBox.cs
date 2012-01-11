using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;

//  http://social.msdn.microsoft.com/forums/en-US/wpf/thread/f230804d-fc0f-4321-a61e-69a2c890b28d/
//  TODO: Add a dependency property - selectedenumeration
//  then set the datatemplate to show it

namespace Apex.Controls
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EnumComboBox : ComboBox
    {
        protected override void OnInitialized(EventArgs e)
        {
            //  Call the base.
            base.OnInitialized(e);

            //  Set the display/value paths.
            DisplayMemberPath = "Value";
            SelectedValuePath = "Key";

            //  Populate the items source.
            PopulateItemsSource();
        }

        /// <summary>
        /// Populates the items source.
        /// </summary>
        private void PopulateItemsSource()
        {
            //  We must have an items source and an item which is an enum.
            if (ItemsSource != null || SelectedValue is Enum == false)
                return;

            //  Get the enum type.
            var enumType = SelectedValue.GetType();

            //  Get the enum values.
            var enumValues = Enum.GetValues(enumType);

            //  Create some enum value/descriptions.
            var enumerationValuesToDescriptions = new List<KeyValuePair<object, string>>();

            //  Go through each one.
            foreach (var enumValue in enumValues)
            {
                //  Add the enumeration item.
                enumerationValuesToDescriptions.Add(new KeyValuePair<object, string>(enumValue, GetEnumName(enumType, enumValue)));
            }

            //  Set the items source.
            ItemsSource = enumerationValuesToDescriptions;
        }

        private string GetEnumName(Type enumType, object enumValue)
        {
            var descriptionAttribute = enumType
              .GetField(enumValue.ToString())
              .GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;


            return descriptionAttribute != null
              ? descriptionAttribute.Description
              : enumValue.ToString();
        }

        
        private static readonly DependencyProperty EnumValueProperty =
          DependencyProperty.Register("EnumValue", typeof(object), typeof(EnumComboBox),
          new PropertyMetadata(null, new PropertyChangedCallback(OnEnumValueChanged)));

        public object EnumValue
        {
            get { return (object)GetValue(EnumValueProperty); }
            set { SetValue(EnumValueProperty, value); }
        }

        private static void OnEnumValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            EnumComboBox me = o as EnumComboBox;

            me.SelectedValue = args.NewValue;
            me.PopulateItemsSource();
        }
                
    }
}