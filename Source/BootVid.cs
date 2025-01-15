using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Session;
using Playnite.SDK;
using Playnite.SDK.Events;
using Playnite.SDK.Plugins;
using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace BootVid
{
    public class BootVid : GenericPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private BootVidSettingsViewModel settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("5c4269c6-48e8-44c6-a9a9-c72c1090d9f1");

        public BootVid(IPlayniteAPI api) : base(api)
        {
            settings = new BootVidSettingsViewModel(this);
            Properties = new GenericPluginProperties
            {
                HasSettings = true
            };
        }

        public override void OnGameInstalled(OnGameInstalledEventArgs args)
        {
            // Add code to be executed when game is finished installing.
        }

        public override void OnGameStarted(OnGameStartedEventArgs args)
        {
            // Add code to be executed when game is started running.
        }

        public override void OnGameStarting(OnGameStartingEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameStopped(OnGameStoppedEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameUninstalled(OnGameUninstalledEventArgs args)
        {
            // Add code to be executed when game is uninstalled.
        }

        private IAudioSession _session;

        public override void OnApplicationStarted(OnApplicationStartedEventArgs args)
        {
            
            if (PlayniteApi.ApplicationInfo.Mode == ApplicationMode.Fullscreen)
            {
                // Solo mostrar el splash screen si hay un video configurado
                if (!string.IsNullOrEmpty(settings.Settings.VideoPath))
                {
                    var controller = new CoreAudioController();
                    var sessions = controller.DefaultPlaybackDevice.SessionController.ActiveSessions();

                    foreach (var session in sessions)
                    {
                        if (session.DisplayName.Contains("Playnite")) // Identifica el proceso
                        {
                            _session = session;
                            _session.Volume = 0.0; // Mutea Playnite
                            break;
                        }
                    }
                    var playniteProcess = Process.GetCurrentProcess();
                    IntPtr mainWindowHandle = playniteProcess.MainWindowHandle;

                    // Minimizar la ventana principal si se encuentra
                    if (mainWindowHandle != IntPtr.Zero)
                    {
                        NativeMethods.ShowWindow(mainWindowHandle, NativeMethods.SW_HIDE);
                    }
                    var splashScreen = new SplashScreenWindow(settings.Settings.VideoPath);
                    splashScreen.ShowDialog();
                    _session.Volume = 100.0;
                    if (mainWindowHandle != IntPtr.Zero)
                    {
                        NativeMethods.ShowWindow(mainWindowHandle, NativeMethods.SW_SHOW);
                    }
                }
            }
            
        }

        public override void OnApplicationStopped(OnApplicationStoppedEventArgs args)
        {
            // Add code to be executed when Playnite is shutting down.
        }

        public override void OnLibraryUpdated(OnLibraryUpdatedEventArgs args)
        {
            // Add code to be executed when library is updated.
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new BootVidSettingsView(settings);
        }
    }
}