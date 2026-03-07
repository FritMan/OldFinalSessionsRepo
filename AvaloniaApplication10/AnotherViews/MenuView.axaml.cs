using System;
using System.Collections.Generic;
using Avalonia.Controls;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Input;
using AvaloniaApplication10.Data;
using AvaloniaApplication10.Views;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using Microsoft.EntityFrameworkCore;
using static AvaloniaApplication10.Classes.Helper;

namespace AvaloniaApplication10.AnotherViews;

public partial class MenuView : UserControl
{
    public MenuView()
    {
        InitializeComponent();
        MenuFrame.Content = new GraphView();
    }
    
    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        MenuFrame.Content = new VendingView();
    }
}