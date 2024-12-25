using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;

namespace BootVid
{
    public class SplashScreenWindow : Window
    {
        public SplashScreenWindow(string videoPath)
        {
            // Configurar la ventana
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            //WindowStartupLocation = WindowStartupLocation.Manual;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            Background = System.Windows.Media.Brushes.Black;
            Topmost = true;

            Width = SystemParameters.PrimaryScreenWidth;
            Height = SystemParameters.PrimaryScreenHeight;
            //var screenWidth = SystemParameters.PrimaryScreenWidth;
            //var screenHeight = SystemParameters.PrimaryScreenHeight;

            /*Left = 0;
            Top = 0;
            if (screenWidth / screenHeight != 16.0 / 10.0)
            {
                //Width = 1280;
                //Height = 800;
                Left = (screenWidth - 1280) / 2;
                Top = (screenHeight - 800) / 2;
            }*/

            // Crear y agregar el UserControl
            var splashControl = new SplashScreenControl(videoPath);
            splashControl.SplashScreenEnded += () => this.Close();

            Content = splashControl;
        }
    }
}
