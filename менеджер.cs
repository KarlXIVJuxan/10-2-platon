using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace магазин_3
{
    internal class менеджер : контроллер
    {
        public string Username = "менеджер";
        public string Password = "1234";

        static string o;
        static int aa;
        public static void Manager_menu(string b, int q)
        {
            o = b;
            aa = q;
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Welcome {b}");
            Console.SetCursorPosition(60, 0);
            Админ.Text(q, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Фамилия");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Имя");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Отчество");
            Console.SetCursorPosition(85, 2);
            Console.WriteLine("Должность");
            List<Basa> u = Json_говно.Mydeserial<List<Basa>>("Basa.json");
            Basa login = new Basa();
            Basa basa = new Basa();
            int i = 3;

            foreach (Basa u2 in u)
            {

                Console.SetCursorPosition(12, i);
                Console.WriteLine(u2.ID);
                Console.SetCursorPosition(25, i);
                Console.WriteLine(u2.Surname);
                Console.SetCursorPosition(45, i);
                Console.WriteLine(u2.Name);
                Console.SetCursorPosition(65, i);
                Console.WriteLine(u2.NameOfName);
                Console.SetCursorPosition(85, i);
                Админ.Text(u2.Post, 0);
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
            Админ.selected = Стрелки.Checker(3, u.Count, u, "Basa.json");
            if (Админ.selected >= 3)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {b}!");
                Console.SetCursorPosition(60, 0);
                Админ.Text(q, 0);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine($"  ID: {u[Админ.selected - 3].ID}");
                Console.WriteLine($"  Фамилия: {u[Админ.selected - 3].Surname}");
                Console.WriteLine($"  Имя: {u[Админ.selected - 3].Name}");
                Console.WriteLine($"  Отчество: {u[Админ.selected - 3].NameOfName}");
                Console.WriteLine($"  День рождения: {u[Админ.selected - 3].birthday}");
                Console.WriteLine($"  Серия и номер паспорта: {u[Админ.selected - 3].pasport}");
                Админ.Text(u[Админ.selected - 3].Post, 1);
                Console.WriteLine($"  Зарплата: {u[Админ.selected - 3].Zarplata}");
                Console.WriteLine($"  Аккаунт сотрудника: {u[Админ.selected - 3].account}");
                t = 2;
                while (t <= 15)
                {
                    Console.SetCursorPosition(100, t);
                    Console.WriteLine("|");
                    t++;
                }
                Console.SetCursorPosition(102, 2);
                Console.WriteLine("F10 - изменить");
                Console.SetCursorPosition(102, 3);
                Console.WriteLine("пункт");
                Console.SetCursorPosition(102, 4);
                Console.WriteLine("Del - удалить пункт");
                Console.SetCursorPosition(102, 5);
                Console.WriteLine("пункт");
                Console.SetCursorPosition(102, 6);
                Console.WriteLine("Esc - вернуться");
                Console.SetCursorPosition(102, 7);
                Console.WriteLine("в меню");
                int sel = Стрелки.Checker(2, 10, u, "Basa.json");
                if (sel == -10)
                {
                    менеджер.Manager_menu(b, q);
                }
                if (sel == -11)
                {
                    менеджер.Manager_menu(b, q);
                }
                if (sel == -2)
                {
                    Console.SetCursorPosition(102, 2);
                    Console.WriteLine("0-Админ");
                    Console.SetCursorPosition(102, 3);
                    Console.WriteLine("1 - Кассир");
                    Console.SetCursorPosition(102, 4);
                    Console.WriteLine("2 - Кадровик");
                    Console.SetCursorPosition(102, 5);
                    Console.WriteLine("3 - Склад-менеджер");
                    Console.SetCursorPosition(102, 6);
                    Console.WriteLine("4 - Бухгалтер");
                    Console.SetCursorPosition(102, 7);
                    Console.WriteLine("S - сохранить изменения");
                    Console.SetCursorPosition(102, 8);
                    Console.WriteLine("S -cохранить");
                    while (true)
                    {
                        int selected = Стрелки.Checker(2, 10, u, "Basa.json");
                        if (selected == 2)
                        {
                            try
                            {
                                var e = login.ID.ToString();
                                u[Админ.selected - 3].ID = Convert.ToInt32(Update(e, "ID: "));
                            }
                            catch
                            {
                                Console.SetCursorPosition(102, 9);
                                Console.WriteLine("Недопустимое значение, попробуйте снова");
                                var e = login.ID.ToString();
                                Console.SetCursorPosition(8, 2);
                                u[Админ.selected - 3].ID = Convert.ToInt32(Update(e, "ID: "));
                            }
                        }
                        else if (selected == 3)
                        {
                            u[Админ.selected - 3].Surname = Update(login.Surname, "  Фамилия: ");

                        }
                        else if (selected == 4)
                        {
                            u[Админ.selected - 3].Name = Update(login.Name, "  Имя: ");

                        }
                        else if (selected == 5)
                        {
                            u[Админ.selected - 3].NameOfName = Update(login.NameOfName, "  Отчество: ");

                        }
                        else if (selected == 6)
                        {

                            u[Админ.selected - 3].birthday = Update(login.birthday, "  День рождения: ");

                        }
                        else if (selected == 7)
                        {
                            var e = login.pasport.ToString();
                            u[Админ.selected - 3].pasport = Convert.ToInt32(Update(e, "  Серия и номер паспорта: "));

                        }

                        else if (selected == 8)
                        {
                            var e = login.Post.ToString();
                            u[Админ.selected - 3].Post = Convert.ToInt32(Update(e, "  Должность:"));

                        }
                        else if (selected == 9)
                        {
                            var e = login.Zarplata.ToString();
                            u[Админ.selected - 3].Zarplata = Convert.ToDouble(Update(e, "  Зарплата: "));

                        }

                        else if (selected == 10)
                        {
                            u[Админ.selected - 3].account = Update(login.account, "  Аккаунт сотрудника: ");

                        }
                        else if (selected == -9)
                        {
                            Json_говно.MySeri(u, "Basa.json");
                            менеджер.Manager_menu(b, q);
                        }
                    }




                }
            }
            if (Админ.selected == -4)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($" Welcome {b}");
                Console.SetCursorPosition(60, 0);
                Админ.Text(q, 0);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("  ID: ");
                Console.WriteLine("  Фамилия: ");
                Console.WriteLine("  Имя: ");
                Console.WriteLine("  Отчество: ");
                Console.WriteLine("  День рождения: ");
                Console.WriteLine("  Серия и номер паспорта: ");
                Console.WriteLine("  Должность: ");
                Console.WriteLine("  Зарплата: ");
                Console.WriteLine("  Аккаунт сотрудника: ");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(70, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                Console.SetCursorPosition(72, 9);
                Console.WriteLine("S - сохранить");
                Console.SetCursorPosition(72, 10);
                Console.WriteLine("Esc - выйти в меню");
                while (true)
                {
                    int new_sel = Стрелки.Checker(2, 10, u, "Basa.json");
                    if (new_sel == 2)
                    {
                        try
                        {
                            var e = basa.ID.ToString();
                            basa.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                        catch
                        {
                            Console.SetCursorPosition(72, 11);
                            Console.WriteLine("Недопустимое значение, попробуйте снова");
                            var e = basa.ID.ToString();
                            Console.SetCursorPosition(8, 2);
                            basa.ID = Convert.ToInt32(Update(e, "  ID: "));
                        }
                    }
                    else if (new_sel == 3)
                    {
                        basa.Surname = Update(basa.Surname, "  Фамилия: ");

                    }
                    else if (new_sel == 4)
                    {
                        basa.Name = Update(basa.Name, "  Имя: ");

                    }
                    else if (new_sel == 5)
                    {

                        basa.NameOfName = Update(basa.NameOfName, "  Отчество: ");

                    }
                    else if (new_sel == 6)
                    {
                        var e = basa.birthday;
                        basa.birthday = Update(e, "  День рождения: ");
                    }
                    else if (new_sel == 7)
                    {
                        var e = basa.pasport.ToString();
                        basa.pasport = Convert.ToInt64(Update(e, "  Серия и номер паспорта: "));

                    }
                    else if (new_sel == 8)
                    {
                        var e = basa.Post.ToString();
                        basa.Post = Convert.ToInt32(Update(e, "  Должность: "));

                    }
                    else if (new_sel == 9)
                    {
                        var e = basa.Zarplata.ToString();
                        basa.Zarplata = Convert.ToDouble(Update(e, "  Зарплата: "));

                    }
                    else if (new_sel == 10)
                    {

                        basa.account = Update(basa.account, "  Аккаунт сотрудника: ");

                    }
                    else if (new_sel == -9)
                    {
                        u.Add(basa);
                        Json_говно.MySeri(u, "Basa.json");
                        менеджер.Manager_menu(b, q);

                    }
                }

            }
            else if (Админ.selected == -5)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 0);
                Console.WriteLine($"Welcome {b}!");
                Console.SetCursorPosition(60, 0);
                Админ.Text(q, 0);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("Выберите, по какому пункту вы хотите произвести поиск:");
                Console.WriteLine("  ID");
                Console.WriteLine("  Фамилия");
                Console.WriteLine("  Имя");
                Console.WriteLine("  Отчество");
                Console.WriteLine("  День рождения");
                Console.WriteLine("  Серия и номер паспорта");
                Console.WriteLine("  Должность");
                Console.WriteLine("  Зарплата");
                Console.WriteLine("  Аккаунт сотрудника");
                int treck = 2;
                while (treck <= 15)
                {
                    Console.SetCursorPosition(60, treck);
                    Console.WriteLine("|");
                    treck++;
                }
                int sel = Стрелки.Checker(3, 9, u, "Basa.json");
                if (sel == 3)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int id = Convert.ToInt32(Console.ReadLine());
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].ID == id)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);

                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                            r++;
                        }
                    }
                }
                else if (sel == 4)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string surname = Console.ReadLine();
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Surname == surname)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }
                    }
                }


                else if (sel == 5)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string name = Console.ReadLine();
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Name == name)
                        {

                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                            int ser = Стрелки.Checker(3, 100, u, "Logins.json");

                        }
                    }
                }
                else if (sel == 6)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string po = Console.ReadLine();
                    int r = 3;
                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].NameOfName == po)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }

                    }

                }
                else if (sel == 7)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string birth = Console.ReadLine();
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].birthday == birth)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }
                    }
                }
                else if (sel == 8)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int pap = Convert.ToInt32(Console.ReadLine());
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].pasport == pap)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }
                    }
                }
                else if (sel == 9)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    int dolzh = Convert.ToInt32(Console.ReadLine());
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Post == dolzh)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }
                    }
                }
                else if (sel == 10)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    double zp = Convert.ToDouble(Console.ReadLine());
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].Zarplata == zp)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }
                    }
                }
                else if (sel == 11)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Введите значение для поиска");
                    Console.SetCursorPosition(2, 16);
                    string acc = Console.ReadLine();
                    int r = 3;

                    for (int ii = 0; ii < u.Count; ii++)
                    {

                        if (u[ii].account == acc)
                        {
                            Printed();
                            Console.SetCursorPosition(12, r);
                            Console.WriteLine(u[ii].ID);
                            Console.SetCursorPosition(25, r);
                            Console.WriteLine(u[ii].Surname);
                            Console.SetCursorPosition(45, r);
                            Console.WriteLine(u[ii].Name);
                            Console.SetCursorPosition(65, r);
                            Console.WriteLine(u[ii].NameOfName);
                            Console.SetCursorPosition(85, r);
                            Админ.Text(u[ii].Post, 0);
                            r++;
                            int se = Стрелки.Checker(3, r, u, "Basa.json");
                            if (se == -10)
                            {
                                менеджер.Manager_menu(b, q);
                            }
                        }
                    }
                }
                if (sel == -10)
                {
                    менеджер.Manager_menu(b, q);
                }

            }
            if (Админ.selected == -10)
            {
                Program.Main();
            }
            if (Админ.selected == -11)
            {
                менеджер.Manager_menu(b, q);
            }
        }
        private static void Printed()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($" Welcome {o}");
            Console.SetCursorPosition(60, 0);
            Админ.Text(aa, 0);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("Фамилия");
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Имя");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Отчество");
            Console.SetCursorPosition(85, 2);
            Console.WriteLine("Должность");
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

        }
    }
}