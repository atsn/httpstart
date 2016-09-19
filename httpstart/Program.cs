using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace httpstart
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener myServer = new TcpListener(IPAddress.Any, 6789);
                myServer.Start();

                while (true)
                {
                    TcpClient myServerTcpconnection = myServer.AcceptTcpClient();
                    Console.WriteLine("Server started");
                    Echo service = new Echo(myServerTcpconnection);
                    Thread myThread = new Thread(service.Message);
                    myThread.Start();
                    myServer.Stop();



                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }


        }
    }
}
