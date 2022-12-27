using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace магазин_3
{
    internal class json_говно
    {
        public static void MySeri<T>(T date, string filename)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(date);
            File.WriteAllText(desktop + "\\" + filename, json);
        }
        public static T Mydeserial<T>(string filename)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + filename);
            T date = JsonConvert.DeserializeObject<T>(json);
            return date;
        }
    }
}