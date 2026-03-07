using System;
using Avalonia.Controls;
using System.IO;
using System.Linq;
using Avalonia.Interactivity;
using Avalonia.Threading;
using AvaloniaApplication10.Data;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using static AvaloniaApplication10.Classes.Helper;

namespace AvaloniaApplication10.Views;

public partial class AuthView : UserControl
{
    private int count = 0;
    private string globalpass = "";
    
    private DispatcherTimer timer =  new DispatcherTimer {Interval = TimeSpan.FromSeconds(20)};
    public AuthView()
    {
        InitializeComponent();
        Generate();
        timer.Tick += TimerOnTick;
    }

    private void Generate()
    {
        var temp = Path.GetTempPath();
        Random random  = new Random();

        var alph = "1234567890!@#%&qwertyuiopasdfghjklzxcvbnm";
        var pass = "";

        for (int i = 0; i < 7; i++)
        {
            var sym = alph[random.Next(0, alph.Length)];
            pass += sym;
        }
        
        
        string date = DateTime.Now.ToString("u");

        date = date.Replace(" ", "T");
        
        string passdate = date + " - "  + pass;
        globalpass = pass;

        if (File.Exists(temp + "passcode.txt"))
        {
            File.Delete(temp + "passcode.txt");
            File.WriteAllText(temp + "passcode.txt", passdate);
        }
        else
        {
            File.WriteAllText("passcode.txt", passdate);
        }
    }

    private void CodeBtn_OnClick(object? sender, RoutedEventArgs e)
    {

        bool glob = true;
        
       if (glob == true)
        {
            MainMainFrame.Content = new AnotherViews.MenuView();
            ExpanderUser.IsVisible = true;
            ExpanderUser.DataContext = AuthUser;
        }
      else
        {
            count++;

            if (count == 3)
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка","Блокировка на 20 секунд", ButtonEnum.Ok, Icon.Error).ShowAsync();
                timer.Start();
                OkBtn.IsEnabled = false;
                CodeBtn.IsEnabled = false;
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка","Неверный код", ButtonEnum.Ok, Icon.Error).ShowAsync();
            }
        }
    }

    private void TimerOnTick(object? sender, EventArgs e)
    {
        OkBtn.IsEnabled = true;
        CodeBtn.IsEnabled = true;
        timer.Stop();
        count = 0;
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var user = Db.Users.FirstOrDefault(el => el.Password == PasswordTb.Text && el.Login == LogiTb.Text);

        if (user != null)
        {
            LoginStack.IsVisible = false;
            CodeStack.IsVisible = true;

            AuthUser = user;
        }
        else
        {
            count++;

            if (count == 1)
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка","Блокировка на 20 секунд", ButtonEnum.Ok, Icon.Error).ShowAsync();
                timer.Start();
                OkBtn.IsEnabled = false;
                CodeBtn.IsEnabled = false;
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка","Неверный логин или пароль", ButtonEnum.Ok, Icon.Error).ShowAsync();
            }
        }
    }
}