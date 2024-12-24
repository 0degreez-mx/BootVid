using Microsoft.Win32;
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

namespace BootVid
{
    public partial class BootVidSettingsView : UserControl
    {
        private BootVidSettingsViewModel viewModel;
        /*public BootVidSettingsView()
        {
            InitializeComponent();
        }*/
        public BootVidSettingsView(BootVidSettingsViewModel viewModel)
        {
            InitializeComponent();
            //this.viewModel = viewModel;
            this.viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            DataContext = this.viewModel;
        }

        private void OnBrowseClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mkv|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                if (viewModel?.Settings != null) // Validar que viewModel y Settings no sean null
                {
                    viewModel.Settings.VideoPath = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("Error: La configuración no está inicializada.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}