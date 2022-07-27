using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

using WinInputSynth.Contracts.Services;
using WinInputSynth.Views;  

namespace WinInputSynth.ViewModels;

public class ShellViewModel : ObservableRecipient
{
    private bool _isBackEnabled;
    private object _selected;
    private ICommand _menuFileExitCommand;
    private ICommand _menuSettingsCommand;
    private ICommand _menuViewsMouseCommand;
    private ICommand _menuViewsKeyboardCommand;
    private ICommand _menuViewsMouseAndKeyboard;

    public ICommand MenuFileExitCommand => _menuFileExitCommand ??= new RelayCommand(OnMenuFileExit);

    public ICommand MenuSettingsCommand => _menuSettingsCommand ??= new RelayCommand(OnMenuSettings);

    public ICommand MenuViewsMouseCommand => _menuViewsMouseCommand ??= new RelayCommand(OnMenuViewsMouse);

    public ICommand MenuViewsKeyboardCommand => _menuViewsKeyboardCommand ??= new RelayCommand(OnMenuViewsKeyboard);

    public ICommand MenuViewsMouseAndKeyboardCommand => _menuViewsMouseAndKeyboard ??= new RelayCommand(OnMenuViewsMouseAndKeyboard);

    public INavigationService NavigationService { get; }

    public bool IsBackEnabled
    {
        get => _isBackEnabled;
        set => SetProperty(ref _isBackEnabled, value);
    }

    public object Selected
    {
        get => _selected;
        set => SetProperty(ref _selected, value);
    }

    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    private void OnMenuFileExit() => Application.Current.Exit();

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsPage));

    private void OnMenuViewsMouse() => NavigationService.NavigateTo(typeof(MousePage));

    private void OnMenuViewsKeyboard() => NavigationService.NavigateTo(typeof(KeyboardPage));

    private void OnMenuViewsMouseAndKeyboard() => NavigationService.NavigateTo(typeof(MouseAndKeyboardPage));
}
