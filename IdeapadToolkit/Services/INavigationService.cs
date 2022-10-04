using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace IdeapadToolkit.Services
{
    public interface INavigationService
    {
        Frame? NavFrame { get; set; }
        bool CanGoBack { get; }
        void GoBack();
        void Navigate<TElement>(object? args = null) where TElement : UIElement;
        void Navigate(Type page, object? args = null);
    }
}
