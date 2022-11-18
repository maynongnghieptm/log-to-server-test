using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


using System.Net;
using System.Text;  // For class Encoding
using System.IO;    // For StreamReader

using System.Net.Http;
using RestSharp;
using DataFormat = RestSharp.DataFormat;
using System.Windows.Markup;



namespace LOG_TO_SERVER_TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            InitializeComponent();



            String JSON_STRING = GET_string_file("C://Tractor_project/Tractor_App/MY_TRACTOR/html/Plan_Configure.txt");

            if (JSON_STRING.Length >= 0)
            {
                READ_Plan_Configure(JSON_STRING);
            }

            


            var client = new RestClient("http://192.168.1.9:443");
            var request = new RestRequest("/auth/login");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { username = "sonnguyenhong", password = "123123" }); // Anonymous type object is converted to Json body

            var response = client.Post(request);
            var content = response.Content; // Raw content as string
                                            // var response2 = client.Post<Person>(request);
                                            //var name = response2.Data.Name;
            Debug.WriteLine(content);
            Debug.WriteLine(content);
            Debug.WriteLine(content);
            Debug.WriteLine(content);


            MessageBox.Show(content);


        }
    }
}
