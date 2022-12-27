using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace магазин_3
{
    internal class Кассир
    {
        static double w;
        static int l;
        public static void Cashier_Menu(string g, int rota, int r = 0)
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Приветствую {g}");
            Console.SetCursorPosition(60, 0);
            Админ.Text(rota, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Название товара");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Цена за штуку");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Количество");
            int t = 2;
            while (t <= 15)
            {
                Console.SetCursorPosition(95, t);
                Console.WriteLine("|");
                t++;
            }
            List<Tovar> tovars = json_говно.Mydeserial<List<Tovar>>("Tovar.json");

            Console.SetCursorPosition(97, 3);
            Console.WriteLine("S - завершить покупку ");
            Console.SetCursorPosition(97, 4);
            Console.WriteLine("Esc - вернуться в меню");

            int i = 3;
            foreach (Tovar tovar in tovars)
            {
                Console.SetCursorPosition(12, i);
                Console.WriteLine(tovar.ID);
                Console.SetCursorPosition(25, i);
                Console.WriteLine(tovar.NameOf);
                Console.SetCursorPosition(50, i);
                Console.WriteLine(tovar.priceFor1);
                Console.SetCursorPosition(70, i);
                Console.WriteLine(tovar.p);
                i++;
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine($"                                                             Итог: {w}");
            Админ.selected = Стрелки.Checker(3, tovars.Count, tovars, "Tovar.json");
            if (Админ.selected >= 3)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Приветствую {g}!");
                Console.SetCursorPosition(60, 0);
                Админ.Text(rota, 0);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"  ID: {tovars[Админ.selected - 3].ID}");
                Console.WriteLine($"  Название: {tovars[Админ.selected - 3].NameOf}");
                Console.WriteLine($"  Цена за штуку: {tovars[Админ.selected - 3].priceFor1}");
                Console.WriteLine($"  Количество: {tovars[Админ.selected - 3].p}");
                t = 2;
                while (t <= 15)
                {
                    Console.SetCursorPosition(58, t);
                    Console.WriteLine("|");
                    t++;
                }
                Console.SetCursorPosition(60, 2);
                Console.WriteLine("'+' - прибавить");
                Console.SetCursorPosition(60, 3);
                Console.WriteLine("'-'  - убавить ");
                Console.SetCursorPosition(60, 4);
                Console.WriteLine("Esc - вернуться в меню");
                tovars[Админ.selected - 3].p = 0;
                l = 0;
                while (true)
                {

                    int sel = Стрелки.Checker(2, 4, tovars, "Tovar.json");
                    if (sel == -20)
                    {
                        if (tovars[Админ.selected - 3].p <= tovars[Админ.selected - 3].sklad && tovars[Админ.selected - 3].p >= 0)
                        {
                            tovars[Админ.selected - 3].p = tovars[Админ.selected - 3].p + 1;
                            Console.SetCursorPosition(2, 5);
                            Console.WriteLine($"Количество: {tovars[Админ.selected - 3].p}");
                        }
                    }
                    else if (sel == -21)
                    {
                        if (tovars[Админ.selected - 3].p <= tovars[Админ.selected - 3].sklad && tovars[Админ.selected - 3].p >= 0)
                        {
                            tovars[Админ.selected - 3].p = tovars[Админ.selected - 3].p - 1;
                            Console.SetCursorPosition(2, 5);
                            Console.WriteLine($"Количество: {tovars[Админ.selected - 3].p}");
                        }
                    }
                    else if (sel == -10)
                    {
                        tovars[Админ.selected - 3].sklad -= tovars[Админ.selected - 3].p;
                        tovars[Админ.selected - 3].pokupka = tovars[Админ.selected - 3].p * tovars[Админ.selected - 3].priceFor1;
                        w = w + tovars[Админ.selected - 3].p * tovars[Админ.selected - 3].priceFor1;
                        l = l + tovars[Админ.selected - 3].p;
                        tovars[Админ.selected - 3].p = l;
                        json_говно.MySeri(tovars, "Tovar.json");
                        Cashier_Menu(g, rota, tovars[Админ.selected - 3].p);
                    }
                }
            }
            if (Админ.selected == -10)
            {
                Cashier_Menu(g, rota);
            }
            else if (Админ.selected == -9)
            {
                List<Buh_uchyot> u = json_говно.Mydeserial<List<Buh_uchyot>>("Buh.json");
                foreach (Tovar tovar in tovars)
                {
                    Buh_uchyot buh_Uchyot = new Buh_uchyot();
                    buh_Uchyot.ID = tovar.ID;
                    buh_Uchyot.NameOf = tovar.NameOf;
                    buh_Uchyot.Zarplata = tovar.pokupka;
                    buh_Uchyot.time = DateTime.Now;
                    buh_Uchyot.tf = true;
                    u.Add(buh_Uchyot);
                    json_говно.MySeri(u, "Buh.json");
                }
                w = 0;
                int k = 3;
                while (k <= 4)
                {
                    Console.SetCursorPosition(97, k);
                    Console.WriteLine("                                ");
                    k++;
                }
                Console.SetCursorPosition(97, 3);
                Console.WriteLine("Сохранено!");
                foreach (Tovar tovar in tovars)
                {
                    tovar.p = 0;
                    tovar.pokupka = 0;
                    json_говно.MySeri(tovars, "Tovar.json");
                }
                Админ.selected = Стрелки.Checker(3, tovars.Count, tovars, "Tovar.json");
                if (Админ.selected == -10)
                {
                    Program.Main();
                }
            }
        }
    }
}