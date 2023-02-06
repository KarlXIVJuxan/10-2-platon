using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace магазин_3
{
    internal class контроллер
    {
        public static string Update(string sin, string txt)
        {
            Console.SetCursorPosition(Console.CursorLeft + txt.Length, Console.CursorTop - 0);
            Console.WriteLine("                     ");
            Console.SetCursorPosition(Console.CursorLeft + txt.Length + 1, Console.CursorTop - 1);
            sin = Console.ReadLine();
            return sin;
        }
        public static void Delete<T>(List<T> д, string file)
        {
            д.RemoveAt(Админ.selected - 3);
            Json_говно.MySeri(д, file);
            return;
        }
    }
}