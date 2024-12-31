using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SharpDX.XInput;
using System.Windows.Threading;

namespace BootVid
{
    public class SplashScreenWindow : Window
    {
        private readonly Controller controller;
        private readonly DispatcherTimer inputTimer;
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
            KeyDown += OnKeyDown;
            PreviewKeyDown += OnPreviewKeyDown;
            Focusable = true;
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
            controller = new Controller(UserIndex.One);
            inputTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            inputTimer.Tick += CheckGamepadInput;
            inputTimer.Start();

            var splashControl = new SplashScreenControl(videoPath);
            splashControl.SplashScreenEnded += () =>
            {
                inputTimer.Stop();
                this.Close();
            };

            Content = splashControl;
            
        }
        private void CheckGamepadInput(object sender, EventArgs e)
        {
            if (GamepadInputHandler.IsButtonPressed(controller, GamepadButtonFlags.B))
            {

                inputTimer.Stop();
                this.Close();
            }
        }

        private void OnKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                inputTimer.Stop();
                this.Close();
            }
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                //e.Handled = true;
            }
        }
    }
}
