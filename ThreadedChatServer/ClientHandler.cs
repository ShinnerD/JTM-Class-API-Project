using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace ThreadedChatServer
{
  public class ClientHandler
  {
    public readonly Guid Id;
    public string? UserHandle;
    public BinaryWriter ChatWriter;
    public BinaryWriter SystemWriter;
    public Socket ActiveSocket;

    private readonly BinaryReader _reader;
    private readonly Regex allowedHandleLetters = new Regex("^[a-zA-Z0-9_]*$");
    private readonly int allowedHandleLength = 10;

    public ClientHandler(Socket socket, Guid clientHandlerId)
    {
      ActiveSocket = socket;
      var socketStream = new NetworkStream(socket);
      SystemWriter = new BinaryWriter(socketStream);
      ChatWriter = new BinaryWriter(socketStream);
      _reader = new BinaryReader(socketStream);
      Id = clientHandlerId;
    }

    public void HandleClient()
    {
      SystemWriter.Write("Connection accepted.\n");
      while (ActiveSocket.Connected)
      {
        while (string.IsNullOrEmpty(UserHandle))
        {
          SystemWriter.Write("Please enter desired user handle. \n");
          SystemWriter.Write("Handle can only contain letters, numbers and _ \n");
          SystemWriter.Write("Handle must be no longer than +" + allowedHandleLength + " characters. \n");
          var userNameInput = _reader.ReadString();

          if (!string.IsNullOrEmpty(userNameInput)
          && allowedHandleLetters.IsMatch(userNameInput)
          && userNameInput.Length <= allowedHandleLength)
          {
            UserHandle = userNameInput;
            SystemWriter.Write("Handle Accepted. You can now chat with others. \n");
            SystemWriter.Write("Type @Username to send a private message. \n");
            SystemWriter.Write("Type /users to list all users. \n");
          }
        }

        var userInput = _reader.ReadString();

        if (string.IsNullOrWhiteSpace(userInput))
          continue;

        if (userInput.StartsWith('@'))
        {
          var username = userInput.Split(' ')[0].Substring(1);
          var message = userInput.Split(' ')[1];
          ChatServer.ChatWriteToClient(this, username, message);
          continue;
        }

        if (userInput.TrimEnd() == "/users")
        {
          SystemWriter.Write("USERS: " + string.Join(", ", ChatServer.ClientHandlers.Values.Select(i => i.UserHandle).OrderBy(i => i).ToArray()));
          continue;
        }

        ChatServer.ChatWriteToAllClients(this, userInput);
      }

      ChatServer.RemoveClientHandler(this);
    }
  }
}