using SocketServer;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace TelnetShell
{
  public class ClientHandler
  {
    private Socket s;
    private NetworkStream socketStream;
    public BinaryWriter writer;
    private BinaryReader reader;

    public ClientHandler(Socket s)
    {
      this.s = s;
      socketStream = new NetworkStream(s);
      writer = new BinaryWriter(socketStream);
      reader = new BinaryReader(socketStream);
    }

    public void HandleClient()
    {
      Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
      writer.Write("Connection accepted.\r\n");
      while (true)
      {
        var fullLine = reader.ReadString();

        var cmdString = fullLine.Length >= 5 ? fullLine.Substring(0, 5) : string.Empty;
        var contentLine = fullLine.Length > 5 ? fullLine.Substring(5) : string.Empty;

          switch (cmdString)
          {
            case "echo:":
              writer.Write("echo from server: " + contentLine + "\r\n");
              break;

            case "date:":
              writer.Write("Today's Date: " + DateTime.Now.ToShortDateString() + "\r\n");
              break;

            case "root:":
              foreach (var pair in Program.ClientHandlers)
              {
                writer.Write("Root says: " + contentLine + "\r\n");
              }
              break;

            default:
              writer.Write("Command not recognized\r\n");
              break;
        }
      }
    }
  }
}