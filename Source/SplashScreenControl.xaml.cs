using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BootVid
{
    /// <summary>
    /// Interaction logic for SplashScreenControl.xaml
    /// </summary>
    public partial class SplashScreenControl : UserControl
    {
        public event Action SplashScreenEnded;

        public SplashScreenControl(string videoPath)
        {
            InitializeComponent();
            /*KeyDown += OnKeyDown;
            PreviewKeyDown += OnPreviewKeyDown;
            Focusable = true;*/
            //ShowCancelInstructions();
            if (!string.IsNullOrEmpty(videoPath))
            {
                VideoPlayer.Source = new Uri(videoPath);
            }
            
        }

        private void OnMediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            SplashScreenEnded?.Invoke();
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape || e.Key == Key.B)
            {
                //ShowCancelInstructions();
                SplashScreenEnded?.Invoke();
            }
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                //e.Handled = true;
            }
        }

        private void ShowCancelInstructions()
        {
            var instructions = new TextBlock
            {
                Text = "Press 'B' on controller or 'ESC' on keyboard to skip.",
                Foreground = System.Windows.Media.Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, 20),
                FontSize = 18
            };

            (Content as Grid)?.Children.Add(instructions);
        }
    }
}
