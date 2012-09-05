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
using System.Threading;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace LFSPWPC
{
    public partial class Form1 : Form
    {
        private TcpListener listener;
        private Thread listenThread;
        private const int PORT = 1234;
        private int gear = 0;
        private int sensitivity = 70;
        private int x_temp = 0;
        private double NOISE = 4.1;
        private int OFFSET;

        private Boolean mouse = false;

        const int MF_BYPOSITION = 0x400;

        /* 'X' bezáró gomb kikapcsolása - 1 */
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        /* Egér szimulálása */
        [DllImport("user32.dll")]
        internal extern static int SetCursorPos(int x, int y);

        /* Billentyűzet szimulálása*/
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /* Ablak adatai*/
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        private IntPtr GetActiveWindow()
        {
            IntPtr handle = IntPtr.Zero;
            return GetForegroundWindow();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        
            public int Top;         
            public int Right;      
            public int Bottom; 
        }

        private RECT win;

        public const int VK_A = 0x41;
        public const int VK_S = 0x53;
        public const int VK_D = 0x44;
        public const int VK_G = 0x47;
        public const int VK_SPACE = 0x20;

        private int deskWidth = Screen.PrimaryScreen.Bounds.Width;
        private int deskHeight = Screen.PrimaryScreen.Bounds.Height;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* 'X' bezáró gomb kikapcsolása - 2*/
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);

            IPAddress serverIP = IPAddress.Parse(getLocalIP());
            IPEndPoint server = new IPEndPoint(serverIP, PORT);

            txbIP.Text = getLocalIP()+":"+PORT.ToString();

            txbMouse.Text = "OFF";
            txbSens.Text = "70";

            txbNoise.Text = "4,1";

            listener = new TcpListener(IPAddress.Any, 1234);
            listener.Start();

            startServer();
        }

       private string getLocalIP()
        {
            string localIP = null;

            System.Net.IPHostEntry localIPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            foreach (System.Net.IPAddress localIPAddress in localIPHostEntry.AddressList)
            {
                if (localIPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = localIPAddress.ToString();
                }

            }

            return localIP;
        }


        private void startServer()
        {

            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();

        }

        private void stopServer()
        {
            listener.Stop();
        }

        private void ListenForClients()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] buffer = new byte[32];
            int data;

            txbClient.Invoke((MethodInvoker)delegate
            {
                txbClient.Text = "Client connected.";
            });

            Thread.Sleep(200);

            while (true)
            {
                data = 0;

                try
                {
                    data = clientStream.Read(buffer, 0, 32);
                }
                catch
                {   
                    txbClient.Invoke((MethodInvoker)delegate
                    {
                        txbClient.Text = "Socket error has occured.";
                    });
                    break;
                }

                if (data == 0)
                {
                    txbClient.Invoke((MethodInvoker)delegate
                    {
                        txbClient.Text = "Client disconnected.";
                    });
                    break;
                }

                string text1 = Encoding.UTF8.GetString(buffer, 0, data);
                string[] pre = text1.Split(new char[] { '|' });
                string text = pre[0];

                if(chbTest.Checked)
                {
                    txbAcc.Invoke((MethodInvoker)delegate
                    {
                        txbAcc.Text = text;
                    });
                }

                if(!text.Equals(""))
                {
                    handleCmd(text);
                }
            }

            tcpClient.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void update(double x)
        {
             Graphics g = pictureBox1.CreateGraphics();

             g.Clear(Color.White);
             Pen p = new Pen(Color.Black, 1);

             g.DrawLine(p,new Point(5,25), new Point(395,25));

             Pen p2 = new Pen(Color.Red,5);

             g.DrawRectangle(p2,new Rectangle(new Point((int)(x*10)+200,19),new Size(11,11)));
            
        }

        private void handleCmd(string text)
        {

           if(text == "gason"){

               //MessageBox.Show("Gas on4");
               //ControlSendMessage("Live for Speed", VK_A);
               sendKeyDown("Live for Speed", VK_A);

               if (chbTest.Checked)
               {
                   rbGas.Invoke((MethodInvoker)delegate
                   {
                       rbGas.Checked = true;
                   });
                   rbBrake.Invoke((MethodInvoker)delegate
                   {
                       rbBrake.Checked = false;
                   });
                   rbHBrake.Invoke((MethodInvoker)delegate
                   {
                       rbHBrake.Checked = false;
                   });
               }
           }
           else if (text == "gasoff")
           {
               //MessageBox.Show("Gas off4");
               //ControlSendMessage("Live for Speed", VK_S);
               sendKeyUp("Live for Speed", VK_A);

               if (chbTest.Checked)
               {
                   rbBrake.Invoke((MethodInvoker)delegate
                   {
                       rbBrake.Checked = false;
                   });
                   rbGas.Invoke((MethodInvoker)delegate
                   {
                       rbGas.Checked = false;
                   });
                   rbHBrake.Invoke((MethodInvoker)delegate
                   {
                       rbHBrake.Checked = false;
                   });
               }
           }
           else if (text == "brakeon")
           {
               //ControlSendMessage("Live for Speed", VK_S);
               sendKeyDown("Live for Speed", VK_S);

               if (chbTest.Checked)
               {
                   rbBrake.Invoke((MethodInvoker)delegate
                   {
                       rbBrake.Checked = true;
                   });
                   rbGas.Invoke((MethodInvoker)delegate
                   {
                       rbGas.Checked = false;
                   });
                   rbHBrake.Invoke((MethodInvoker)delegate
                   {
                       rbHBrake.Checked = false;
                   });
               }
           }
           else if (text == "brakeoff")
           {
               //ControlSendMessage("Live for Speed", VK_S);
               sendKeyUp("Live for Speed", VK_S);

               if (chbTest.Checked)
               {
                   rbBrake.Invoke((MethodInvoker)delegate
                   {
                       rbBrake.Checked = false;
                   });
                   rbGas.Invoke((MethodInvoker)delegate
                   {
                       rbGas.Checked = false;
                   });
                   rbHBrake.Invoke((MethodInvoker)delegate
                   {
                       rbHBrake.Checked = false;
                   });
               }
           }
           else if (text == "hbrakeon")
           {
               //ControlSendMessage("Live for Speed", VK_SPACE);
               sendKeyDown("Live for Speed", VK_SPACE);

               if (chbTest.Checked)
               {
                   rbBrake.Invoke((MethodInvoker)delegate
                   {
                       rbBrake.Checked = false;
                   });
                   rbGas.Invoke((MethodInvoker)delegate
                   {
                       rbGas.Checked = false;
                   });
                   rbHBrake.Invoke((MethodInvoker)delegate
                   {
                       rbHBrake.Checked = true;
                   });
               }
           }
           else if (text == "hbrakeoff")
           {
               //ControlSendMessage("Live for Speed", VK_SPACE);
               sendKeyUp("Live for Speed", VK_SPACE);

               if (chbTest.Checked)
               {
                   rbBrake.Invoke((MethodInvoker)delegate
                   {
                       rbBrake.Checked = false;
                   });
                   rbGas.Invoke((MethodInvoker)delegate
                   {
                       rbGas.Checked = false;
                   });
                   rbHBrake.Invoke((MethodInvoker)delegate
                   {
                       rbHBrake.Checked = false;
                   });
               }
           }
           else if (text == "shiftp")
           {
               ControlSendMessage("Live for Speed",VK_D);

               if (chbTest.Checked)
               {
                   gear++;

                   txbGear.Invoke((MethodInvoker)delegate
                   {
                       if (gear <= 0)
                       {
                           txbGear.Text = "R";
                           gear = 0;
                       }
                       else if (gear > 5)
                       {
                           gear = 5;
                           txbGear.Text = gear.ToString();
                       }
                       else
                       {
                           txbGear.Text = gear.ToString();
                       }
                   });
               }
           }
           else if (text == "shiftm")
           {
               ControlSendMessage("Live for Speed", VK_G);
               //mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTDOWN, (int)deskWidth / 2, (int)deskHeight / 2, 0, 0);

               if (chbTest.Checked)
               {
                   gear--;

                   txbGear.Invoke((MethodInvoker)delegate
                   {
                       if (gear <= 0)
                       {
                           txbGear.Text = "R";
                           gear = 0;
                       }
                       else if (gear > 5)
                       {
                           gear = 5;
                           txbGear.Text = gear.ToString();
                       }
                       else
                       {
                           txbGear.Text = gear.ToString();
                       }
                   });
               }
           }
           else if (text == "mouse")
           {

               mouse = !mouse;

               if (mouse)
               {
                   txbMouse.Invoke((MethodInvoker)delegate
                   {
                       txbMouse.Text = "ON";
                   });
               }
               else
               {
                   txbMouse.Invoke((MethodInvoker)delegate
                   {
                       txbMouse.Text = "OFF";
                   });
               }


           }
           else
           {
              try
               {
                   int x = (int)Double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);

                   if (NOISE > 8)
                   {
                       NOISE = 8;
                   }

                   if (NOISE < 0)
                   {
                       NOISE = 0;
                   }

                   txbNoise.Text = NOISE.ToString();
                    
                   if (x > x_temp + NOISE || x < x_temp - NOISE) x = x_temp;
                   else x_temp = x;

                   GetWindowRect(GetActiveWindow(), out win);

                   OFFSET = (win.Right + win.Left)/2;

                  // if(bottom < (deskWidth/2)) OFFSET = bottom;
                   //else OFFSET = -bottom;

                   int Y = (int)deskHeight / 2;
                   int X = (int)(x * sensitivity) + OFFSET; //+ (deskWidth / 2);

                   //mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, X, Y, 0, 0);
                   if (mouse) SetCursorPos(X, Y);

                   if (chbTest.Checked)
                   {
                       txbPosX.Invoke((MethodInvoker)delegate
                       {
                           txbPosX.Text = X.ToString();
                       });

                       update(x);
                   } 
               }
               catch
               {
               }
           }
        }

        private void ControlSendMessage(string winTitle, int Key)
        {
            IntPtr hWnd = FindWindow(null, winTitle);             
                //lenyomva
                SendMessage(hWnd, 0x100, (int)Key, 0);
                //tartva
                Thread.Sleep(50);
                //felengedve
                SendMessage(hWnd, 0x101, (int)Key, 0);       
        }

        private void sendKeyDown(string winTitle, int Key)
        {
            IntPtr hWnd = FindWindow(null, winTitle);
            SendMessage(hWnd, 0x100, (int)Key, 0);
        }

        private void sendKeyUp(string winTitle, int Key)
        {
            IntPtr hWnd = FindWindow(null, winTitle);
            SendMessage(hWnd, 0x101, (int)Key, 0); 
        }

        private void tbSens_Scroll(object sender, EventArgs e)
        {
            sensitivity = tbSens.Value;
            txbSens.Text = sensitivity.ToString();
        }

        private void txbSens_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sensitivity = Convert.ToInt32(txbSens.Text);
            }
            catch
            {
                MessageBox.Show("Please type a number between 20 & 200");
                sensitivity = 100;
                txbSens.Text = "100";
            }

            if (sensitivity > 200)
            {
                sensitivity = 200;
            }

            if(sensitivity < 20)
            {
                sensitivity = 20;
            }

            tbSens.Value = sensitivity;
        }

        private void txbNoise_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NOISE = Convert.ToDouble(txbNoise.Text);
            }
            catch
            {
                MessageBox.Show("Please type a number between 0.0 & 8.0!\n Use ','(comma) instead of '.'(point) !");
                NOISE = 4.5;
                txbNoise.Text = "4,5";
            }

            if (NOISE > 8)
            {
                NOISE = 8;
            }

             if (NOISE < 0)
             {
                 NOISE = 0;
             }
        }


    }
}
