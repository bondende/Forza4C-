using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forza4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            Condivisa c = new Condivisa();
            Connessione connect = new Connessione(ref c);
            Thread tRicezione = new Thread(new ThreadStart(connect.Ricezione));
            tRicezione.Start();
            */
            new Eventi(this/*,connect*/);
            DrawCanvas.Invoke();
            string[] ips = test();
            foreach (var item in ips)
            {
                txtip.Text += item + "\r\n";
            }

        }

        public static string[] test()
        {
            try
            {
                string localIP;
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                }
                return new string[] { localIP };
            }
            catch (Exception e)
            {
                NetworkInterfaceType _type = NetworkInterfaceType.Ethernet;
                List<string> indirizzi = new List<string>();
                foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                indirizzi.Add(ip.Address.ToString());
                            }
                        }
                    }
                }
                return indirizzi.ToArray();
            }

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(0);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(1);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(2);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(3);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(4);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(5);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick.Invoke(6);
        }

        public event ClickSuCasellaEventHandler ButtonClick;
        public delegate void ClickSuCasellaEventHandler(int colonna);

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            Restart.Invoke();
        }

        public event RestartEventHandler Restart;
        public delegate void RestartEventHandler();

        public event DisegnaCanvas DrawCanvas;
        public delegate void DisegnaCanvas();

    }
}
