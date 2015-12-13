namespace ClientChat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.btn_stopconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.onlineUser = new System.Windows.Forms.ListView();
            this.column_username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SingleRadio = new System.Windows.Forms.RadioButton();
            this.GroupRadio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_shutdown = new System.Windows.Forms.Button();
            this.sendMessageBox = new System.Windows.Forms.RichTextBox();
            this.allmessageBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_show = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.btn_stopconnect);
            this.groupBox1.Controls.Add(this.btn_connect);
            this.groupBox1.Controls.Add(this.textBox_port);
            this.groupBox1.Controls.Add(this.textBox_ip);
            this.groupBox1.Controls.Add(this.textBox_username);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(50, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户登录";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(98, 53);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(100, 21);
            this.textBox_password.TabIndex = 9;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(36, 56);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(29, 12);
            this.password.TabIndex = 8;
            this.password.Text = "密码";
            // 
            // btn_stopconnect
            // 
            this.btn_stopconnect.Location = new System.Drawing.Point(137, 140);
            this.btn_stopconnect.Name = "btn_stopconnect";
            this.btn_stopconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_stopconnect.TabIndex = 7;
            this.btn_stopconnect.Text = "关闭连接";
            this.btn_stopconnect.UseVisualStyleBackColor = true;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(21, 140);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 6;
            this.btn_connect.Text = "请求连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(98, 108);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(100, 21);
            this.textBox_port.TabIndex = 5;
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(98, 79);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(100, 21);
            this.textBox_ip.TabIndex = 4;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(98, 26);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(100, 21);
            this.textBox_username.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "端口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.onlineUser);
            this.groupBox2.Location = new System.Drawing.Point(50, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 153);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "在线用户";
            // 
            // onlineUser
            // 
            this.onlineUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_username,
            this.column_IP,
            this.column_port});
            this.onlineUser.FullRowSelect = true;
            this.onlineUser.GridLines = true;
            this.onlineUser.Location = new System.Drawing.Point(21, 20);
            this.onlineUser.Name = "onlineUser";
            this.onlineUser.Size = new System.Drawing.Size(191, 118);
            this.onlineUser.TabIndex = 6;
            this.onlineUser.UseCompatibleStateImageBehavior = false;
            this.onlineUser.View = System.Windows.Forms.View.Details;
            // 
            // column_username
            // 
            this.column_username.Text = "用户名";
            // 
            // column_IP
            // 
            this.column_IP.Text = "IP";
            this.column_IP.Width = 49;
            // 
            // column_port
            // 
            this.column_port.Text = "端口号";
            this.column_port.Width = 73;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SingleRadio);
            this.groupBox3.Controls.Add(this.GroupRadio);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btn_send);
            this.groupBox3.Controls.Add(this.btn_shutdown);
            this.groupBox3.Controls.Add(this.sendMessageBox);
            this.groupBox3.Controls.Add(this.allmessageBox);
            this.groupBox3.Location = new System.Drawing.Point(292, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 381);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "收发信息";
            // 
            // SingleRadio
            // 
            this.SingleRadio.AutoSize = true;
            this.SingleRadio.Location = new System.Drawing.Point(91, 196);
            this.SingleRadio.Name = "SingleRadio";
            this.SingleRadio.Size = new System.Drawing.Size(47, 16);
            this.SingleRadio.TabIndex = 7;
            this.SingleRadio.Text = "私聊";
            this.SingleRadio.UseVisualStyleBackColor = true;
            this.SingleRadio.CheckedChanged += new System.EventHandler(this.SingleRadio_CheckedChanged);
            // 
            // GroupRadio
            // 
            this.GroupRadio.AutoSize = true;
            this.GroupRadio.Checked = true;
            this.GroupRadio.Location = new System.Drawing.Point(161, 196);
            this.GroupRadio.Name = "GroupRadio";
            this.GroupRadio.Size = new System.Drawing.Size(47, 16);
            this.GroupRadio.TabIndex = 6;
            this.GroupRadio.TabStop = true;
            this.GroupRadio.Text = "群聊";
            this.GroupRadio.UseVisualStyleBackColor = true;
            this.GroupRadio.CheckedChanged += new System.EventHandler(this.GroupRadio_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "发送消息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "已接收消息";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(142, 352);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_shutdown
            // 
            this.btn_shutdown.Location = new System.Drawing.Point(21, 352);
            this.btn_shutdown.Name = "btn_shutdown";
            this.btn_shutdown.Size = new System.Drawing.Size(76, 23);
            this.btn_shutdown.TabIndex = 2;
            this.btn_shutdown.Text = "关闭";
            this.btn_shutdown.UseVisualStyleBackColor = true;
            // 
            // sendMessageBox
            // 
            this.sendMessageBox.Location = new System.Drawing.Point(16, 228);
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Size = new System.Drawing.Size(201, 98);
            this.sendMessageBox.TabIndex = 1;
            this.sendMessageBox.Text = "";
            this.sendMessageBox.TextChanged += new System.EventHandler(this.sendMessageBox_TextChanged);
            // 
            // allmessageBox
            // 
            this.allmessageBox.Location = new System.Drawing.Point(16, 47);
            this.allmessageBox.Name = "allmessageBox";
            this.allmessageBox.Size = new System.Drawing.Size(201, 138);
            this.allmessageBox.TabIndex = 0;
            this.allmessageBox.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_show);
            this.groupBox4.Location = new System.Drawing.Point(50, 219);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(227, 48);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "连接状态";
            // 
            // label_show
            // 
            this.label_show.AutoSize = true;
            this.label_show.Location = new System.Drawing.Point(34, 22);
            this.label_show.Name = "label_show";
            this.label_show.Size = new System.Drawing.Size(89, 12);
            this.label_show.TabIndex = 0;
            this.label_show.Text = "未连接到服务器";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 465);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_stopconnect;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_shutdown;
        private System.Windows.Forms.RichTextBox sendMessageBox;
        private System.Windows.Forms.RichTextBox allmessageBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_show;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView onlineUser;
        private System.Windows.Forms.ColumnHeader column_username;
        private System.Windows.Forms.ColumnHeader column_IP;
        private System.Windows.Forms.ColumnHeader column_port;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.RadioButton GroupRadio;
        private System.Windows.Forms.RadioButton SingleRadio;
    }
}

