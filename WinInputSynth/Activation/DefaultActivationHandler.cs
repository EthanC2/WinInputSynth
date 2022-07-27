using System;
using System.Threading.Tasks;

using Microsoft.UI.Xaml;

using WinInputSynth.Contracts.Services;
using WinInputSynth.ViewModels;
using WinInputSynth.Views;

namespace WinInputSynth.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame.Content is null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _navigationService.NavigateTo(typeof(MousePage), args.Arguments);

        await Task.CompletedTask;
    }
}
