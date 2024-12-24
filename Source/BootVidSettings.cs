using Playnite.SDK;
using Playnite.SDK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootVid
{
    public class BootVidSettings : ObservableObject
    {
        private string videoPath;
        public string VideoPath
        {
            get => videoPath;
            set => SetValue(ref videoPath, value);
        }
    }

    public class BootVidSettingsViewModel : ObservableObject, ISettings
    {
        //private readonly IPlayniteAPI api;
        private readonly BootVid plugin;
        private BootVidSettings editingClone { get; set; }
        private BootVidSettings settings;

        public BootVidSettings Settings
        {
            get => settings;
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }

        public BootVidSettingsViewModel(BootVid plugin)
        {
            this.plugin = plugin;
            //this.api = api;

            // Load saved settings or set defaults
            //var savedSettings = plugin.LoadPluginSettings<BootVidSettings>();
            //Settings = savedSettings ?? new BootVidSettings { VideoPath = "" };
            var savedSettings = plugin.LoadPluginSettings<BootVidSettings>();

            // LoadPluginSettings returns null if no saved data is available.
            if (savedSettings != null)
            {
                Settings = savedSettings;
            }
            else
            {
                Settings = new BootVidSettings { VideoPath = "" };
            }

        }

        public void BeginEdit()
        {
            // Code executed when settings view is opened and user starts editing values.
            editingClone = Serialization.GetClone(Settings);
        }

        public void CancelEdit()
        {
            // Code executed when user decides to cancel any changes made since BeginEdit was called.
            // This method should revert any changes made to Option1 and Option2.
            Settings = editingClone;
        }

        public void EndEdit()
        {
            // Code executed when user decides to confirm changes made since BeginEdit was called.
            // This method should save settings made to Option1 and Option2.
            plugin.SavePluginSettings(Settings);
        }
        public bool VerifySettings(out List<string> errors)
        {
            // Code execute when user decides to confirm changes made since BeginEdit was called.
            // Executed before EndEdit is called and EndEdit is not called if false is returned.
            // List of errors is presented to user if verification fails.
            errors = new List<string>();
            return true;
        }
    }
    /*public class BootVidSettings : ObservableObject
    {
        private string option1 = string.Empty;
        private bool option2 = false;
        private bool optionThatWontBeSaved = false;

        public string Option1 { get => option1; set => SetValue(ref option1, value); }
        public bool Option2 { get => option2; set => SetValue(ref option2, value); }
        // Playnite serializes settings object to a JSON object and saves it as text file.
        // If you want to exclude some property from being saved then use `JsonDontSerialize` ignore attribute.
        [DontSerialize]
        public bool OptionThatWontBeSaved { get => optionThatWontBeSaved; set => SetValue(ref optionThatWontBeSaved, value); }
    }

    public class BootVidSettingsViewModel : ObservableObject, ISettings
    {
        private readonly BootVid plugin;
        private BootVidSettings editingClone { get; set; }

        private BootVidSettings settings;
        public BootVidSettings Settings
        {
            get => settings;
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }

        public BootVidSettingsViewModel(BootVid plugin)
        {
            // Injecting your plugin instance is required for Save/Load method because Playnite saves data to a location based on what plugin requested the operation.
            this.plugin = plugin;

            // Load saved settings.
            var savedSettings = plugin.LoadPluginSettings<BootVidSettings>();

            // LoadPluginSettings returns null if no saved data is available.
            if (savedSettings != null)
            {
                Settings = savedSettings;
            }
            else
            {
                Settings = new BootVidSettings();
            }
        }

        public void BeginEdit()
        {
            // Code executed when settings view is opened and user starts editing values.
            editingClone = Serialization.GetClone(Settings);
        }

        public void CancelEdit()
        {
            // Code executed when user decides to cancel any changes made since BeginEdit was called.
            // This method should revert any changes made to Option1 and Option2.
            Settings = editingClone;
        }

        public void EndEdit()
        {
            // Code executed when user decides to confirm changes made since BeginEdit was called.
            // This method should save settings made to Option1 and Option2.
            plugin.SavePluginSettings(Settings);
        }

        public bool VerifySettings(out List<string> errors)
        {
            // Code execute when user decides to confirm changes made since BeginEdit was called.
            // Executed before EndEdit is called and EndEdit is not called if false is returned.
            // List of errors is presented to user if verification fails.
            errors = new List<string>();
            return true;
        }
    }*/
}