using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO;
using System.Windows.Markup;

//  http://social.msdn.microsoft.com/forums/en-US/wpf/thread/f230804d-fc0f-4321-a61e-69a2c890b28d/
//  TODO: Add a dependency property - selectedenumeration
//  then set the datatemplate to show it

namespace Apex.Controls
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EnumerationComboBox : ComboBox
    {
        protected override void OnInitialized(EventArgs e)
        {
            //  Call the base.
            base.OnInitialized(e);

          /*

            MemoryStream sr = null;

            ParserContext pc = null;

            string xaml = string.Empty;

            xaml = "<DataTemplate><TextBlock Text=\"{Binding Value}\"/></DataTemplate>";

            sr = new MemoryStream(Encoding.ASCII.GetBytes(xaml));

            pc = new ParserContext();

            pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");

            pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");

            DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sr, pc);

            this.Resources.Add("dt", datatemplate);

            this.ItemTemplate = datatemplate;*/

            DisplayMemberPath = "Name";
            SelectedValuePath = "Value";

            SelectionChanged += new SelectionChangedEventHandler(EnumerationComboBoxTemp_SelectionChanged);
          
        }

        void EnumerationComboBoxTemp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  Get the new item.
          if (e.AddedItems.Count == 0 || e.AddedItems[0] is NameValue == false)
            return;
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

            //  Get the enum values.
            var enumValues = Enum.GetValues(enumType);

            //  Create some enum value/descriptions.
            Enumerations = new List<NameValue>();
          
            //  Go through each one.
            foreach (var enumValue in enumValues)
            {
                //  Add the enumeration item.
              Enumerations.Add(new NameValue(GetEnumName(enumType, enumValue), enumValue));
            }

            //  Set the items source.
            ItemsSource = Enumerations;
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

        
        private static readonly DependencyProperty SelectedEnumerationProperty =
          DependencyProperty.Register("SelectedEnumeration", typeof(object), typeof(EnumerationComboBox),
          new PropertyMetadata(null, new PropertyChangedCallback(OnSelectedEnumerationChanged)));

        public object SelectedEnumeration
        {
          get { return (object)GetValue(SelectedEnumerationProperty); }
          set { SetValue(SelectedEnumerationProperty, value); }
        }

        private static void OnSelectedEnumerationChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
          EnumerationComboBox me = o as EnumerationComboBox;

          //  Populate the items source.
          me.PopulateItemsSource();
        }

        public List<NameValue> Enumerations
        {
          get;
          set;
        }
    }

    public class NameValue
    {
      public NameValue()
      {

      }

      public NameValue(string name, object value)
      {
        Name = name;
        Value = value;
      }

      public string Name
      {
        get;
        set;
      }

      public object Value
      {
        get;
        set;
      }
    }
}