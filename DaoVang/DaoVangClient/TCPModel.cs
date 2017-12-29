using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DaoVangClient
{
    class TCPModel
    {
        private TcpClient tcpclnt;
        private Stream stm;
        private byte[] byteSend;
        private byte[] byteReceive;
        private string ServerIP;
        private int ServerPort;

        public TCPModel(string ip, int p)
        {
            ServerIP = ip;
            ServerPort = p;
            tcpclnt = new TcpClient();
            byteReceive = new byte[5000];
        }

        public string ClientInformation()
        {
            string str = "";
            try
            {
                Socket s = tcpclnt.Client;
                str = str + s.LocalEndPoint;
                Console.WriteLine(str);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            return str;
        }

        public int ConnectToServer()
        {
            try
            {
                tcpclnt.Connect(ServerIP, ServerPort);
                stm = tcpclnt.GetStream();
                Console.WriteLine("Connect to server OK!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return -1;
            }
            return 1;
        }

        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }

        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        public int SendData(string str)
        {
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byteSend = asen.GetBytes(str);
                stm.Write(byteSend, 0, byteSend.Length);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return -1;
            }
        }

        public string ReadStringData()
        {
            string str = "";
            try
            {
                int k = stm.Read(byteReceive, 0, 5000);
                Console.WriteLine("Length of data received: " + k.ToString());
                Console.WriteLine("From server: ");
                char[] c = new char[k];
                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(byteReceive[i]));
                    c[i] = Convert.ToChar(byteReceive[i]);
                }
                str = new string(c);
            }
            catch (Exception e)
            {
                str = "Error..... " + e.StackTrace;
                Console.WriteLine(str);
            }
            return str;
        }

        public int SendData(Object obj)
        {
            try
            {
                byteSend = SerializeData(obj);
                stm.Write(byteSend, 0, byteSend.Length);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                return -1;
            }
        }

        public Object ReadObjectData()
        {
            Object obj = null;
            try
            {
                int k = stm.Read(byteReceive, 0, 5000);
                Console.WriteLine("Length of data received: " + k.ToString());
                Console.WriteLine("From server: ");
                obj = DeserializeData(byteReceive);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            return obj;
        }

        public void CloseConnection()
        {
            tcpclnt.Close();
        }
    }
}
