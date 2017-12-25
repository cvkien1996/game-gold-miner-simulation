using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaoVangObjects;

namespace DaoVangClient
{
    public partial class Form1 : Form
    {
        private TCPModel tcp1, tcp2, tcp3, tcp4;
        private int backupPort = 13000;

        private Grabber[] grabbers = new Grabber[2];
        private Button[] grabbers_btn = new Button[2];

        private Mine mine;
        private List<Button> mine_btns;
        private volatile int clicked = 0;
        private int numberOfPlayers = 0;
        private int myPoints = 0;
        private int opponentPoints = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            tcp1.CloseConnection();
            tcp2.CloseConnection();
            tcp3.CloseConnection();
            tcp4.CloseConnection();
        }

        int connectServer()
        {
            tcp1 = new TCPModel(ServerIP_tb.Text, int.Parse(ServerPort_tb.Text));
            int flag = tcp1.ConnectToServer();
            tcp2 = new TCPModel(ServerIP_tb.Text, int.Parse(ServerPort_tb.Text));
            flag = tcp2.ConnectToServer();
            tcp3 = new TCPModel(ServerIP_tb.Text, int.Parse(ServerPort_tb.Text));
            flag = tcp3.ConnectToServer();
            tcp4 = new TCPModel(ServerIP_tb.Text, int.Parse(ServerPort_tb.Text));
            flag = tcp4.ConnectToServer();
            return flag;
        }

        void initGrabberButton(int index)
        {
            grabbers_btn[index] = new Button();
            grabbers_btn[index].Location = new System.Drawing.Point(grabbers[index].getX(), grabbers[index].getY());
            grabbers_btn[index].Size = new System.Drawing.Size(grabbers[index].getWidth(), grabbers[index].getHeight());

            grabbers_btn[index].UseVisualStyleBackColor = true;
            grabbers_btn[index].FlatStyle = FlatStyle.Flat;
            if (index == 0)
            {
                grabbers_btn[index].BackColor = Color.FromArgb(100, Color.Blue);
                grabbers_btn[index].FlatAppearance.BorderColor = Color.Blue;
            }
            else
            {
                grabbers_btn[index].BackColor = Color.FromArgb(100, Color.Red);
                grabbers_btn[index].FlatAppearance.BorderColor = Color.Red;
            }
            grabbers_btn[index].FlatAppearance.BorderSize = 1;
            this.Controls.Add(grabbers_btn[index]);
        }

        void updateGrabberButton(int index)
        {
            grabbers_btn[index].Location = new System.Drawing.Point(grabbers[index].getX(), grabbers[index].getY());
            grabbers_btn[index].Size = new System.Drawing.Size(grabbers[index].getWidth(), grabbers[index].getHeight());
            if (grabbers[index].grabbedItem_index != -1)
            {
                mine_btns[grabbers[index].grabbedItem_index].Location = new System.Drawing.Point(grabbers[index].grabbedItem.getX(), grabbers[index].grabbedItem.getY());
            }
        }

        void initMineButtons()
        {
            mine_btns = new List<Button>();
            for (int i = 0; i < mine.listOfMine.Count(); i++)
            {
                SquareBlock block = mine.listOfMine[i];
                Button btn = new Button();
                btn.Location = new System.Drawing.Point(block.getX(), block.getY());
                btn.Size = new System.Drawing.Size(block.getSize(), block.getSize());

                if (block.getType() == 1)
                    btn.BackColor = Color.Gold;
                else if (block.getType() == 2)
                    btn.BackColor = Color.Gray;
                else
                    btn.BackColor = Color.LightBlue;

                mine_btns.Add(btn);
                this.Controls.Add(btn);
            }
        }

        void removeGrabbedItemButton(int index)
        {
            if (grabbers[index].grabbedItem_index != -1)
            {
                Button btn = mine_btns[grabbers[index].grabbedItem_index];
                mine.listOfMine.RemoveAt(grabbers[index].grabbedItem_index);
                mine_btns.RemoveAt(grabbers[index].grabbedItem_index);
                this.Controls.Remove(btn);
            }
        }

        SquareBlock touch(int index)
        {
            int flag1 = tcp1.SendData("IS TOUCH");
            int flag2 = tcp1.SendData(grabbers[index]);
            string tmp = tcp1.ReadStringData();
            int receive = int.Parse(tmp);
            if (receive == -1)
                return null;
            SquareBlock result = mine.listOfMine[receive];
            grabbers[index].grabbedItem_index = receive;
            return result;
        }
        
        void Start(object obj)
        {
            int index = (Int32)obj;
            while (true)
            {             
                if (clicked == 0)
                {
                    grabbers[index].moveGrabber();
                    int flag1 = tcp1.SendData("CLIENT MOVE");
                    int flag2 = tcp1.SendData(grabbers[index]);

                    updateGrabberButton(index);

                    Thread.Sleep(80);
                }
                else
                {                   
                    if (grabbers[index].isGrabbing == 1)
                    {
                        if (grabbers[index].getHeight() == 25)
                        {
                            clicked = 0;
                            int flag1 = tcp1.SendData("REMOVE GRABBED ITEM");
                            int flag2 = tcp1.SendData(grabbers[index]);
                            Connections_tb.AppendText(grabbers[index].grabbedItem_index.ToString());
                            grabbers[index].isGrabbing = 0;
                            removeGrabbedItemButton(index);
                         
                            grabbers[index].grabbedItem = null;
                            grabbers[index].grabbedItem_index = -1;
                            
                            go_btn.Enabled = true;
                        }
                        else
                        {
                            grabbers[index].extendGrabber();
                            int flag1 = tcp1.SendData("CLIENT MOVE");
                            int flag2 = tcp1.SendData(grabbers[index]);
                            updateGrabberButton(index);
                          
                            Thread.Sleep(80);
                        }
                    }
                    else
                    {
                        if (grabbers[index].getHeight() > 710)
                        {
                            grabbers[index].isGrabbing = 1;
                        }                           
                        else
                        {
                            grabbers[index].grabbedItem = touch(index);
                            if (grabbers[index].grabbedItem == null)
                            {
                                grabbers[index].extendGrabber();
                                int flag1 = tcp1.SendData("CLIENT MOVE");
                                int flag2 = tcp1.SendData(grabbers[index]);
                                updateGrabberButton(index);
                                Thread.Sleep(80);
                            }
                            else
                            {
                                grabbers[index].isGrabbing = 1;
                            }
                        }
                    }
                    
                }
            }
        }

        void ReceiveBroadcast(object obj)
        {
            int index = (Int32)obj;
            while (true)
            {
                string command = tcp2.ReadStringData();
                if(command.Equals("OPPONENT MOVE"))
                {
                    Grabber temp = (Grabber)tcp2.ReadObjectData();
                    grabbers[index] = temp;
                    updateGrabberButton(index);
                }
                else if(command.Equals("REMOVE OPPONENT GRABBED ITEM"))
                {
                    Grabber temp = (Grabber)tcp2.ReadObjectData();
                    grabbers[index] = temp;
                    grabbers[index].isGrabbing = 0;
                    removeGrabbedItemButton(index);                          
                    grabbers[index].grabbedItem = null;
                    grabbers[index].grabbedItem_index = -1;
                }
            }
        }

        void ReceiveMyPoints(object obj)
        {
            while (true)
            {
                myPoints = int.Parse(tcp3.ReadStringData());
                Client1_tb.Text = myPoints.ToString();
            }
        }

        void ReceiveOpponentPoints(object obj)
        {
            while (true)
            {
                opponentPoints = int.Parse(tcp4.ReadStringData());
                Client2_tb.Text = opponentPoints.ToString();
            }
        }

        void waitForOpponentConnect(object obj)
        {
            while (numberOfPlayers < 2)
            {
                int flag = tcp1.SendData("NUMBER OF PLAYERS");
                numberOfPlayers = int.Parse(tcp1.ReadStringData());
                Thread.Sleep(100);
            }
            int flag1 = tcp1.SendData("PLAY");
            grabbers[0] = (Grabber)tcp1.ReadObjectData();
            grabbers[1] = (Grabber)tcp2.ReadObjectData();
            mine = (Mine)tcp1.ReadObjectData();
            myPoints = int.Parse(tcp3.ReadStringData());
            opponentPoints = int.Parse(tcp4.ReadStringData());

            play_btn.Enabled = true;
        }

        private void ConnectServer_btn_Click(object sender, EventArgs e)
        {
            if (connectServer() == 1) {

                Thread t = new Thread(waitForOpponentConnect);
                t.Start();
                ConnectServer_btn.Enabled = false;
            };
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            
            initGrabberButton(0);
            initGrabberButton(1);
            initMineButtons();

            Client1_tb.Text = myPoints.ToString();
            Client2_tb.Text = opponentPoints.ToString();

            Thread t1 = new Thread(Start);
            t1.Start(0);

            Thread t2 = new Thread(ReceiveBroadcast);
            t2.Start(1);

            Thread t3 = new Thread(ReceiveMyPoints);
            t3.Start();

            Thread t4 = new Thread(ReceiveOpponentPoints);
            t4.Start();

            play_btn.Enabled = false;
            go_btn.Enabled = true;
        }

        private void go_btn_Click(object sender, EventArgs e)
        {
            clicked = 1;

            go_btn.Enabled = false;
        }
    }
}
