using System.IO;
using static AvaloniaApplication10.Classes.Helper;

namespace AvaloniaApplication10.Data;

public partial class User
{
    public byte[] PhotoEdited
    {
        get
        {
            if (Photo != null)
            {
                return Photo;
                
            }
            else
            {
                return File.ReadAllBytes("C:\\Users\\Ансар\\RiderProjects\\AvaloniaApplication10\\AvaloniaApplication10\\Assets\\0676db33732acc9f36eaf8f965176db3.jpg");
            }
        }
    }

    public string Fio
    {
        get
        {
            return $"{Surname} {Name[0]}.{Patronimic[0]}.";
        }
    }
}