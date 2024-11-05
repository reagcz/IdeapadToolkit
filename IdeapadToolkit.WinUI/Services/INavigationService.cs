using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;

namespace IdeapadToolkit.WinUI3.Services;
internal interface INavigationService
{
    public Frame? NavFrame { get; set; }
    public bool CanGoBack { get; }
    public void GoBack();
    public void Navigate<TElement>(object? args = null, NavigationTransitionInfo? navigationTransitionInfo = null) where TElement : UIElement;
    public void Navigate(Type page, object? args = null, NavigationTransitionInfo? navigationTransitionInfo = null);
}
