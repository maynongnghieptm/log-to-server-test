using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;
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
            string tractorid = "64e2241bf3ea921e3f7855bb";
            try
            {
                webSocketService = new WebSocketService(new SocketIO(host, new SocketIOOptions
                {
                    ExtraHeaders = new Dictionary<string, string>
                    {
                        { "tractorid", tractorid }
                    }
                }));
                webSocketService.connectWSServer();
                SocketIO client = webSocketService.GetClient();
                client.OnConnected += (sender, e) =>
                {
                    this.Dispatcher.Invoke(async () =>
                    {
                        statusConnectionTbx.Text = "Connect to WS Server successfully!";
                    });
                    client.On(tractorid, async (message) =>
                    {
                        Debug.WriteLine("Hello");
                        var dataArray = JArray.Parse(message.ToString());
                       
                        Debug.WriteLine(dataArray[0]["fileConfig"]);
                        using(HttpClient httpClient = new HttpClient())
                        {
                            HttpResponseMessage response = await httpClient.GetAsync(dataArray[0]["fileConfig"].ToString());
                            
                            if(response.IsSuccessStatusCode)
                            {
                                byte[] contentBytes = await response.Content.ReadAsByteArrayAsync();
                                Debug.WriteLine("Writing to file ...");
                                string localFilePath = "fileConfig.txt";

                                File.WriteAllBytes(localFilePath, contentBytes);
                            } else
                            {
                                Debug.WriteLine($"Failed to download file. Status code: {response.StatusCode}");
                            }
                        }
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
            webSocketService.sendTractorLogs("logs", message);
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
                string msg = "{\"t\":\"0\",\"data\":{\"id\":[\"1\",\"1\"],\"drive\":[0,1,2,0,0],\"time\":[26,12,2022,9,32,45,97],\"llh\":[20.9553559616953,105.846090000165,0],\"xyz\":[48587961.6456527,2317439.06053528,0],\"ypr\":[0,0,0],\"rfbs\":[0,0,0,0],\"tha\":[0,0,0],\"bt\":[0,0],\"frs\":[0,24.48,0,0],}}";
                while (sending)
                {
                    if (cnt < 1)
                    {
                        sendLogs(webSocketService, this.mainWindow.GetTractor().GetId() + "|" + this.mainWindow.GetField().GetId() + "|1668589200000|" + msg + "|1");
                        cnt++;
                    }
                    else if(cnt < 15)
                    {
                        sendLogs(webSocketService, this.mainWindow.GetTractor().GetId() + "|" + this.mainWindow.GetField().GetId() + "|1668589200000|" + msg + "|2");
                        cnt++;
                    } else
                    {
                        sendLogs(webSocketService, this.mainWindow.GetTractor().GetId() + "|" + this.mainWindow.GetField().GetId() + "|1668589200000|" + msg + "|0");
                        //sending = false;
                        cnt = 0;
                    }
                    Debug.WriteLine("Hello");
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
