using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using магазин_3;

namespace магазин_3
{
    internal class складовщик : контроллер
    {
        public string Username = "складовщик";
        public string Password = "12";

        static string o;
        static int aa;
        public static void Sklad_menu(string q, int qq)
        {
            o = q;
            aa = qq;
            List<Tovar> list = Json_говно.Mydeserial<List<Tovar>>("Tovar.json");
            Tovar tovar = new Tovar();

            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Приветствую {q}");
            Console.SetCursorPosition(60, 0);
            Админ.Text(qq, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Название товара");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Цена за штуку");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Общее количество");
            int i = 3;
            foreach (Tovar u2 in list)
            {
                Console.SetCursorPosition(12, i);
                Console.WriteLine(u2.ID);
                Console.SetCursorPosition(25, i);
                Console.WriteLine(u2.NameOf);
                Console.SetCursorPosition(45, i);
                Console.WriteLine(u2.priceFor1);
                Console.SetCursorPosition(65, i);
                Console.WriteLine(u2.sklad);
                i++;
            }
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(100, t);
                Console.WriteLine("|");
                t++;
            }
            Console.SetCursorPosition(102, 2);
            Console.WriteLine("F1 - добавить");
            Console.SetCursorPosition(102, 3);
            Console.WriteLine(" пункт");
            Console.SetCursorPosition(102, 4);
            Console.WriteLine("F2 - поиск");
            Console.SetCursorPosition(102, 5);
            Console.WriteLine("по индексу");
            Админ.selected = Стрелки.Checker(3, list.Count, list, "Tovar.json");
            if (Админ.selected >= 3)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Приветствую {q}!");
                Console.SetCursorPosition(60, 0);
                Админ.Text(qq, 0);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"  ID: {list[Админ.selected - 3].ID}");
                Console.WriteLine($"  Название товара: {list[Админ.selected - 3].NameOf}");
                Console.WriteLine($"  Цена за штуку: {list[Админ.selected - 3].priceFor1}");
                Console.WriteLine($"  Общее количество: {list[Админ.selected - 3].sklad}");
                t = 2;
                while (t <= 15)
                {
                    Console.SetCursorPosition(58, t);
                    Console.WriteLine("|");
                    t++;
                }
                Console.SetCursorPosition(60, 2);
                Console.WriteLine("F10 - изменить");
                Console.SetCursorPosition(60, 3);
                Console.WriteLine("пункт");
                Console.SetCursorPosition(60, 4);
                Console.WriteLine("Del - удалить пункт");
                Console.SetCursorPosition(60, 5);
                Console.WriteLine("пункт");
                Console.SetCursorPosition(60, 6);
                Console.WriteLine("Esc - вернуться");
                Console.SetCursorPosition(60, 7);
                Console.WriteLine("в меню");
                int sel = Стрелки.Checker(2, 4, list, "Tovar.json");
                if (sel == -10)
                {
                    Sklad_menu(q, qq);
                }
                if (sel == -11)
                {
                    Sklad_menu(q, qq);
                }
                if (sel == -2)
                {
                    Console.SetCursorPosition(60, 10);
                    Console.WriteLine("S -cохранить");
                    while (true)
                    {
                        int selected = Стрелки.Checker(2, 10, list, "Tovar.json");
                        if (selected == 2)
                        {
                            try
                            {
                                var e = tovar.ID.ToString();
                                list[Админ.selected - 3].ID = Convert.ToInt32(Update(e, "  ID: "));
                            }
                            catch
                            {
                                Console.SetCursorPosition(60, 11);
                                Console.WriteLine("Недопустимое значение, попробуйте снова");
                                var e = tovar.ID.ToString();
                                list[Админ.selected - 3].ID = Convert.ToInt32(Update(e, "  ID: "));
                            }
                        }
                        else if (selected == 3)
                        {
                            list[Админ.selected - 3].NameOf = Update(tovar.NameOf, "  Название товара: ");
                        }
                        else if (selected == 4)
                        {
                            var e = tovar.priceFor1.ToString();
                            list[Админ.selected - 3].priceFor1 = Convert.ToDouble(Update(e, "  Цена за штуку: "));
                        }
                        else if (selected == 5)
                        {
                            var e = tovar.sklad.ToString();
                            list[Админ.selected - 3].sklad = Convert.ToInt32(Update(e, "  Общее количество: "));
                        }
                        else if (selected == -9)
                        {
                            Json_говно.MySeri(list, "Tovar.json");
                            Sklad_menu(q, qq);
                        }
                        else if (selected == -10)
                        {
                            Sklad_menu(q, qq);
                        }
                    }
                }
            }
            else if (Админ.selected == -4)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($" Приветствую {q}");
                Console.SetCursorPosition(60, 0);
                Админ.Text(qq, 0);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("  ID: ");
                Console.WriteLine("  Название товара: ");
                Console.WriteLine("  Цена за штуку: ");
                Console.WriteLine("  Общее количество: ");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(70, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                Console.SetCursorPosition(72, 4);
                Console.WriteLine("S - сохранить");
                Console.SetCursorPosition(72, 5);
                Console.WriteLine("Esc - выйти в меню");
                while (true)
                {
                    int selected = Стрелки.Checker(2, 10, list, "Tovar.json");
                    if (selected == 2)
                    {
                        var e = tovar.ID.ToString();
                        try
                        {
                            tovar.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                        catch
                        {
                            Console.SetCursorPosition(72, 11);
                            Console.WriteLine("Недопустимое значение, попробуйте снова");
                            Console.SetCursorPosition(8, 2);
                            tovar.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                    }
                    else if (selected == 3)
                    {
                        tovar.NameOf = Update(tovar.NameOf, "  Название товара: ");
                    }
                    else if (selected == 4)
                    {
                        var e = tovar.priceFor1.ToString();
                        tovar.priceFor1 = Convert.ToDouble(Update(e, "  Цена за штуку: "));
                    }
                    else if (selected == 5)
                    {
                        var e = tovar.sklad.ToString();
                        tovar.sklad = Convert.ToInt32(Update(e, "  Общее количество: "));
                    }
                    else if (selected == -9)
                    {
                        list.Add(tovar);
                        Json_говно.MySeri(list, "Tovar.json");
                        Sklad_menu(q, qq);
                    }
                    else if (selected == -10)
                    {
                        Sklad_menu(q, qq);
                    }
                }
            }
            else if (Админ.selected == -5)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($" Приветствую {q}");
                Console.SetCursorPosition(60, 0);
                Админ.Text(qq, 0);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("Выберите, по какому пункту вы хотите произвести поиск:");
                Console.WriteLine("  ID");
                Console.WriteLine("  Название товара");
                Console.WriteLine("  Цена за штуку");
                Console.WriteLine("  Общее количество");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(60, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                int sel = Стрелки.Checker(3, 4, list, "Tovar.json");
                if (sel == 3)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int id = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < list.Count; ii++)
                    {

                        if (list[ii].ID == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(list[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(list[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(list[ii].priceFor1);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(list[ii].sklad);

                            r++;
                            int se = Стрелки.Checker(3, r, list, "Tovar.json");
                            if (se == -10)
                            {
                                Sklad_menu(q, qq);
                            }
                        }
                    }
                }
                if (sel == 4)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string idi = Console.ReadLine();
                    int r = 3;
                    for (int ii = 0; ii < list.Count; ii++)
                    {
                        if (list[ii].NameOf == idi)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(list[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(list[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(list[ii].priceFor1);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(list[ii].sklad);

                            r++;
                            int se = Стрелки.Checker(3, r, list, "Tovar.json");
                            if (se == -10)
                            {
                                Sklad_menu(q, qq);
                            }
                        }
                    }
                }
                if (sel == 5)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int ido = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < list.Count; ii++)
                    {

                        if (list[ii].priceFor1 == ido)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(list[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(list[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(list[ii].priceFor1);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(list[ii].sklad);

                            r++;
                            int se = Стрелки.Checker(3, r, list, "Tovar.json");
                            if (se == -10)
                            {
                                Sklad_menu(q, qq);
                            }
                        }
                    }
                }
                if (sel == 6)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int ida = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < list.Count; ii++)
                    {
                        if (list[ii].sklad == ida)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(list[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(list[ii].NameOf);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(list[ii].priceFor1);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(list[ii].sklad);

                            r++;
                            int se = Стрелки.Checker(3, r, list, "Tovar.json");
                            if (se == -10)
                            {
                                Sklad_menu(q, qq);
                            }
                        }
                    }
                }
            }
            else if (Админ.selected == -10)
            {
                Program.Main();
            }
        }
        private static void Printed()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Приветствую {o}");
            Console.SetCursorPosition(60, 0);
            Админ.Text(aa, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Название товара");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Цена за штуку");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Общее количество");
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(108, t);
                Console.WriteLine("|");
                t++;
            }
        }
    }
}