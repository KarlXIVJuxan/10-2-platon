using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace магазин_3
{
    internal class логин_пароль
    {
        public int ID;
        public string Password;
        public string Username;
        public int Post;
        public List<string> all_Password = new List<string>()
        {
            "12345",
            "1234",
            "123",
            "12",
            "1"
        };
        public List<string> all_Username = new List<string>()
        {
            "админ",
            "менеджер",
            "бухгалтер",
            "складовщик",
            "кассир"
        };
    }
    internal class Basa : логин_пароль
    {
        public string Name;
        public string Surname;
        public string NameOfName;
        public long pasport;
        public string birthday;
        public double Zarplata;
        public string account;
    }
    public class Tovar
    {
        public int ID;
        public string NameOf;
        public double priceFor1;
        public int sklad;
        public int p;
        public double pokupka;
    }
    internal class Buh_uchyot
    {
        public int ID;
        public string NameOf;
        public double Zarplata;
        public DateTime time = DateTime.Now;
        public bool tf;
    }
}