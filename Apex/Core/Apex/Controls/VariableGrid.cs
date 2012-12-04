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
using System.Windows.Shapes;
using System.ComponentModel;
using Apex.MVVM;

namespace Apex.Controls
{
    /// <summary>
    /// VariableGrid class - supports a grid with a variable number of rows or columns.
    /// </summary>
    public class VariableGrid : Grid
    {
        /// <summary>
        /// Called when [grid property changed].
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnGridPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            //  Get the grid.
            var me = (VariableGrid) dependencyObject;

            //  Clear the rows and columns.
            me.RowDefinitions.Clear();
            me.ColumnDefinitions.Clear();

            //  Rows and columns must be positive.
            if (me.Rows < 0 || me.Columns < 0)
                return;

            //  Create a grid length converter.
            var gridLengthConverter = new Consistency.GridLengthConverter();

            //  Add each row.
            for (int i = 0; i < me.Rows; i++)
                me.RowDefinitions.Add(new RowDefinition() {Height = gridLengthConverter.ConvertFromString(me.RowHeight)});

            //  Add each column.
            for (int i = 0; i < me.Columns; i++)
                me.ColumnDefinitions.Add(new ColumnDefinition() {Width = gridLengthConverter.ConvertFromString(me.ColumnWidth)});
        }

        /// <summary>
        /// The rows dependency property.
        /// </summary>
        private static readonly DependencyProperty rowsProperty =
            DependencyProperty.Register("Rows", typeof (int), typeof (VariableGrid),
                                        new PropertyMetadata(1, new PropertyChangedCallback(OnGridPropertyChanged)));

        /// <summary>
        /// The columns dependency property.
        /// </summary>
        private static readonly DependencyProperty columnsProperty =
            DependencyProperty.Register("Columns", typeof (int), typeof (VariableGrid),
                                        new PropertyMetadata(1, new PropertyChangedCallback(OnGridPropertyChanged)));

        /// <summary>
        /// The rows dependency property.
        /// </summary>
        private static readonly DependencyProperty rowHeightProperty =
            DependencyProperty.Register("RowHeight", typeof (string), typeof (VariableGrid),
                                        new PropertyMetadata("Auto", new PropertyChangedCallback(OnGridPropertyChanged)));

        /// <summary>
        /// The columns dependency property.
        /// </summary>
        private static readonly DependencyProperty columnsWidthProperty =
            DependencyProperty.Register("ColumnWidth", typeof (string), typeof (VariableGrid),
                                        new PropertyMetadata("Auto", new PropertyChangedCallback(OnGridPropertyChanged)));

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>The rows.</value>
        [Description("The number of rows."), Category("Common Properties")]
        public int Rows
        {
            get { return (int) GetValue(rowsProperty); }
            set { SetValue(rowsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>The columns.</value>
        [Description("The number of columns."), Category("Common Properties")]
        public int Columns
        {
            get { return (int) GetValue(columnsProperty); }
            set { SetValue(columnsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the height of the row.
        /// </summary>
        /// <value>
        /// The height of the row.
        /// </value>
        [Description("The row height property (used for all rows)."), Category("Common Properties")]
        public string RowHeight
        {
            get { return (string) GetValue(rowHeightProperty); }
            set { SetValue(rowHeightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the width of the column.
        /// </summary>
        /// <value>
        /// The width of the column.
        /// </value>
        [Description("The column width property (used for all columns)."), Category("Common Properties")]
        public string ColumnWidth
        {
            get { return (string) GetValue(columnsWidthProperty); }
            set { SetValue(columnsWidthProperty, value); }

        }
    }
}