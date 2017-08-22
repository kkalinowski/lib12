using lib12.Collections;
using System;
using System.Windows;
using System.Windows.Controls;
using lib12.Misc;

namespace lib12.WPF.Controls.FluidGrid
{
    public static class FluidGrid
    {
        #region Rows
        public static string GetRows(DependencyObject dpObject)
        {
            return (string)dpObject.GetValue(RowsProperty);
        }

        public static void SetRows(DependencyObject dpObject, string value)
        {
            dpObject.SetValue(RowsProperty, value);
        }

        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.RegisterAttached("Rows", typeof(string), typeof(FluidGrid), new UIPropertyMetadata(string.Empty, Rows_Changed));

        private static void Rows_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = (Grid)sender;
            var rows = ((string)e.NewValue).Split(' ', ',');
            foreach (var row in rows)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = ParseGridLength(row) });
            }
        }
        #endregion

        #region Columns
        public static string GetColumns(DependencyObject dpObject)
        {
            return (string)dpObject.GetValue(ColumnsProperty);
        }

        public static void SetColumns(DependencyObject dpObject, string value)
        {
            dpObject.SetValue(ColumnsProperty, value);
        }

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.RegisterAttached("Columns", typeof(string), typeof(FluidGrid), new UIPropertyMetadata(string.Empty, Columns_Changed));

        private static void Columns_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = (Grid)sender;
            var columns = ((string)e.NewValue).Split(' ', ',');
            foreach (var column in columns)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = ParseGridLength(column) });
            }
        }
        #endregion

        #region StackRows
        public static string GetStackRows(DependencyObject dpObject)
        {
            return (string)dpObject.GetValue(StackRowsProperty);
        }

        public static void SetStackRows(DependencyObject dpObject, string value)
        {
            dpObject.SetValue(StackRowsProperty, value);
        }

        public static readonly DependencyProperty StackRowsProperty =
            DependencyProperty.RegisterAttached("StackRows", typeof(string), typeof(FluidGrid), new UIPropertyMetadata(string.Empty, StackRows_Changed));

        private static void StackRows_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = (Grid)sender;
            var text = (string)e.NewValue;
            if (text.Contains(","))
            {
                var settings = text.Split(',');
                var rows = int.Parse(settings[0]);
                var rowHeight = ParseGridLength(settings[1]);
                TimesLoop.Do(rows, () => grid.RowDefinitions.Add(new RowDefinition { Height = rowHeight }));
            }
            else
            {
                var rows = int.Parse(text);
                TimesLoop.Do(rows, () => grid.RowDefinitions.Add(new RowDefinition()));
            }
        }
        #endregion

        #region StackColumns
        public static string GetStackColumns(DependencyObject dpObject)
        {
            return (string)dpObject.GetValue(StackColumnsProperty);
        }

        public static void SetStackColumns(DependencyObject dpObject, string value)
        {
            dpObject.SetValue(StackColumnsProperty, value);
        }

        public static readonly DependencyProperty StackColumnsProperty =
            DependencyProperty.RegisterAttached("StackColumns", typeof(string), typeof(FluidGrid), new UIPropertyMetadata(string.Empty, StackColumns_Changed));

        private static void StackColumns_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = (Grid)sender;
            var text = (string)e.NewValue;
            if (text.Contains(","))
            {
                var settings = text.Split(',');
                var columns = int.Parse(settings[0]);
                var columnWidth = ParseGridLength(settings[1]);
                TimesLoop.Do(columns, () => grid.ColumnDefinitions.Add(new ColumnDefinition { Width = columnWidth }));
            }
            else
            {
                var columns = int.Parse(text);
                TimesLoop.Do(columns, () => grid.ColumnDefinitions.Add(new ColumnDefinition()));
            }
        }
        #endregion

        #region Logic
        private static GridLength ParseGridLength(string text)
        {
            if (text.Equals("Auto", StringComparison.OrdinalIgnoreCase))
            {
                return GridLength.Auto;
            }
            else if (text.Contains("*"))
            {
                text = text.Replace("*", "");
                if (text.IsNullOrEmpty())
                    return new GridLength(1, GridUnitType.Star);
                else
                    return new GridLength(double.Parse(text), GridUnitType.Star);
            }
            else
            {
                return new GridLength(double.Parse(text));
            }
        }
        #endregion
    }
}
