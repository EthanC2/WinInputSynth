using System;
using System.Collections.Generic;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using WinInputSynth.Contracts.Services;
using WinInputSynth.ViewModels;
using WinInputSynth.Views;

namespace WinInputSynth.Services;

public class PageService : IPageService
{
    private readonly HashSet<Type> _pages;
    public HashSet<Type> Pages => _pages;

    public PageService()
    {
        _pages = new HashSet<Type>();
        Register<ShellPage>();
        Register<MousePage>();
        Register<KeyboardPage>();
        Register<MouseAndKeyboardPage>();
        Register<SettingsPage>();
    }

    public bool PageExists(Type page)
    { 
        return _pages.Contains(page);
    }

    private void Register<P>() where P : Page
    {
        Type page = typeof(P);
        lock (_pages)
        {
            if (_pages.Contains(page))
            {
                throw new ArgumentException($"The key {page} is already configured in PageService");
            }

            _pages.Add(typeof(P));
        }
    }
}
