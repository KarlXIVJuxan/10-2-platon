using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace магазин_3
{
    internal class Стрелки : контроллер
    {
        private static string name;
        public static int Checker<T>(int startPos, int count, List<T> t, string f, string arrow = "->")
        {
            string empty = new string(' ', arrow.Length);
            int i = startPos;
            Console.SetCursorPosition(0, startPos);
            Console.Write(arrow);
            ConsoleKeyInfo key;
            for (; ; )
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (i == count + startPos - 1)
                        continue;
                    Console.SetCursorPosition(0, i);
                    Console.Write(empty);
                    Console.SetCursorPosition(0, ++i);
                    Console.Write(arrow);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (i == startPos)
                        continue;
                    Console.SetCursorPosition(0, i);
                    Console.Write(empty);
                    Console.SetCursorPosition(0, --i);
                    Console.Write(arrow);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return i;
                }
                else if (key.Key == ConsoleKey.F10)
                {
                    return -2;
                }
                else if (key.Key == ConsoleKey.Delete)
                {
                    Delete(t, f);
                    return -11;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return -10;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    return -4;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    return -9;

                }
                else if (key.Key == ConsoleKey.F2)
                {
                    return -5;

                }
                else if (key.Key == ConsoleKey.OemPlus)
                {
                    return -20;
                }
                else if (key.Key == ConsoleKey.OemMinus)
                {
                    return -21;
                }
            }
        }
    }
}