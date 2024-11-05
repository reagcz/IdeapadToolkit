using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace IdeapadToolkit.WinUI3.Helpers;

public partial class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool booleanValue)
        {
            return booleanValue ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }
        return false;
    }
}

public partial class InvertedBoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool booleanValue)
        {
            return !booleanValue ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is Visibility visibility)
        {
            return visibility != Visibility.Visible;
        }
        return false;
    }
}
