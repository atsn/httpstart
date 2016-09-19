using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpstart
{
    class Echo
    {
        private TcpClient connectionseet;

        public Echo(TcpClient connectionseet)
        {
            this.connectionseet = connectionseet;
        }

        internal void Message()
        {
            Stream connectionStream = connectionseet.GetStream();


            StreamReader sReader = new StreamReader(connectionStream);
            StreamWriter sWriter = new StreamWriter(connectionStream);
            sWriter.AutoFlush = true;
            string message = "q";

            while (message.ToLower() != "stop")
            {

                message = sReader.ReadLine();


                if (message.StartsWith("GET") && message.EndsWith("HTTP/1.1") && message != "GETHTTP/1.1" &&
                    message != "GET HTTP/1.1")
                {
                    try
                    {
                        string[] messeges = new string[3];

                        messeges = message.Split(' ');

                        message = messeges[2];

                    }
                    catch (IndexOutOfRangeException)
                    {

                        sWriter.WriteLine("bad reques");
                    }
                    catch (Exception x)
                    {
                        throw x;
                    }

                }

                else
                {
                    sWriter.WriteLine(message.ToUpper() + " Nu Er Jeg Ekoo MHUHAHAH");
                }

                Console.WriteLine(message);



            }








        }

    }
}
