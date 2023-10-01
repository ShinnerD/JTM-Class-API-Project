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
      sendButton = new Button();
      outputTextBox = new RichTextBox();
      userGroupBox = new GroupBox();
      userListBox = new ListBox();
      ipTextBox = new TextBox();
      label1 = new Label();
      label2 = new Label();
      portTextBox = new TextBox();
      connectButton = new Button();
      disconnectButton = new Button();
      inputTextBox = new TextBox();
      userGroupBox.SuspendLayout();
      SuspendLayout();
      // 
      // sendButton
      // 
      sendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      sendButton.FlatAppearance.BorderColor = Color.FromArgb(250, 250, 250);
      sendButton.FlatStyle = FlatStyle.Flat;
      sendButton.ForeColor = Color.FromArgb(250, 250, 250);
      sendButton.Location = new Point(701, 417);
      sendButton.Name = "sendButton";
      sendButton.Size = new Size(87, 23);
      sendButton.TabIndex = 1;
      sendButton.Text = "Send";
      sendButton.UseVisualStyleBackColor = true;
      sendButton.Click += sendButton_Click;
      // 
      // outputTextBox
      // 
      outputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      outputTextBox.BackColor = Color.FromArgb(26, 26, 26);
      outputTextBox.BorderStyle = BorderStyle.None;
      outputTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      outputTextBox.ForeColor = Color.FromArgb(191, 214, 214);
      outputTextBox.Location = new Point(12, 35);
      outputTextBox.Name = "outputTextBox";
      outputTextBox.ReadOnly = true;
      outputTextBox.Size = new Size(598, 374);
      outputTextBox.TabIndex = 2;
      outputTextBox.TabStop = false;
      outputTextBox.Text = "";
      // 
      // userGroupBox
      // 
      userGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      userGroupBox.BackColor = Color.FromArgb(26, 26, 26);
      userGroupBox.Controls.Add(userListBox);
      userGroupBox.FlatStyle = FlatStyle.Flat;
      userGroupBox.ForeColor = Color.FromArgb(250, 250, 250);
      userGroupBox.Location = new Point(616, 6);
      userGroupBox.Name = "userGroupBox";
      userGroupBox.Size = new Size(172, 403);
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
      userListBox.SelectionMode = SelectionMode.None;
      userListBox.Size = new Size(166, 381);
      userListBox.TabIndex = 0;
      userListBox.TabStop = false;
      // 
      // ipTextBox
      // 
      ipTextBox.BackColor = Color.FromArgb(31, 31, 31);
      ipTextBox.BorderStyle = BorderStyle.FixedSingle;
      ipTextBox.ForeColor = Color.FromArgb(191, 214, 214);
      ipTextBox.Location = new Point(35, 6);
      ipTextBox.Name = "ipTextBox";
      ipTextBox.Size = new Size(187, 23);
      ipTextBox.TabIndex = 4;
      ipTextBox.Text = "127.0.0.1";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.ForeColor = Color.FromArgb(250, 250, 250);
      label1.Location = new Point(12, 9);
      label1.Name = "label1";
      label1.Size = new Size(17, 15);
      label1.TabIndex = 5;
      label1.Text = "IP";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.ForeColor = Color.FromArgb(250, 250, 250);
      label2.Location = new Point(228, 9);
      label2.Name = "label2";
      label2.Size = new Size(35, 15);
      label2.TabIndex = 6;
      label2.Text = "PORT";
      // 
      // portTextBox
      // 
      portTextBox.BackColor = Color.FromArgb(31, 31, 31);
      portTextBox.BorderStyle = BorderStyle.FixedSingle;
      portTextBox.ForeColor = Color.FromArgb(191, 214, 214);
      portTextBox.Location = new Point(269, 6);
      portTextBox.Name = "portTextBox";
      portTextBox.Size = new Size(82, 23);
      portTextBox.TabIndex = 7;
      portTextBox.Text = "8001";
      // 
      // connectButton
      // 
      connectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      connectButton.FlatAppearance.BorderColor = Color.FromArgb(250, 250, 250);
      connectButton.FlatStyle = FlatStyle.Flat;
      connectButton.ForeColor = Color.FromArgb(250, 250, 250);
      connectButton.Location = new Point(397, 6);
      connectButton.Name = "connectButton";
      connectButton.Size = new Size(87, 23);
      connectButton.TabIndex = 8;
      connectButton.Text = "Connect";
      connectButton.UseVisualStyleBackColor = true;
      connectButton.Click += connectButton_Click;
      // 
      // disconnectButton
      // 
      disconnectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      disconnectButton.FlatAppearance.BorderColor = Color.FromArgb(250, 250, 250);
      disconnectButton.FlatStyle = FlatStyle.Flat;
      disconnectButton.ForeColor = Color.FromArgb(250, 250, 250);
      disconnectButton.Location = new Point(503, 6);
      disconnectButton.Name = "disconnectButton";
      disconnectButton.Size = new Size(87, 23);
      disconnectButton.TabIndex = 9;
      disconnectButton.Text = "Disconnect";
      disconnectButton.UseVisualStyleBackColor = true;
      disconnectButton.Click += disconnectButton_Click;
      // 
      // inputTextBox
      // 
      inputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      inputTextBox.BackColor = Color.FromArgb(31, 31, 31);
      inputTextBox.BorderStyle = BorderStyle.FixedSingle;
      inputTextBox.ForeColor = Color.FromArgb(191, 214, 214);
      inputTextBox.Location = new Point(12, 417);
      inputTextBox.Name = "inputTextBox";
      inputTextBox.Size = new Size(683, 23);
      inputTextBox.TabIndex = 10;
      inputTextBox.KeyDown += inputTextBox_KeyDown;
      // 
      // ChatClient
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(31, 31, 31);
      ClientSize = new Size(800, 450);
      Controls.Add(inputTextBox);
      Controls.Add(disconnectButton);
      Controls.Add(connectButton);
      Controls.Add(portTextBox);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(ipTextBox);
      Controls.Add(userGroupBox);
      Controls.Add(outputTextBox);
      Controls.Add(sendButton);
      Name = "ChatClient";
      Text = "Chat Client";
      FormClosing += ChatClient_FormClosing;
      userGroupBox.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button sendButton;
    private RichTextBox outputTextBox;
    private GroupBox userGroupBox;
    private ListBox userListBox;
    private TextBox ipTextBox;
    private Label label1;
    private Label label2;
    private TextBox portTextBox;
    private Button connectButton;
    private Button disconnectButton;
    private TextBox inputTextBox;
  }
}