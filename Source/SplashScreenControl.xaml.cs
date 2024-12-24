﻿using System;
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
    /// <summary>
    /// Interaction logic for SplashScreenControl.xaml
    /// </summary>
    public partial class SplashScreenControl : UserControl
    {
        public event Action SplashScreenEnded;

        public SplashScreenControl(string videoPath)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(videoPath))
            {
                VideoPlayer.Source = new Uri(videoPath);
            }
        }

        private void OnMediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            SplashScreenEnded?.Invoke();
        }
    }
}