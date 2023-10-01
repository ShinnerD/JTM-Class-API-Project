using System.Net;
using System.Net.Sockets;

namespace ThreadedChatServer
{
  public class ChatServer
  {
    public static Dictionary<Guid, ClientHandler> ClientHandlers = new();

    public static IPAddress ServerIP = IPAddress.Parse("127.0.0.1");

    public static void Main()
    {
      try
      {
        var tcpListener = new TcpListener(ServerIP, 8001);
        tcpListener.Start();

        Console.WriteLine("The server is running at port 8001...");
        Console.WriteLine("The local End point is  :" + tcpListener.LocalEndpoint);

        while (true)
        {
          Console.WriteLine("Waiting for a connection.....");

          var socket = tcpListener.AcceptSocket();
          var connectedIPAddress = socket.RemoteEndPoint as IPEndPoint;
          var clientHandler = new ClientHandler(socket, Guid.NewGuid());

          lock (ClientHandlers)
          {
            ClientHandlers.Add(clientHandler.Id, clientHandler);
          }

          Thread clientHandlerThread = new(clientHandler.HandleClient);
          clientHandlerThread.Start();

          Console.WriteLine(connectedIPAddress is not null
            ? "Connection established for connection from: " + connectedIPAddress.Address
            : "Connection established from: UNKNOWN");
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("Error..... " + e.Message);
        Console.WriteLine("StackTrace: " + e.StackTrace);
      }
    }

    public static bool HasUser(string username, out ClientHandler? userClientHandler)
    {
      userClientHandler = ClientHandlers.Values.FirstOrDefault(i => i.UserHandle == username);

      if (userClientHandler is null)
        return false;

      return true;
    }

    public static void RemoveClientHandler(ClientHandler clientHandler)
    {
      lock (ClientHandlers)
      {
        ClientHandlers.Remove(clientHandler.Id);
      }
    }

    public static void SystemWriteToAllClients(string message)
    {
      foreach (var clientHandler in ClientHandlers.Values)
      {
        clientHandler.SystemWriter.Write("SERVER: " + message + "\n");
      }
    }

    public static void ChatWriteToAllClients(ClientHandler client, string message)
    {
      foreach (var clientHandler in ClientHandlers.Values.Where(i => !client.Equals(i)))
      {
        clientHandler.ChatWriter.Write(client.UserHandle + ": " + message + "\n");
      }
    }

    public static void ChatWriteToClient(ClientHandler sendingClient, string receivingUserName, string message)
    {
      if (HasUser(receivingUserName, out var receivingClientHandler))
      {
        receivingClientHandler?.ChatWriter.Write("PRIVATE from " + sendingClient.UserHandle + ": " + message + "\n");
        return;
      }

      sendingClient.SystemWriter.Write("SERVER: No user with that username. \n");
    }
  }
}