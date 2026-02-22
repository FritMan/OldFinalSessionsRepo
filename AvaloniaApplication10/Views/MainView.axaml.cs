using System;
using Avalonia.Controls;
using System.IO;
using Microsoft.EntityFrameworkCore;
using static AvaloniaApplication10.Classes.Helper;

namespace AvaloniaApplication10.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        MainMainFrame = MainFrame;
        MainMainFrame.Content = new AuthView();
        
        Db.Roles.Load();
        Db.Users.Load();
        ExpanderUser = UserExp;
    }
}