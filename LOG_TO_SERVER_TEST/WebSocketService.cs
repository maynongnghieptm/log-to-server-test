using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LOG_TO_SERVER_TEST
{
    internal class WebSocketService
    {
        SocketIO client;

        public WebSocketService(SocketIO client)
        {
            this.client = client;
        }

        public SocketIO GetClient()
        {
            return this.client;
        }

        public void SetClient(SocketIO client)
        {
            this.client = client;
        }

        public async void connectWSServer()
        {
            await this.client.ConnectAsync();
        }

        public async void disconnectWSServer()
        {
            await this.client.DisconnectAsync();
        }

        public async void sendTractorLogs(string eventName, string message)
        {
            try
            {
                if(this.client != null && this.client.Connected)
                {
                    await this.client.EmitAsync(eventName, message);
                }
            } catch (Exception e)
            {
                MessageBox.Show("Exception Occured when send logs to server");
            }
        }

        public async void onConnected(object? sender, EventArgs e) 
        {
            Console.WriteLine("Connected to websocket server");
            sendTractorLogs("send logs", "dca8616a-e0a7-4b09-8dd7-a5a97c27a687*13403c4f-5c5f-4c15-afa6-2a009265edce*1668589200000*start_message_go_hear*1");
        }
    }
}
