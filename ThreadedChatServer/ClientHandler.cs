using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace ThreadedChatServer
{
  public class ClientHandler
  {
    private readonly Socket _socket;
    public BinaryWriter Writer;
    private readonly BinaryReader _reader;
    public string? ClientNickname;

    public ClientHandler(Socket socket)
    {
      this._socket = socket;
      var socketStream = new NetworkStream(socket);
      Writer = new BinaryWriter(socketStream);
      _reader = new BinaryReader(socketStream);
    }

    public void HandleClient()
    {
      Console.WriteLine("Connection accepted from " + _socket.RemoteEndPoint);
      Writer.Write("Connection accepted.\r\n");
      while (true)
      {
        var fullLine = _reader.ReadString();

        if (string.IsNullOrWhiteSpace(fullLine)) 
          continue;

        foreach (var clientHandler in Program.ClientHandlers.Values)
        {
          clientHandler.Writer.Write(ClientNickname + ": " + fullLine);
        }
      }
    }
  }
}