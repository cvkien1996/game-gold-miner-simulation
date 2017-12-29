using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaoVangObjects;

namespace DaoVangServer
{
    public partial class Form1 : Form
    {
        private Grabber[] grabbers = new Grabber[2];            
        private Button[] grabbers_btn = new Button[2];
        private int[] points = new int[2];

        private Mine mine;
        private List<Button> mine_btns;

        private volatile int clicked = 0;
        private Object thisLock = new Object();

        private TCPModel tcp;
        private SocketModel[] sockets1 = new SocketModel[2];    // Socket chinh, chu yeu gui nhan di chuyen cua player 1
        private SocketModel[] sockets2 = new SocketModel[2];    // Gui nhan di chuyen cua player 2
        private SocketModel[] sockets3 = new SocketModel[2];    // Gui nhan diem cua player 1 va thong bao game end
        private SocketModel[] sockets4 = new SocketModel[2];    // Gui nhan diem cua player 2 va thong bao game end

        private int numberOfClients = 0;

        public Form1()
        {
            InitializeComponent();   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcp.Shutdown();
        }

        // Khoi tao server
        void initServer()
        {
            tcp = new TCPModel(ServerIP_tb.Text, int.Parse(ServerPort_tb.Text));
            tcp.Listen();
        }

        // Ket noi voi clients, tao 4 socket
        void acceptConnection()
        {
            int status = -1;
            Socket s1 = tcp.SetUpANewConnection(ref status);
            sockets1[numberOfClients] = new SocketModel(s1);

            status = -1;
            Socket s2 = tcp.SetUpANewConnection(ref status);
            sockets2[numberOfClients] = new SocketModel(s2);

            status = -1;
            Socket s3 = tcp.SetUpANewConnection(ref status);
            sockets3[numberOfClients] = new SocketModel(s3);

            status = -1;
            Socket s4 = tcp.SetUpANewConnection(ref status);
            sockets4[numberOfClients] = new SocketModel(s4);

            String str = "";
            str = str + sockets1[numberOfClients].GetRemoteEndpoint() + "\n";
            Connections_tb.AppendText(str);
            Connections_tb.Update();   

            numberOfClients++;
        }

        // Thread phuc vu client
        void serve1(Object obj)
        {
            int index = (Int32)obj;
            int opponentIndex = -1;
            if (index == 0)
                opponentIndex = 1;
            else if (index == 1)
                opponentIndex = 0;

            while (true)
            {			
                string command = sockets1[index].ReceiveStringData();
                // Da du 2 players chua ?
                if (command.Equals("NUMBER OF PLAYERS"))
                {
                    sockets1[index].SendData(numberOfClients.ToString());
                }
                // Thuc hien ket noi
                else if (command.Equals("CONNECT"))
                {
                    sockets1[index].SendData("Connection accepted");
                }
                // Thuc hien khi player chon "PLAY", gui mine, grabbers va points ve client
                else if (command.Equals("PLAY"))
                {
                    sockets1[index].SendData(grabbers[index]);
                    sockets2[index].SendData(grabbers[opponentIndex]);
                    sockets1[index].SendData(mine);
                    sockets3[index].SendData(points[index].ToString());
                    sockets4[index].SendData(points[opponentIndex].ToString());
                }
                // Khi grabber cua client di chuyen se gui ve server va server se gui ve cho client doi thu
                else if (command.Equals("CLIENT MOVE"))
                {
                    Grabber temp = (Grabber)sockets1[index].ReceiveObjectData();
                    grabbers[index] = temp;

                    sockets2[opponentIndex].SendData("OPPONENT MOVE");
                    sockets2[opponentIndex].SendData(grabbers[index]);

                    updateGrabberButton(index);
                }
                // Thuc hien xoa item va cong diem tren server, gui diem so ve cho clients
                else if (command.Equals("REMOVE GRABBED ITEM"))
                {
                    Grabber temp = (Grabber)sockets1[index].ReceiveObjectData();
                    grabbers[index] = temp;

                    sockets2[opponentIndex].SendData("REMOVE OPPONENT GRABBED ITEM");
                    sockets2[opponentIndex].SendData(grabbers[index]);

                    //Connections_tb.AppendText(grabbers[index].grabbedItem_index.ToString());
                    grabbers[index].isGrabbing = 0;
                    removeGrabbedItemButton(index);

                    if(grabbers[index].grabbedItem != null)
                    {
                        points[index] += grabbers[index].grabbedItem.value();

                        if (index == 0)
                            Client1_tb.Text = points[index].ToString();
                        else if (index == 1)
                            Client2_tb.Text = points[index].ToString();
                        // Neu khong con item nao => tro choi ket thuc
                        if(mine.listOfMine.Count() == 0)
                        {
                            sockets3[index].SendData("GAME END");
                            sockets4[opponentIndex].SendData("GAME END");

                            sockets3[index].SendData(points[index].ToString());
                            sockets4[opponentIndex].SendData(points[index].ToString());

                            int result = whoWin(index, opponentIndex);
                            if(result == index)
                            {
                                Winner_tb.Text = "Player 1 win";
                                sockets3[index].SendData("YOU WIN");
                                sockets4[opponentIndex].SendData("YOU LOSE");
                            }else if(result == opponentIndex)
                            {
                                Winner_tb.Text = "Player 2 win";
                                sockets3[index].SendData("YOU LOSE");
                                sockets4[opponentIndex].SendData("YOU WIN");
                            }
                            else if(result == -1)
                            {
                                Winner_tb.Text = "DRAW";
                                sockets3[index].SendData("DRAW");
                                sockets4[opponentIndex].SendData("DRAW");
                            }
                        }
                        else
                        {
                            sockets3[index].SendData("MY POINTS");
                            sockets3[index].SendData(points[index].ToString());
                            sockets4[opponentIndex].SendData("OPPONENT POINTS");
                            sockets4[opponentIndex].SendData(points[index].ToString());
                        }
                    }
                    grabbers[index].grabbedItem = null;
                    grabbers[index].grabbedItem_index = -1;
                }
                // Kiem tra va cham tren server
                else if (command.Equals("IS TOUCH"))
                {
                    Grabber temp = (Grabber)sockets1[index].ReceiveObjectData();
                    grabbers[index] = temp;
                    updateGrabberButton(index);

                    int result = isTouch(index);
                    sockets1[index].SendData(result.ToString());
                }
            }
        }

        // Phuc vu tung clients
        void serveMultiClients()
        {
            while (true)
            {
                acceptConnection();

                Thread t1 = new Thread(serve1);
                t1.Start(numberOfClients - 1);
            }
        }

        // Khoi tao button cho grabber
        // Green: player 1
        // Red  : player 2
        void initGrabberButton(int index)
        {
            if (this.InvokeRequired)    //Dung de goi ham trong Thread de chinh sua Controls cua giao dien
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    grabbers_btn[index] = new Button();
                    grabbers_btn[index].Location = new System.Drawing.Point(grabbers[index].getX(), grabbers[index].getY());
                    grabbers_btn[index].Size = new System.Drawing.Size(grabbers[index].getWidth(), grabbers[index].getHeight());
                    grabbers_btn[index].UseVisualStyleBackColor = true;
                    if (index == 0)
                    {
                        grabbers_btn[index].BackColor = Color.FromArgb(100, Color.Green);
                        grabbers_btn[index].FlatAppearance.BorderColor = Color.Green;
                    }
                    else
                    {
                        grabbers_btn[index].BackColor = Color.FromArgb(100, Color.Red);
                        grabbers_btn[index].FlatAppearance.BorderColor = Color.Red;
                    }
                    grabbers_btn[index].FlatStyle = FlatStyle.Flat;
                    grabbers_btn[index].FlatAppearance.BorderSize = 1;
                    this.Controls.Add(grabbers_btn[index]);
                });
            }
            else
            {
                grabbers_btn[index] = new Button();
                grabbers_btn[index].Location = new System.Drawing.Point(grabbers[index].getX(), grabbers[index].getY());
                grabbers_btn[index].Size = new System.Drawing.Size(grabbers[index].getWidth(), grabbers[index].getHeight());
                grabbers_btn[index].UseVisualStyleBackColor = true;
                if(index == 0)
                {
                    grabbers_btn[index].BackColor = Color.FromArgb(100, Color.Green);
                    grabbers_btn[index].FlatAppearance.BorderColor = Color.Green;
                }
                else
                {
                    grabbers_btn[index].BackColor = Color.FromArgb(100, Color.Red);
                    grabbers_btn[index].FlatAppearance.BorderColor = Color.Red;
                }                
                grabbers_btn[index].FlatStyle = FlatStyle.Flat;
                grabbers_btn[index].FlatAppearance.BorderSize = 1;
                this.Controls.Add(grabbers_btn[index]);
            }           
        }

        // Cap nhat location, size button cua grabber
        void updateGrabberButton(int index)
        {
            grabbers_btn[index].Location = new System.Drawing.Point(grabbers[index].getX(), grabbers[index].getY());
            grabbers_btn[index].Size = new System.Drawing.Size(grabbers[index].getWidth(), grabbers[index].getHeight());
            if (grabbers[index].grabbedItem_index != -1)
            {
                mine_btns[grabbers[index].grabbedItem_index].Location = new System.Drawing.Point(grabbers[index].grabbedItem.getX(), grabbers[index].grabbedItem.getY());
            }
        }

        // Khoi tao cac button cho mo vang
        void initMineButtons()
        {
            mine_btns = new List<Button>();
            for(int i = 0; i<mine.listOfMine.Count(); i++)
            {
                SquareBlock block = mine.listOfMine[i];
                Button btn = new Button();
                btn.Location = new System.Drawing.Point(block.getX(), block.getY());
                btn.Size = new System.Drawing.Size(block.getSize(), block.getSize());

                if (block.getType() == 1)
                    btn.BackColor = Color.Gold;
                else if (block.getType() == 2)
                    btn.BackColor = Color.Gray;
                else if(block.getType() == 3)
                    btn.BackColor = Color.LightBlue;

                mine_btns.Add(btn);
                this.Controls.Add(btn);
            }
        }

        // Xoa button cua item ma grabber bat duoc
        void removeGrabbedItemButton(int index)
        {
            if(grabbers[index].grabbedItem_index != -1)
            {
                Button btn = mine_btns[grabbers[index].grabbedItem_index];
                mine_btns.RemoveAt(grabbers[index].grabbedItem_index);
                this.Controls.Remove(btn);
            }
        }

        // Ham xet va cham giua 2 button
        int isTouch(int index)
        {
            for (int i = 0; i < mine_btns.Count(); i++)
            {
                Button c = mine_btns[i];
                if (!c.Equals(grabbers_btn[index]) && grabbers_btn[index].Bounds.IntersectsWith(c.Bounds))
                {
                    lock (thisLock) {
                        mine.listOfMine.RemoveAt(i);
                    } 
                    return i;
                }
            }              
            return -1;
        }

        // Ham xet nguoi chien thang game
        int whoWin(int index, int oppIndex)
        {
            int result = -1;
            if (points[index] > points[oppIndex])
                result = index;
            else if (points[index] < points[oppIndex])
                result = oppIndex;
            else if (points[index] == points[oppIndex])
                result = -1;
            return result;
        }

        // Ham xet va cham giua 2 button cho phien ban offline
        SquareBlock touch(int index)
        {
            for (int i = 0; i < mine_btns.Count(); i++)
            {
                Button c = mine_btns[i];

                if (!c.Equals(grabbers_btn[index]) && grabbers_btn[index].Bounds.IntersectsWith(c.Bounds))
                {
                    SquareBlock result = mine.listOfMine[i];
                    grabbers[index].grabbedItem_index = i;
                    mine.listOfMine.RemoveAt(i);
                    return result;
                }
            }
            return null;
        }

        // Ham xu ly game phien ban offline (tuong doi giong voi ham xu ly game trong Client)
        void Start(object obj)
        {
            while (true)
            {
                if(clicked == 0)
                {
                    grabbers[0].moveGrabber();
                    updateGrabberButton(0);
                    Thread.Sleep(80);
                }
                else
                {
                    if (grabbers[0].isGrabbing == 1)
                    {
                        if (grabbers[0].getHeight() == 25)
                        {
                            clicked = 0;
                            grabbers[0].isGrabbing = 0;
                            removeGrabbedItemButton(0);
                            if (grabbers[0].grabbedItem != null)
                            {
                                points[0] += grabbers[0].grabbedItem.value();
                                Client1_tb.Text = points[0].ToString();
                            }
                            grabbers[0].grabbedItem = null;
                            grabbers[0].grabbedItem_index = -1;
                            button4.Enabled = true;
                        }
                        else
                        {
                            grabbers[0].extendGrabber();
                            updateGrabberButton(0);
                            Thread.Sleep(80);
                        }
                    }
                    else
                    {
                        if (grabbers[0].getHeight() > 710)
                            grabbers[0].isGrabbing = 1;
                        else
                        {
                            grabbers[0].grabbedItem = touch(0);
                            if (grabbers[0].grabbedItem == null)
                            {
                                grabbers[0].extendGrabber();
                                updateGrabberButton(0);
                                Thread.Sleep(80);
                            }
                            else
                            {
                                grabbers[0].isGrabbing = 1;
                            }
                        }   
                    }                     
                }  
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            points[0] = 0;
            grabbers[0] = new Grabber();
            mine = new Mine();
            mine.init();
            initGrabberButton(0);
            initMineButtons();

            Client1_tb.Text = points[0].ToString();

            Thread t = new Thread(Start);
            t.Start();

            StartServer_btn.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clicked = 1;            
            button4.Enabled = false;
        }
        
        private void StartServer_btn_Click(object sender, EventArgs e)
        {
            initServer();

            // Khoi tao mine va grabbers, points cho 2 players
            points[0] = 0;
            points[1] = 0;
            grabbers[0] = new Grabber();
            grabbers[1] = new Grabber();
            mine = new Mine();
            mine.init();
            initGrabberButton(0);
            initGrabberButton(1);
            initMineButtons();

            Client1_tb.Text = points[0].ToString();
            Client2_tb.Text = points[1].ToString();

            Thread t1 = new Thread(serveMultiClients);
            t1.Start();

            StartServer_btn.Enabled = false;
            button2.Enabled = false;
        }
    }
}
