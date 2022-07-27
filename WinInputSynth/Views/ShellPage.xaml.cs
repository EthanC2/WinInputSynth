using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.ApplicationModel.Core;

using System.Threading.Tasks;

using WinInputSynth.Contracts.Services;
using WinInputSynth.Helpers;
using WinInputSynth.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinInputSynth.Views;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ShellPage : Page
{
    public ShellViewModel ViewModel { get; }
    public INavigationService NavigationService { get; }

    public ShellPage(ShellViewModel viewModel, INavigationService navigationService)
    {
        ViewModel = viewModel;
        NavigationService = navigationService;

        InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;

        App.MainWindow.ExtendsContentIntoTitleBar = true;
        App.MainWindow.SetTitleBar(AppTitleBar);
    }

    public void NavigationView_Loaded(object sender, RoutedEventArgs e)
    {
        //System.Diagnostics.Debug.Assert(Frame is not null);
        //Frame.Navigate(typeof(MousePage));
    }

    public void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        Type type = typeof(MousePage);
        System.Diagnostics.Debug.Assert(type is not null);
        System.Diagnostics.Debug.Assert(NavigationService.Frame is not null);
        NavigationService.Frame.Navigate(type);

        //var naViewItemInvoked = (NavigationViewItem) args.SelectedItemContainer;

        //if (args.IsSettingsSelected)
        //{
        //    NavigationFrame.Navigate(typeof(SettingsPage));
        //}
        //else if (args.SelectedItemContainer is not null)
        //{
        //    var navItemTag = args.SelectedItemContainer?.Tag.ToString();
        //    Type page = Type.GetType(navItemTag);
        //    if (!String.IsNullOrEmpty(navItemTag))
        //    {
        //        NavigationFrame.Navigate(typeof(KeyboardPage));
        //    }
        //    else
        //    { 
        //        throw new ArgumentNullException(nameof(navItemTag));
        //    }
        //}
    }

    //private void myButton_Click(object sender, RoutedEventArgs e)
    //{
    //    myButton.Content = "Clicked";
    //}
}
