using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientApp
{
    class Program
    {
        const string STOP_KEYWORD = "stop";
        static void Main(string[] args)
        {
            Console.Title = "Client";
            Console.ReadLine();
            //הגדרת כתובת סופית לחיבור
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 851);
            TcpClient client = new TcpClient();
            //חיבור אל השרת
            client.Connect(endPoint);

            //קבלת צינור התקשרות לשרת
            NetworkStream ns = client.GetStream();           
            ShareDLL.Product p = new ShareDLL.Product() { ID = 1, Name = "Bamba", Price = 18.6 };
            BinaryFormatter formater = new BinaryFormatter();
            formater.Serialize(ns, p);
            Console.WriteLine("product sent");
            Console.ReadLine();
           

            //שחרור משאבים
           
            client.Close();

        }
    }
}
