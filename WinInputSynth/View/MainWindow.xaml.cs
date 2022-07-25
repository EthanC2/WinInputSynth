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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinInputSynth.View;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    IList<string> mouseButtons, clickModes;
    /*private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
    {
    ("mouse", typeof(MousePage)),
    ("keyboard", typeof(KeyboardPage)),
    ("mouse+keyboard", typeof(MouseAndKeyboardPage)),
    ("settings", typeof(SettingsPage)),
    };*/

    public MainWindow()
    {
        InitializeComponent();
        Title = "A Windows Mouse and Keyboard Synthesizer";

        SetTitleBar(AppTitleBar);
        ExtendsContentIntoTitleBar = true;

        mouseButtons = new List<string>() { "Left", "Right", "Middle" };
        clickModes = new List<string>() { "Single Click", "Double Click" };
    }

    //private void myButton_Click(object sender, RoutedEventArgs e)
    //{
    //    myButton.Content = "Clicked";
    //}
}
