using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DaoVangServer
{
    class SocketModel
    {
        private Socket socket;
        private byte[] array_to_receive_data;
        private string remoteEndPoint;

        public SocketModel(Socket s)
        {
            socket = s;
            array_to_receive_data = new byte[5000];
        }
        public SocketModel(Socket s, int length)
        {
            socket = s;
            array_to_receive_data = new byte[length];
        }
        //get the IP and port of connected client
        public string GetRemoteEndpoint()
        {
            string str = "";
            try
            {
                str = Convert.ToString(socket.RemoteEndPoint);
                remoteEndPoint = str;
            }
            catch (Exception e)
            {
                string str1 = "Error..... " + e.StackTrace;
                Console.WriteLine(str1);
                str = "Socket is closed with " + remoteEndPoint;
            }
            return str;
        }


        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }


        public Object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        //receive data from client
        public string ReceiveStringData()
        {
            //server just can receive data AFTER a connection is set up between server and client
            string str = "";
            try
            {
                //count the length of data received (maximum is 100 bytes)
                int k = socket.Receive(array_to_receive_data);
                Console.WriteLine("From client:");
                //convert the byte recevied into string
                char[] c = new char[k];
                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(array_to_receive_data[i]));
                    c[i] = Convert.ToChar(array_to_receive_data[i]);
                }
                str = new string(c);
            }
            catch (Exception e)
            {
                string str1 = "Error..... " + e.StackTrace;
                Console.WriteLine(str1);
                str = "Socket is closed with " + remoteEndPoint;
            }
            return str;
        }

        public Object ReceiveObjectData()
        {
            //server just can receive data AFTER a connection is set up between server and client
            Object obj = null;
            try
            {
                //count the length of data received (maximum is 100 bytes)
                int k = socket.Receive(array_to_receive_data);
                Console.WriteLine("From client:");
                //convert the byte recevied into string
                obj = DeserializeData(array_to_receive_data);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            return obj;
        }

        //send data to client
        public void SendData(string str)
        {
            try
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                socket.Send(asen.GetBytes(str));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

        public void SendData(Object obj)
        {
            try
            {
                byte[] send = SerializeData(obj);
                socket.Send(send);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
        //close sockket
        public void CloseSocket()
        {
            socket.Close();
        }
    }
}
