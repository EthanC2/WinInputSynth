using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using System;

namespace WinInputSynth.Contracts.Services;

public interface INavigationService
{
    event NavigatedEventHandler Navigated;
    bool CanGoBack { get; }
    Frame Frame { get; set; }
    bool NavigateTo(Type page, object parameter = null, bool clearNavigation = false);
    bool GoBack();
}
