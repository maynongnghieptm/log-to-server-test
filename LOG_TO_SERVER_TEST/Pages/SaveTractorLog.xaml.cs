using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
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
        string tractorid = "64e2241bf3ea921e3f7855bb";
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
                webSocketService = new WebSocketService(new SocketIO(host, new SocketIOOptions
                {
                    ExtraHeaders = new Dictionary<string, string>
                    {
                        { "tractorid", this.tractorid }
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
                    client.On(this.tractorid, async (message) =>
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
            webSocketService.sendTractorLogs($"{this.tractorid}-logs", message);
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
                string msg = "{\"ver\":\"2\",\"id\":[\"34d45345\",\"gt435345\",\"235643gret\"],\"drive\":[36,2,0,65,26],\"time\":[17,12,2023,12,45,979,7],\"sum\":[12323,5543,34545.67,344.234,10.5,4.5],\"llh\":[-20.23213123,123.12312323,122.33],\"xyz\":[123123.123123,15469452.342,122.33],\"ypr\":[123.2,-12.34,123.22],\"rtk\":[234,23,23,2],\"sen\":[23,34,0,0,0,0,0,0,0,0,0,0,0],\"ctr_fed\":[12,23,1020,1001,1,1.0,2,2.0,-1,-1.0,1.21,1.19,35,35.01,5.6,5.4,4.5,4.4],\"ctr_oly\":[1,0,0,0,1,90,90,90],\"plans\":[20.23424,106.123233,20.92342423,106.2123233,20.234224,106.1232633,20.234264,106.8123233,20.234524,106.1232233,20.24346724,106.123233,20.23424,106.1238233,20.9232424,106.1223233,20.235424,106.1232363,20.23424,106.123233,20.232424,106.123233,20.423424,106.1232233,20.23424,106.1232833,20.23424,106.1232233,20.234724,106.1823233],\"err\":[0,1,123,213,122,475,45747]}";

                var jsonObject = new
                {
                    missionId = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                    logs = msg,
                };

                string jsonObjectString = JsonSerializer.Serialize(jsonObject);
                
                while (sending)
                {
                    if (cnt < 1)
                    {
                        sendLogs(webSocketService, jsonObjectString);
                        cnt++;
                    }
                    else if(cnt < 15)
                    {
                        sendLogs(webSocketService, jsonObjectString);
                        cnt++;
                    } else
                    {
                        sendLogs(webSocketService, jsonObjectString);
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
