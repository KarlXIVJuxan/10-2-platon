using магазин_3;

namespace магазин_3
{
    internal class Program : контроллер
    {
        public static string y;
        static string yu;
        public static void Main()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 0);
            Console.WriteLine("Приветствую в магазине");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("Логин: ");
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("Пароль: ");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Вход");
            List<логин_пароль> u = Json_говно.Mydeserial<List<логин_пароль>>("Logins.json") ?? new List<логин_пароль>();
            логин_пароль omy = new логин_пароль();
            List<Basa> rtx = Json_говно.Mydeserial<List<Basa>>("Basa.json");
            while (true)
            {
                int selected = Стрелки.Checker(2, 3, u, "");

                if (selected == 2)
                {

                    y = Update(omy.Username, "Логин:  ");

                }
                else if (selected == 3)
                {
                    yu = Update(omy.Password, "Пароль:  ");
                }
                else if (selected == 4)
                {
                    var user = u.Find(e => e.Username == y && e.Password == yu);
                    if (user != null)
                    {
                        bool a = true;
                        if (user.Post == 0)
                        {
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].ID == user.ID)
                                {
                                    Админ.AdminLobby(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }
                            if (a) Админ.AdminLobby(y, user.Post);
                        }
                        else if (user.Post == 1)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].ID == user.ID)
                                {
                                    Кассир.Cashier_Menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }
                            if (a) Кассир.Cashier_Menu(y, 2);
                        }
                        else if (user.Post == 2)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].ID == user.ID)
                                {
                                    менеджер.Manager_menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }
                            if (a) менеджер.Manager_menu(y, 2);
                        }
                        else if (user.Post == 3)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].ID == user.ID)
                                {
                                    складовщик.Sklad_menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }
                            if (a) складовщик.Sklad_menu(y, user.Post);
                        }
                        else if (user.Post == 4)
                        {
                            a = true;
                            for (int i = 0; i < rtx.Count; i++)
                            {
                                if (rtx[i].ID == user.ID)
                                {
                                    Бухгалтер.Buhoe_menu(rtx[i].Name, rtx[i].Post);
                                    a = false;
                                }
                            }
                            if (a) Бухгалтер.Buhoe_menu(y, user.Post);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("Неправильный логин или пароль, попробуйте снова");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Main();
                    }
                }
            }
        }
    }
}