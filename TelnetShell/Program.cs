using System.Net.Sockets;

namespace TelnetShell
{
  class Program
  {
    private static TcpClient tcpClient;
    private static NetworkStream stream;
    private static BinaryReader reader;
    private static BinaryWriter writer;

    public static void Main()
    {
      tcpClient = new TcpClient();
      var ipAdresse = "127.0.0.1";
      var port = 8001;

      Console.WriteLine("Connecting to " + ipAdresse + " " + port);

      try
      {
        tcpClient.Connect(ipAdresse, port);
        stream = tcpClient.GetStream();
        reader = new BinaryReader(stream);
        writer = new BinaryWriter(stream);

        // Start a separate thread for reading messages from the server
        Thread readThread = new Thread(ReadMessages);
        readThread.Start();

        string input;
        do
        {
          input = Console.ReadLine();

          if (!string.IsNullOrWhiteSpace(input))
          {
            writer.Write(input);
          }
        } while (input != "q");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }
      finally
      {
        // Close the client and resources when done
        tcpClient.Close();
        reader.Close();
        writer.Close();
      }
    }

    private static void ReadMessages()
    {
      try
      {
        while (true)
        {
          string message = reader.ReadString();
          Console.WriteLine(message);
        }
      }
      catch (Exception)
      {
        // Handle any exceptions or disconnects here
        Console.WriteLine("Disconnected from the server.");
      }
    }
  }
}