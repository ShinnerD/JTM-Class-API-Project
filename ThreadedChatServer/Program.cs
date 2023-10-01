using System.Net;
using System.Net.Sockets;

namespace ThreadedChatServer
{
  public class Program
  {
    public static Dictionary<string, ClientHandler> ClientHandlers = new();

    public static void Main()
    {
      try
      {
        var ipAd = IPAddress.Parse("127.0.0.1"); //localhost IP address,
        var myList = new TcpListener(ipAd, 8001); //and use the same at
        myList.Start();                                //the client side
        Console.WriteLine("The server is running at port 8001...");
        Console.WriteLine("The local End point is  :" + myList.LocalEndpoint);
        while (true)
        {
          Console.WriteLine("Waiting for a connection.....");
          var s = myList.AcceptSocket();
          var ch = new ClientHandler(s);
          lock (ClientHandlers)
          {
            var socketStream = new NetworkStream(s);
            var reader = new BinaryReader(socketStream);
            var writer = new BinaryWriter(socketStream);

            var txt = string.Empty;

            while (string.IsNullOrEmpty(txt) || txt.Length < 4)
            {
              writer.Write("Please enter an alias of at least 4 characters: ");
              txt = reader.ReadString();
            }

            var nick = txt.Substring(0, 4);

            ClientHandlers[nick] = ch;
            ch.ClientNickname = nick;
          }
          Thread t = new(ch.HandleClient);
          t.Start();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("Error..... " + e.StackTrace);
      }
    }
  }
}