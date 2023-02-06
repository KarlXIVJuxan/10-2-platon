using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace магазин_3
{
    internal class Json_говно
    {
        public static void MySeri<T>(T date, string filename)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(date);
            File.WriteAllText(desktop + "C:\\Users\\chelo\\Desktop\\Logins.json", json);
        }
        public static T Mydeserial<T>(string filename)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = "C:\\Users\\chelo\\Desktop\\Logins.json";
            if (File.Exists(json))
            {
                json = File.ReadAllText("C:\\Users\\chelo\\Desktop\\Logins.json");
            }
            else
            {
                File.Create(json).Close();
            }
            T date = JsonConvert.DeserializeObject<T>(json);
            return date;
        }
    }
}