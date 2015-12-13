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
using System.Collections;
using System.Threading;
using System.Diagnostics;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        public int listenport = 8888; //服务器端监听端口   
        private TcpListener listener;    //服务器监听器  
        IPAddress localIP = IPAddress.Parse("127.0.0.1");
        private ArrayList clients;     // 已连接客户端数组  
        private Thread processor;    //主线程  
        //     private Socket clientsocket;   //客户端套接字  
        private TcpClient tcpClient;
        private Thread clientservice;     //客户端线程
        private bool connected = false;


        class Client
        {
            //       private string Name;
            private string username;
            private TcpClient tcpClient;
            private Thread clThread;
            public string Name
            {
                get { return username; }
                set { username = value; }
            }
            public TcpClient Tcp_client
            {
                get { return tcpClient; }
                set { tcpClient = value; }
            }
            public Thread CLThread
            {
                get { return clThread; }
                set { clThread = value; }
            }
            public Client(string Name, TcpClient tcpClient, Thread CLThread)
            {
                this.Name = Name;
                this.Tcp_client = tcpClient;
                this.CLThread = CLThread;

            }

        }
        public Form1()
        {
            InitializeComponent();
            //textPort.Text = "8888";
        }

        private void StartListening()
        {
            listener = new TcpListener(localIP, listenport);
            listener.Start();
            while (true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    tcpClient = client;
                    clientservice = new Thread(new ThreadStart(ServiceClient));
                    //开始服务客户端 
                    clientservice.Start();   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            //listener.Stop();  
        }


        private void ServiceClient()
        {
            TcpClient client = tcpClient;
            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();
            int i;
            // Buffer for reading data
            Byte[] bytes = new Byte[25600];
            String data = null;
            Client c = null;
            connected = true;
            // Loop to receive all the data sent by the client.
            string cur_user ="";
            while (connected == true)
            {
                if ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    string[] tokens = data.Split(new Char[] { '|' });
                    switch (tokens[0])
                    {
                        case "CLOSE":
                            connected = false;
                            break;
                        case "CONNECT":
                            string[] tokens1 = tokens[1].Split(new Char[] { ',' });
                            ListViewItem lvItem = new ListViewItem();                                    
                            lvItem.Text = tokens1[0];
                            cur_user = tokens[1];
                            lvItem.SubItems.Add(tokens1[1]);
                            lvItem.SubItems.Add(tokens1[2]);
                            onlineUser.Items.Add(lvItem);//服务器界面添加刚加入用户
                            c = new Client(tokens[1], client, clientservice); //将处理该客户端的TCP连接保存到自定义的对象中
                            clients.Add(c);//服务器端将该tcp连接保存起来
                            UpdateToClients();                            
                            break;
                    }
                    if (connected == false) break; //客户端关闭连接，服务器端相应的线程也停止监听，                   
                    // Process the data sent by the client.                     
                    bytes.Initialize();//清空bytes，方便下一次读取信息
                }
            }
            DelUser(cur_user);//删除服务器端离线的用户，更新在线用户列表
            UpdateToClients();//将更新后的在线用户推送到所有客户端
            stream.Close();
            client.Close();
        }
        private void DelUser(string username)
        {
            for (int i = 0; i < clients.Count; ++i)
            {
                if (((Client)clients[i]).Name == username)
                {
                    int idx = FindIdxInListView(username);
                    onlineUser.Items.RemoveAt(idx);
                    //MessageBox.Show("removed");
                    clients.RemoveAt(i);
                }
            }
        }
        private void UpdateToClients()
        {
            for (int i = 0; i < clients.Count; ++i)
            {
                string message = "UPDATE|" + GetChatterList(); //将目前在线用户发给客户端
                SendToClient(((Client)clients[i]), message);//向客户端发送消息message
            }

        }
        private int FindIdxInListView(string username)
        {
            string[] tokens1 = username.Split(new Char[] { ',' });
            string tmp_username = tokens1[0];
            for (int i = 0; i < onlineUser.Items.Count; ++i)
                if ((string)onlineUser.Items[i].SubItems[0].Text == tmp_username)
                    return i;
            return -1;
        }
        private void SendToClient(Client cl, string message)
        {
            try
            {
                NetworkStream stream = cl.Tcp_client.GetStream();
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(message);
                // Send back a response.
                stream.Write(msg, 0, msg.Length);

            }
            catch (Exception)
            {
                cl.Tcp_client.Close();
                cl.CLThread.Abort();
                clients.Remove(cl);
                //       clientlist.Items.Remove(cl.Name + " : " + cl.Host.ToString());
            }
        }
        private string GetChatterList()
        {
            string chatters = "";
            for (int n = 0; n < clients.Count; n++)
            {
                Client cl = (Client)clients[n];
                chatters += cl.Name;
                chatters += "|";
            }
            chatters = chatters.Substring(0, chatters.Length - 1);
            //chatters.Trim(new char[] { '|' });
            return chatters;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (textPort.Text != "8888")
                listenport = Convert.ToInt32("8888");

            Control.CheckForIllegalCrossThreadCalls = false;
            clients = new ArrayList(); 
            //开始一个监听线程  
            processor = new Thread(new ThreadStart(StartListening));
            processor.Start();
            MessageBox.Show("开始监听！");
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
            Application.Exit();
        }      


    }
}
