using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using SimpleInjector;

namespace IdeapadToolkit.Services
{
    public class NavigationService : INavigationService
    {
        public Frame? NavFrame { get; set; }

        public NavigationService(Container container)
        {
            this._container = container;
        }
        
        public bool CanGoBack
        {
            get
            {
                return this.NavFrame?.CanGoBack ?? false;
            }
        }
        public void GoBack()
        {
            NavFrame?.GoBack();
        }

        public void Navigate<TElement>(object? args) where TElement : UIElement
        {
            NavFrame?.Navigate(this._container.GetInstance<TElement>(), args);
        }
        public void Navigate(Type page, object? args)
        {
            NavFrame?.Navigate(this._container.GetInstance(page), args);
        }

        private readonly Container _container;
    }
}
