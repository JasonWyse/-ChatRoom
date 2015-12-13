using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace ClientChat
{
    public partial class Form1 : Form
    {
        private int serverport;
        private TcpClient clientsocket;
        private NetworkStream ns;
        private StreamReader sr;
        private Thread recThread = null;
        private Thread recUdpThread = null;
        private string serveraddress;
        private string clientname;
        private bool connected = false;

        private int local_udp_port;
        private string local_udp_addr;
        private UdpClient udpcRecv;
        private UdpClient udpcSend;
        private Thread thrUdpRecv;
        private bool udpListenOn = false;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            btn_stopconnect.Enabled = false;
            btn_stopconnect.Enabled = false;
     //       btn_send.Enabled = false;
     //       radioBtn_public.Checked = true;
            textBox_username.Text = "user1";
            textBox_port.Text = "8888";
            textBox_ip.Text = "127.0.0.1";
            textBox_password.Text = "password";
            Random ro = new Random();
            local_udp_port = 10000+ro.Next(10000);
            local_udp_addr = "127.0.0.1";
        }


        protected override void OnClosed(EventArgs e)
        {
            QuitChat();
            if (recThread != null && recThread.IsAlive)
                recThread.Abort();
            base.OnClosed(e);
        }

        private void SendToServerMsg(TcpClient cl, string message)
        {
            try
            {
                NetworkStream stream = cl.GetStream();
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
                // Send back a response.
                stream.Write(msg, 0, msg.Length);

            }
            catch (Exception)
            {
                cl.Close();                           
               
            }
        }
               
        //private void ReceiveChat()
        //{
        //    bool alive = true;
        //    while (alive)
        //    {
        //        try
        //        {
        //            Byte[] buffer = new Byte[2048000];
        //            ns.Read(buffer, 0, buffer.Length);
        //            string time = System.DateTime.Now.ToLongTimeString();
        //            string chatter = System.Text.Encoding.Default.GetString(buffer);

        //            string[] tokens = chatter.Split(new Char[] { '|' });

        //            if (tokens[0] == "CHAT")
        //            {
        //                allmessage.AppendText(tokens[1].Trim());
        //                allmessage.AppendText("  " + time + " \r\n");
        //                allmessage.AppendText(tokens[2].Trim());



        //            }
        //            else if (tokens[0] == "PRIV")
        //            {

        //                allmessage.AppendText("消息来自 ");
        //                allmessage.AppendText(tokens[1].Trim());
        //                allmessage.AppendText(" " + time + "\r\n");
        //                allmessage.AppendText(tokens[2] + "\r\n");//不同聊天模式token格式不一样 



        //            }
        //            else if (tokens[0] == "JOIN")
        //            {
        //                allmessage.AppendText(time + "  ");
        //                allmessage.AppendText(tokens[1].Trim());
        //                allmessage.AppendText("加入聊天室" + "\r\n");
        //                string newcomer = tokens[1].Trim(new char[] { '\r', '\n' });
        //                //string newcomer = tokens[1].Trim();  
        //                //MessageBox.Show(newcomer);  
        //                ListViewItem lvItem = new ListViewItem();
        //                lvItem.Text = tokens[1];
        //                lvItem.SubItems.Add(tokens[2]);
        //                lvItem.SubItems.Add(tokens[3]);
        //                onlineUser.Items.Add(lvItem);
                        
        //            }
        //            else if (tokens[0] == "LEAVE")
        //            {
        //                allmessage.AppendText(time + "  ");
        //                allmessage.AppendText(tokens[1].Trim());
        //                allmessage.AppendText("退出了聊天室" + "\r\n");


        //                string leaver = tokens[1].Trim(new char[] { '\r', '\n' });


        //                for (int n = 0; n < onlineUser.Items.Count; n++)
        //                {
        //                    if (onlineUser.Items[n].Text.CompareTo(leaver) == 0)
        //                    {
        //                        onlineUser.Items.RemoveAt(n);
        //                    }
        //                }


        //            }
        //            else if (tokens[0] == "ERROR")
        //            {
        //                MessageBox.Show(tokens[1]);
        //            }
        //            else if (tokens[0] == "QUIT")
        //            {
        //                ns.Close();
        //                clientsocket.Close();
        //                alive = false;
        //                label_show.Text = "服务器断开";
        //                connected = false;
        //                btn_send.Enabled = false;
        //                btn_stopconnect.Enabled = false;
        //                btn_shutdown.Enabled = false;
        //                MessageBox.Show("服务器断开!");

        //            }
        //        }
        //        catch (Exception) { }
        //    }
        //}

        private void QuitChat()
        {
            if (connected)
            {
                try
                {
                    string command = "LEAVE|" + clientname;
                    Byte[] outbytes = System.Text.Encoding.Default.GetBytes(command);
                    ns.Write(outbytes, 0, outbytes.Length);
                    clientsocket.Close();
                }
                catch (Exception)
                {
                }
            }

            if (recThread != null && recThread.IsAlive)
                recThread.Abort();
            this.Text = "聊天室客户端";

        }

        private void ReceiveUdpChat()
        {
            UdpClient udpClient = new UdpClient(11100);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            { 
            Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            string returnData = Encoding.ASCII.GetString(receiveBytes);
            string[] tokens = returnData.Split(new Char[] { '|' });

            string time = System.DateTime.Now.ToLongTimeString();
            allmessageBox.AppendText("消息来自 "+tokens[0].Trim());
            allmessageBox.AppendText("  " + time + " \r\n");
            allmessageBox.AppendText(tokens[1].Trim());
            }
            //Console.WriteLine("This message was sent from " +
            //                        RemoteIpEndPoint.Address.ToString() +
            //                        " on their port number " +
            //                        RemoteIpEndPoint.Port.ToString());
        }
        private void CreateConnection()
        {
            //serveraddress = textBox_ip.Text;
            //serverport = Convert.ToInt32(textBox_port.Text);
            try
            {
                clientsocket = new TcpClient(serveraddress, serverport);
                ns = clientsocket.GetStream();
                sr = new StreamReader(ns);
                connected = true;
                label_show.Text = "连接到服务器";

            }
            catch (Exception)
            {
                MessageBox.Show("无法连接到服务器", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                label_show.Text = "未连接到服务器";
            }
        }
        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "" || textBox_ip.Text == "" || textBox_port.Text == "")
            {
                MessageBox.Show("请输入完整信息", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                clientname = textBox_username.Text;
                serveraddress = textBox_ip.Text;
                serverport = int.Parse(textBox_port.Text);              

            }

            Thread clientrequest = new Thread(new ThreadStart(ClientToServer));
            clientrequest.Start();      
            
        }
        private void ClientToServer()
        {
             //开始TCP服务客户端             
            clientsocket = new TcpClient(serveraddress, serverport);
            ns = clientsocket.GetStream();
            string command = "CONNECT|" + textBox_username.Text + "," + local_udp_addr + "," + local_udp_port.ToString();
            SendToServerMsg(clientsocket, command);            
            
            int i;
            string serverresponse = null;
            Byte[] bytes1 = new Byte[25600];
            connected = true;

            # region while
            //客户端TCP服务保持和服务器连接
            while (connected == true)
            {
                if ((i = ns.Read(bytes1, 0, bytes1.Length)) != 0)
                {
                    serverresponse = System.Text.Encoding.ASCII.GetString(bytes1, 0, i);
                    //string serverresponse =  System.Text.Encoding.ASCII.GetString(bytes, 0, i);            
                    serverresponse.Trim();
                    string[] tokens = serverresponse.Split(new Char[] { '|' });
                    switch (tokens[0])
                    {
                        case "LISTEN":
                            break;
                        case "UPDATE":
                            label_show.Text = "连接到服务器";
                            btn_stopconnect.Enabled = true;
                            onlineUser.Items.Clear();//清空客户端所有在线用户
                            //将新接受到的在线用户更新到列表上
                            for (int n = 1; n < tokens.Length; n++)
                            {
                                if (tokens[n] != "")
                                {
                                    string[] tokens1 = tokens[n].Split(new Char[] { ',' });
                                    ListViewItem lvItem = new ListViewItem();                                    
                                    lvItem.Text = tokens1[0];
                                    lvItem.SubItems.Add(tokens1[1]);
                                    lvItem.SubItems.Add(tokens1[2]);
                                    onlineUser.Items.Add(lvItem);
                                }
                                //   onlineUser.Items.Add(tokens[n].Trim(new char[] { '\r', '\n' }));
                            }
                            if (udpListenOn == false)
                                StartUdpListen();
                            break;
                    }                   
                }
            }  
        #endregion
        }
        
        private void StartUdpListen()
        {
            //启动Udp监听器
            IPEndPoint localIpep = new IPEndPoint(
                IPAddress.Parse(local_udp_addr), local_udp_port); // 本机IP和监听端口号

            udpcRecv = new UdpClient(localIpep);//UdpClient udpcRecv

            thrUdpRecv = new Thread(ReceiveMessage);
            thrUdpRecv.Start();
            udpListenOn = true;
            /////////////////////////
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            //关闭客户端，向服务器端发送关闭通知
            string command = "CLOSE|";
            Byte[] bytes = System.Text.Encoding.Default.GetBytes(command);
            ns.Write(bytes, 0, bytes.Length);
            connected = false;
            ns.Close();
            clientsocket.Close();
            //Thread.Sleep(1000);
            Process.GetCurrentProcess().Kill();
            Application.Exit();
        }        

        //private void btn_stopconnect_Click(object sender, EventArgs e)
        //{
        //    QuitChat();
        //    btn_stopconnect.Enabled = false;
        //    btn_connect.Enabled = true;
        //    btn_send.Enabled = false;
        //    btn_shutdown.Enabled = false;
        //    ns.Close();
        //    clientsocket.Close();
        //    recThread.Abort();
        //    connected = false;
        //    onlineUser.Items.Clear();
        //    label_show.Text = "未连接到服务器";

        //    textBox_ip.Enabled = true;
        //    textBox_username.Enabled = true;
        //}

        private void SentMsgToOthers(string msg)
        {
 
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                string message = sendMessageBox.Text;
                sendMessageBox.Text = "";
                //byte[] sendbytes = Encoding.Unicode.GetBytes(message);
                // 实名发送
                IPEndPoint localIpep = new IPEndPoint(
                    IPAddress.Parse(local_udp_addr), local_udp_port+1); // 本机IP，指定的端口号
                udpcSend = new UdpClient(localIpep);
                //Thread thrSend = new Thread(SendMessage);
                //thrSend.Start(message);
                SendMessage(message);
            }
            catch (Exception)
            {
                MessageBox.Show("失去与服务器的连接", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ns.Close();
                clientsocket.Close();
                if (recThread != null && recThread.IsAlive)
                    recThread.Abort();
                connected = false;
                label_show.Text = "未连接到服务器";
            }
        }
        private void SendMessage(object obj)
        {
            string message = (string)obj;
            if (GroupRadio.Checked == true && SingleRadio.Checked == false)
            {
                for (int i = 0; i < onlineUser.Items.Count; ++i)
                {
                    string username = onlineUser.Items[i].SubItems[0].Text;
                    string ip = onlineUser.Items[i].SubItems[1].Text;
                    int port = Int32.Parse(onlineUser.Items[i].SubItems[2].Text);
                    IPEndPoint remoteIpep = new IPEndPoint(
                    IPAddress.Parse(ip), port); // 发送到的IP地址和端口号
                    byte[] sendbytes = Encoding.Unicode.GetBytes(clientname + ": " + message);
                    udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);

                }
                udpcSend.Close();
            }
            else if (GroupRadio.Checked == false && SingleRadio.Checked == true)
            {
                for (int i = 0; i < onlineUser.Items.Count; ++i)
                {
                    if (onlineUser.Items[i].Selected == true)
                    {
                        string username = onlineUser.Items[i].SubItems[0].Text;
                        string ip = onlineUser.Items[i].SubItems[1].Text;
                        int port = Int32.Parse(onlineUser.Items[i].SubItems[2].Text);
                        IPEndPoint remoteIpep = new IPEndPoint(
                        IPAddress.Parse(ip), port); // 发送到的IP地址和端口号
                        byte[] sendbytes = Encoding.Unicode.GetBytes("private talk came from "+clientname + ": " +"\r\n"+ message);
                        udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                        allmessageBox.Text = allmessageBox.Text + "\r\n" + "private talk to" + username+": "+"\r\n"+message;
                    }

                }
            }
               udpcSend.Close();
            
        }
        private void ReceiveMessage(object obj)
        {
            IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);
                    string message = Encoding.Unicode.GetString(
                        bytRecv, 0, bytRecv.Length);
                    //MessageBox.Show(message);
                    allmessageBox.Text = allmessageBox.Text + "\r\n" + message;

                }
                catch (Exception ex)
                {                    
                    break;
                }
            }
        }

        private void SingleRadio_CheckedChanged(object sender, EventArgs e)
        {
            GroupRadio.Checked = false;
            //SingleRadio.Checked = true;
        }

        private void GroupRadio_CheckedChanged(object sender, EventArgs e)
        {
            SingleRadio.Checked = false;
            //GroupRadio.Checked = true;
        }

        private void sendMessageBox_TextChanged(object sender, EventArgs e)
        {

        }
       

       
        

      

        

        
    }
}
