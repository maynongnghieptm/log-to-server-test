using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using SocketIOClient;

namespace LOG_TO_SERVER_TEST.Pages
{
    /// <summary>
    /// Interaction logic for SaveTractorLog.xaml
    /// </summary>
    public partial class SaveTractorLog : Window
    {
        MainWindow mainWindow;
        WebSocketService webSocketService;
        Thread sendLogsThread;
        bool sending = false;
        public SaveTractorLog(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void serverHostInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string host = serverHostInput.Text;
            try
            {
                webSocketService = new WebSocketService(new SocketIO(host));
                webSocketService.connectWSServer();
                SocketIO client = webSocketService.GetClient();
                client.OnConnected += (sender, e) =>
                {
                    this.Dispatcher.Invoke(async () =>
                    {
                        statusConnectionTbx.Text = "Connect to WS Server successfully!";
                    });
                };
            } catch (Exception ex)
            {
                statusConnectionTbx.Text = ex.Message;
            }
        }

        private void statusConnectionTbx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sendLogs(WebSocketService webSocketService, string message)
        {
            webSocketService.sendTractorLogs("send logs", message);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            webSocketService.disconnectWSServer();
            statusConnectionTbx.Text = "WS Server disconnected!";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sendLogsThread = new Thread(() =>
            {
                sending = true;
                int cnt = 0;
                while (sending)
                {
                    if (cnt < 1)
                    {
                        sendLogs(webSocketService, this.mainWindow.GetTractor().GetId() + "*" + this.mainWindow.GetField().GetId() + "*1668589200000*start_message_go_hear*1");
                        cnt++;
                    }
                    else
                    {
                        sendLogs(webSocketService, this.mainWindow.GetTractor().GetId() + "*" + this.mainWindow.GetField().GetId() + "*1668589200000*message_go_hear*2");
                        cnt++;
                    }
                    Thread.Sleep(1000);
                }
            });
            sendLogsThread.Start();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sending = false;
            sendLogsThread = null;
        }
    }
}
