using System.Net;
using System.Net.Sockets;

namespace ThreadedChatClient
{
  public partial class ChatClient : Form
  {
    private string chatWindowContent;
    private TcpClient windowTcpClient;
    private BinaryReader Reader;
    private BinaryWriter Writer;

    public ChatClient()
    {
      InitializeComponent();
      chatWindowContent = string.Empty;
      outputTextBox.Text = chatWindowContent;
    }

    private void connectButton_Click(object sender, EventArgs e)
    {
      if (windowTcpClient is not null && windowTcpClient.Connected)
      {
        return;
      }

      if (IPAddress.TryParse(ipTextBox.Text, out var ipAddress) && int.TryParse(portTextBox.Text, out var port))
      {
        windowTcpClient = new();
        try
        {
          chatWindowContent += "Connecting to " + ipAddress + " please wait..\n";
          windowTcpClient.Connect(ipAddress, port);
        }
        catch (Exception)
        {
          chatWindowContent += "Could not connect to server. \n";
          return;
        }

        var stream = windowTcpClient.GetStream();
        Reader = new BinaryReader(stream);
        Writer = new BinaryWriter(stream);
        var readThread = new Thread(ReadMessages);
        readThread.Start();
        chatWindowContent += "Connected To Server. \n";
        return;
      }

      chatWindowContent += "IP or Port is not valid. \n";
    }

    public Action WriteToChatWindow(string message)
    {
      return () =>
      {
        chatWindowContent += message;
        outputTextBox.Text = chatWindowContent;
      };
    }

    public Action FillUserList(string[] userNames)
    {
      return () =>
      {
        userListBox.Items.Clear();
        userListBox.Items.AddRange(userNames);
      };
    }

    private void ReadMessages()
    {
      try
      {
        while (windowTcpClient.Connected)
        {
          string message = Reader.ReadString();

          if (message.StartsWith("USERS: "))
          {
            var userNames = message.Substring(7).Split(", ").OrderBy(i => i).ToArray();
            this.Invoke(FillUserList(userNames));
          }

          this.Invoke(WriteToChatWindow(message));
        }
      }
      catch (Exception)
      {
        Console.WriteLine("Disconnected from the server.");
      }
    }

    private void sendButton_Click(object sender, EventArgs e)
    {
      var input = inputTextBox.Text;

      if (!string.IsNullOrWhiteSpace(input) && windowTcpClient.Connected)
      {
        Writer.Write(input);
        inputTextBox.Text = string.Empty;
      }
    }

    private void disconnectButton_Click(object sender, EventArgs e)
    {
      if (windowTcpClient is not null && windowTcpClient.Connected)
      {
        windowTcpClient.Close();
        this.Invoke(WriteToChatWindow("Disconnected from server."));
      }
    }

    private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (windowTcpClient is not null && windowTcpClient.Connected)
      {
        windowTcpClient.Close();
      }
    }

    private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        sendButton_Click(sender, e);
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
    }
  }
}