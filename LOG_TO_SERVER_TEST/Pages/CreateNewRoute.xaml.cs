using Microsoft.Win32;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace LOG_TO_SERVER_TEST.Pages
{
    /// <summary>
    /// Interaction logic for CreateNewRoute.xaml
    /// </summary>
    public partial class CreateNewRoute : Window
    {
        MainWindow mainWindow;
        ApiService apiService = new ApiService();
        OpenFileDialog uploadRouteFile = new OpenFileDialog();
        string filename;

        public CreateNewRoute(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uploadRouteFile.CheckFileExists = true;
            uploadRouteFile.AddExtension = true;
            uploadRouteFile.Multiselect = false;
            uploadRouteFile.InitialDirectory = @"C:\";
            uploadRouteFile.Filter = "txt files (*.txt)|*.txt";
            
            if(uploadRouteFile.ShowDialog()==true)
            {  
                filename = uploadRouteFile.FileName;
                pathTextBox.Text = filename;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string token = mainWindow.GetToken();
            var createRouteRequest = new RestRequest("/routes", Method.Post);
            createRouteRequest.AddHeader("Content-Type", "multipart/form-data");
            createRouteRequest.AddHeader("Authorization", "Bearer " + token);
            createRouteRequest.AddFile("routeFile", filename, "text/plain");
            createRouteRequest.AddParameter("field_id", "13403c4f-5c5f-4c15-afa6-2a009265edce");
            var createRouteResponse = apiService.GetClient().Post(createRouteRequest);
            var content = createRouteResponse.Content;
            MessageBox.Show(content);
        }
    }
}
