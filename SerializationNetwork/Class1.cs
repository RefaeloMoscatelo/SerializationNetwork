using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerApp
{
    class Program
    {
        const string STOP_KEYWORD = "stop";
        static void Main(string[] args)
        {
            Console.Title = "Server";
            ;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 851);
            //הגדרת אובייקט שרת
            TcpListener server = new TcpListener(endPoint);
            //הפעלת השרת
            server.Start();
            Console.WriteLine("Server Up...");
            //המתנה להתחברות לקוח
            TcpClient connectedClient = server.AcceptTcpClient();
            Console.WriteLine("Client Connected..send message");
            //קבלת צינור התקשורת ללקוח
            NetworkStream ns = connectedClient.GetStream();
            BinaryWriter writer = new BinaryWriter(ns);
            BinaryFormatter formater = new BinaryFormatter();
            ShareDLL.Product ProductFromClient = formater.Deserialize(ns) as ShareDLL.Product;          
            Console.WriteLine("Product Id is: {0} ",ProductFromClient.ID);
            Console.WriteLine("Product Name is: {0} ", ProductFromClient.Name);
            Console.WriteLine("Product Price is: {0} ", ProductFromClient.Price);
            Console.ReadLine();
           
            connectedClient.Close();
            server.Stop();

        }
    }
}

