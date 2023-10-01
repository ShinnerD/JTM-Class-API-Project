namespace ThreadedChatClient
{
  partial class ChatClient
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      inputChatBox = new TextBox();
      sendButton = new Button();
      outputTextBox = new RichTextBox();
      userGroupBox = new GroupBox();
      userListBox = new ListBox();
      userGroupBox.SuspendLayout();
      SuspendLayout();
      // 
      // inputChatBox
      // 
      inputChatBox.Location = new Point(12, 415);
      inputChatBox.Name = "inputChatBox";
      inputChatBox.Size = new Size(683, 23);
      inputChatBox.TabIndex = 0;
      // 
      // sendButton
      // 
      sendButton.Location = new Point(701, 415);
      sendButton.Name = "sendButton";
      sendButton.Size = new Size(87, 23);
      sendButton.TabIndex = 1;
      sendButton.Text = "Send";
      sendButton.UseVisualStyleBackColor = true;
      // 
      // outputTextBox
      // 
      outputTextBox.BackColor = Color.FromArgb(26, 26, 26);
      outputTextBox.BorderStyle = BorderStyle.None;
      outputTextBox.Location = new Point(12, 12);
      outputTextBox.Name = "outputTextBox";
      outputTextBox.Size = new Size(598, 397);
      outputTextBox.TabIndex = 2;
      outputTextBox.Text = "";
      // 
      // userGroupBox
      // 
      userGroupBox.BackColor = Color.FromArgb(26, 26, 26);
      userGroupBox.Controls.Add(userListBox);
      userGroupBox.FlatStyle = FlatStyle.Flat;
      userGroupBox.ForeColor = Color.FromArgb(250, 250, 250);
      userGroupBox.Location = new Point(616, 12);
      userGroupBox.Name = "userGroupBox";
      userGroupBox.Size = new Size(172, 397);
      userGroupBox.TabIndex = 3;
      userGroupBox.TabStop = false;
      userGroupBox.Text = "Users";
      // 
      // userListBox
      // 
      userListBox.BackColor = Color.FromArgb(26, 26, 26);
      userListBox.BorderStyle = BorderStyle.None;
      userListBox.Dock = DockStyle.Fill;
      userListBox.ForeColor = Color.FromArgb(191, 214, 214);
      userListBox.FormattingEnabled = true;
      userListBox.ItemHeight = 15;
      userListBox.Location = new Point(3, 19);
      userListBox.Name = "userListBox";
      userListBox.Size = new Size(166, 375);
      userListBox.TabIndex = 0;
      // 
      // ChatClient
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(31, 31, 31);
      ClientSize = new Size(800, 450);
      Controls.Add(userGroupBox);
      Controls.Add(outputTextBox);
      Controls.Add(sendButton);
      Controls.Add(inputChatBox);
      Name = "ChatClient";
      Text = "Chat Client";
      userGroupBox.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox inputChatBox;
    private Button sendButton;
    private RichTextBox outputTextBox;
    private GroupBox userGroupBox;
    private ListBox userListBox;
  }
}