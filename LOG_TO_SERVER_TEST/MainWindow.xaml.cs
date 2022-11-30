using System;
using System.Windows;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using RestSharp;

using LOG_TO_SERVER_TEST.DTO;
using LOG_TO_SERVER_TEST.Pages;
using Microsoft.Win32;
using LOG_TO_SERVER_TEST.Model;

namespace LOG_TO_SERVER_TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog;
        CreateNewRoute createNewRoute;
        string token;
        Tractor tractor;
        Field field;
        ApiService apiService = new ApiService();
        String GET_string_file(String fullPath)
        {


            using (StreamReader r = new StreamReader(fullPath))
            {

                return r.ReadToEnd();

            }
            return "";
        }


        void READ_Plan_Configure(String JSON_STRING )
        {
            dynamic JSON_OBJECT = JObject.Parse(JSON_STRING);
            if (JSON_OBJECT == null)
            {
                return;
            }

            double  Ban_kinh_re_MAC_DINH = ((double)JSON_OBJECT.R_default);
            double  Khoang_cach_duong_song_song_MAC_DINH = ((double)JSON_OBJECT.D_Line_default);


            JArray Origin_P_OUT_ll = JSON_OBJECT.Origin_P_OUT_ll.P;
            String  LATLONG_POLYGON_OUT_SAVE = Origin_P_OUT_ll.ToString();
            double VAR_______BAN_KINH_AN_TOAN = ((double)JSON_OBJECT.Origin_P_OUT_ll.D_safe);
            double VAR_______So_vong_xoan = ((int)JSON_OBJECT.Origin_P_OUT_ll.XN);
            double  VAR_______Khoang_cach_song_song = ((double)JSON_OBJECT.Origin_P_OUT_ll.D_line);
            double  VAR_______ban_kinh_re = ((double)JSON_OBJECT.Origin_P_OUT_ll.R);
            double VAR_______FLAG_Enable_edit = ((int)JSON_OBJECT.Origin_P_OUT_ll.E);

            Debug.WriteLine("VAR_______BAN_KINH_AN_TOAN=" + VAR_______BAN_KINH_AN_TOAN);


            if (Origin_P_OUT_ll.Count >= 2 && (Origin_P_OUT_ll.Count % 2) == 0)
            {

                int size = Origin_P_OUT_ll.Count / 2;
                for (int i = 0; i < size; i++)
                {
                    double X = ((double)Origin_P_OUT_ll[i * 2]);
                    double Y = ((double)Origin_P_OUT_ll[i * 2 + 1]);
                }

            }

         


        }

        public MainWindow()
        {
            const string wss = "http://192.168.1.14:443";
            const string httpServer = "http://192.168.1.14:443";

            InitializeComponent();
            
            //WebSocketService webSocketService = new WebSocketService(new SocketIO(wss));
            //SocketIO client = webSocketService.GetClient();
            //webSocketService.connectWSServer();


            //client.OnConnected += webSocketService.onConnected; 

            //String JSON_STRING = GET_string_file("C://Tractor_project/Tractor_App/MY_TRACTOR/html/Plan_Configure.txt");

            //if (JSON_STRING.Length >= 0)
            //{
            //    READ_Plan_Configure(JSON_STRING);
            //}
        }

        public ApiService GetApiService()
        {
            return apiService;
        }

        public string GetToken()
        {
            return token;
        }

        public Tractor GetTractor()
        {
            return tractor;
        }

        public Field GetField()
        {
            return field;
        }

        public void SetTractor(Tractor tractor)
        {
            this.tractor = tractor;
        }

        public void SetField(Field field)
        {
            this.field = field;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            createNewRoute = new CreateNewRoute(this);
            createNewRoute.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            LoginDTO loginDTO = new LoginDTO
            {
                username = username,
                password = password
            };
            string content = apiService.sendJsonPostRequest("/auth/login", loginDTO);
            JObject jsonContent = JObject.Parse(content);
            token = jsonContent["data"]["token"].ToString();
            MessageBox.Show(token);
        }

        private void usernameInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void connectToWssBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveTractorLog saveTractorLog = new SaveTractorLog(this);
            saveTractorLog.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SelectTractorAndField selectTractorAndField = new SelectTractorAndField(this);
            selectTractorAndField.Show();
        }
    }
}
