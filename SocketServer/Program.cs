using System.Net;
using System.Net.Sockets;
using TelnetShell;

namespace SocketServer
{
  public class Program
  {
    public static Dictionary<string, ClientHandler> ClientHandlers = new();

    public static void Main()
    {
      try
      {
        IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //localhost IP address,
        TcpListener myList = new TcpListener(ipAd, 8001); //and use the same at
        myList.Start();                                //the client side
        Console.WriteLine("The server is running at port 8001...");
        Console.WriteLine("The local End point is  :" + myList.LocalEndpoint);
        while (true)
        {
          Console.WriteLine("Waiting for a connection.....");
          Socket s = myList.AcceptSocket();
          ClientHandler ch = new ClientHandler(s);
          lock (ClientHandlers)
          {
            NetworkStream socketStream = new NetworkStream(s);
            BinaryReader reader = new BinaryReader(socketStream);
            BinaryWriter writer = new BinaryWriter(socketStream);
            writer.Write("Please enter an alias: ");
            string txt = reader.ReadString(); // get nickname
            string nick = txt.Substring(0,4);
            ClientHandlers[nick] = ch;
          }
          Thread t = new Thread(new ThreadStart(ch.HandleClient));
          t.Start();
        }
        //   myList.Stop();
      }
      catch (Exception e)
      {
        Console.WriteLine("Error..... " + e.StackTrace);
      }
    }
  }
}