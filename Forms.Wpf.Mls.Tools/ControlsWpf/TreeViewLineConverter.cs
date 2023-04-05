namespace Forms.Wpf.Mls.Tools.ControlsWpf;

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

public class TreeViewLineConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        TreeViewItem? item = values[2] as TreeViewItem;
        ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(item);
        bool isLastOne = ic.ItemContainerGenerator.IndexFromContainer(item) == ic.Items.Count - 1;
        Rectangle? rectangle = values[3] as Rectangle;
        if (isLastOne)
        {
            if (rectangle != null)
                rectangle.VerticalAlignment = VerticalAlignment.Top;
            return 9.0;
        }
        else
        {
            if (rectangle != null)
                rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            return double.NaN;
        }
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}