using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;

namespace NP_HW_7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DownloadButton(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Download);
            thread.Start(path.Text);
        }

        private void Download(object obj)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile((string)obj, "newFile.txt");
            }
        }

        private void OpenButton(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Directory.GetCurrentDirectory();
            if (file.ShowDialog()==true)
            {
                var fileStream = file.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding(1251)))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            MessageBox.Show(fileContent);
        }
    }
}
