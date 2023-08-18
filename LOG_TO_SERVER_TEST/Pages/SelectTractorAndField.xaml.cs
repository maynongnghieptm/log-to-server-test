using LOG_TO_SERVER_TEST.Model;
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
using System.Windows.Shapes;

namespace LOG_TO_SERVER_TEST.Pages
{
    /// <summary>
    /// Interaction logic for SelectTractorAndField.xaml
    /// </summary>
    /// 

    public partial class SelectTractorAndField : Window
    {
        MainWindow mainWindow;
        public SelectTractorAndField(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tractor newTractor = new Tractor("5f1e899f-d382-4ec1-8a44-fc2e75e68f95", "Nguyen Quoc Tuan");
            this.mainWindow.SetTractor(newTractor);
            MessageBox.Show("Tractor with id " + newTractor.GetId() + " is selected");
        }

        private void tractor2Btn_Click(object sender, RoutedEventArgs e)
        {
            Tractor newTractor = new Tractor("dca8616a-e0a7-4b09-8dd7-a5a97c27a687", "Nguyen Hong Son");
            this.mainWindow.SetTractor(newTractor);
            MessageBox.Show("Tractor with id " + newTractor.GetId() + " is selected");
        }

        private void field1Btn_Click(object sender, RoutedEventArgs e)
        {
            Field newField = new Field("13403c4f-5c5f-4c15-afa6-2a009265edce", "Field 1");
            this.mainWindow.SetField(newField);
            MessageBox.Show("Field with id " + newField.GetId() + " is selected");                 
        }

        private void field2Btn_Click(object sender, RoutedEventArgs e)
        {
            Field newField = new Field("71828346-4970-4eff-aee8-1375abe7e256", "Field 1");
            this.mainWindow.SetField(newField);
            MessageBox.Show("Field with id " + newField.GetId() + " is selected");
        }
    }
}
