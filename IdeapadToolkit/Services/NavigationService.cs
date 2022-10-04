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
            if (NavFrame != null)
            {
                NavFrame.GoBack();
            }
        }

        public void Navigate<TElement>(object args) where TElement : UIElement
        {
            if (NavFrame != null)
            {
                NavFrame.Navigate(this._container.GetInstance<TElement>(), args);
            }
        }
        public void Navigate(Type page, object args)
        {
            if (NavFrame != null)
            {
                NavFrame.Navigate(this._container.GetInstance(page), args);
            }
        }

        private readonly Container _container;
    }
}
