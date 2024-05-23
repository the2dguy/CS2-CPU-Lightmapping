using Newtonsoft.Json;

namespace Source2CPULightmap
{
    public class WindowsUserInfo
    {
        static string username = Environment.UserName;
        static string path = $"C:\\Users\\{username}\\AppData\\Roaming\\Source2Lightmap";
        static string configPath = Path.Combine(path, "config.json");

        public static string GetConfigPath()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return configPath;
        }
    }

    public class AppSettings
    {
        public string csgo_install_dir { get; set; }
    }

    public class SettingsManager
    {
        public static AppSettings LoadSettings()
        {
            string configPath = WindowsUserInfo.GetConfigPath();

            // Check if the settings file exists
            if (File.Exists(configPath))
            {
                // Read the settings from the file
                string settingsJson = File.ReadAllText(configPath);
                return JsonConvert.DeserializeObject<AppSettings>(settingsJson);
            }

            // Return default settings if the file does not exist
            return new AppSettings
            {
                csgo_install_dir = ""
            };
        }

        // public static void ResetSettings()
        // {
        //     // Reset settings to default values
        //     AppSettings defaultSettings = new AppSettings
        //     {
        //         csgo_install_dir = ""
        //     };
        //
        //     string configPath = WindowsUserInfo.GetConfigPath();
        //
        //     // Serialize the default settings to JSON
        //     string defaultSettingsJson = JsonConvert.SerializeObject(defaultSettings);
        //
        //     // Write the default settings to the file
        //     File.WriteAllText(configPath, defaultSettingsJson);
        //
        //     MessageBox.Show("Settings reset to default values", "Success", MessageBoxButtons.OK,
        //         MessageBoxIcon.Information);
        // }

        public static string CheckSettings()
        {
            // Load settings
            var settings = LoadSettings();
            var missingSettings = new List<string>();

            // Check for missing settings
            if (string.IsNullOrEmpty(settings.csgo_install_dir))
            {
                missingSettings.Add("CS:GO/CS2 Install Directory");
            }

            string missingList = string.Join("\n", missingSettings);
            return missingList;
        }
    }
}