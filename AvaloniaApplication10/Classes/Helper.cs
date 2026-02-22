using Avalonia.Controls;
using AvaloniaApplication10.Data;

namespace AvaloniaApplication10.Classes;

public static class Helper
{
    public static ContentControl MainMainFrame = new ContentControl();
    
    public static OldfinaldbContext Db = new OldfinaldbContext();

    public static User AuthUser;

    public static Expander ExpanderUser;
}