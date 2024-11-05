using CommunityToolkit.Mvvm.Input;
using IdeapadToolkit.WinUI3.Localization;
using IdeapadToolkit.WinUI3.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Windows.Input;

namespace IdeapadToolkit.WinUI3.Views;

public sealed partial class TrayIconView : Page
{
    public TrayIconView()
    {
        InitializeComponent();
        ViewModel = App.Composition.Resolve<MainPageViewModel>();
    }

    internal MainPageViewModel ViewModel { get; }

    public event EventHandler TrayIconClicked;

    [RelayCommand]
    private void OnTrayIconClicked()
    {
        TrayIconClicked?.Invoke(this, EventArgs.Empty);
    }

    public void MakeVisible()
    {
        TrayIcon.ForceCreate();
        TrayIcon.Visibility = Visibility.Visible;
        TrayIcon.LeftClickCommand = TrayIconClickedCommand;
        RefreshBindings();
    }

    private void MenuItemExit_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void RefreshBindings()
    {
        ViewModel.Refresh();

        RadioConservation.IsChecked = ViewModel.IsConservationModeEnabled;
        RadioConservation.Text = Strings.CONSERVATION;
        RadioConservation.Command = ViewModel.SetChargingModeCommand;
        RadioConservation.CommandParameter = 0;

        RadioNormal.IsChecked = ViewModel.IsNormalModeEnabled;
        RadioNormal.Text = Strings.NORMAL;
        RadioNormal.Command = ViewModel.SetChargingModeCommand;
        RadioNormal.CommandParameter = 1;

        RadioRapid.IsChecked = ViewModel.IsRapidModeEnabled;
        RadioRapid.Text = Strings.RAPID;
        RadioRapid.Command = ViewModel.SetChargingModeCommand;
        RadioRapid.CommandParameter = 2;

        RadioBatterySaving.IsChecked = ViewModel.IsEfficientChecked;
        RadioBatterySaving.Text = Strings.BATTERY_SAVING;
        RadioBatterySaving.Command = ViewModel.SetPlanCommand;
        RadioBatterySaving.CommandParameter = 2;

        RadioIntelligent.IsChecked = ViewModel.IsIntelligentCoolingChecked;
        RadioIntelligent.Text = Strings.INTELLIGENT_COOLING;
        RadioIntelligent.Command = ViewModel.SetPlanCommand;
        RadioIntelligent.CommandParameter = 1;

        RadioExtreme.IsChecked = ViewModel.IsExtremePerformanceChecked;
        RadioExtreme.Text = Strings.EXTREME_PERFORMANCE;
        RadioExtreme.Command = ViewModel.SetPlanCommand;
        RadioExtreme.CommandParameter = 3;

        TrayIcon.UpdateLayout();
    }

    private void RadioConservation_Loaded(object sender, RoutedEventArgs e)
    {
        RadioConservation.IsChecked = ViewModel.IsConservationModeEnabled;
        RadioNormal.IsChecked = ViewModel.IsNormalModeEnabled;
        RadioRapid.IsChecked = ViewModel.IsRapidModeEnabled;
        RadioBatterySaving.IsChecked = ViewModel.IsEfficientChecked;
        RadioIntelligent.IsChecked = ViewModel.IsIntelligentCoolingChecked;
        RadioExtreme.IsChecked = ViewModel.IsExtremePerformanceChecked;
        TrayIcon.UpdateLayout();
    }
}