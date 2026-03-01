using System;
using Avalonia.Controls;
using System.IO;
using System.Linq;
using AvaloniaApplication10.Data;
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
        loadEffectChartData();
        loadStateChartData();
    }
    
    void loadEffectChartData()
    {
        Db.Vendings.Load();
        
        int efficient = (int)(100 * Db.Vendings.Where(el => el.StatusId == 1).Count() / (double)Db.Vendings.Count());
        
        var series = new SeriesCollection()
        {
            new PieSeries<int>()
            {
                InnerRadius = 30,
                Values = new int[] {100}
            }
        };
        MainNeedle.Value = efficient;
        
        EffectChart.Series = series;
        
        EffLabel.Content = $"Эффективность сети - {efficient.ToString()}%";
        EffLabel.FontSize = 20;
    }
    
    void loadStateChartData()
    {
        Db.Vendings.Load();
        Db.Statusvendings.Load();
        
        var series = new SeriesCollection()
        {
            new PieSeries<int>()
            {
                InnerRadius = 50,
                Name = "Не работает",
                Values = new int[] {Db.Vendings.Where(el => el.StatusId==2).Count()},
            },
            new PieSeries<int>()
            {
                InnerRadius = 50,
                Name = "Работает",
                Values = new int[] {Db.Vendings.Where(el => el.StatusId==1).Count()} 
            },
            new PieSeries<int>()
            {
                InnerRadius = 50,
                Name = "На обслуживании",
                Values = new int[] {Db.Vendings.Where(el => el.StatusId==3).Count()} 
            }
        };
        
        StateChart.Series = series;
    }
}