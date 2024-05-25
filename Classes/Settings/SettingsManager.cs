using Newtonsoft.Json;

namespace Source2CPULightmap.Classes.Settings
{
    public static class WindowsUserInfo
    {
        private static readonly string path =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Source2Lightmap");

        private static readonly string configPath = Path.Combine(path, "config.json");

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
        public string csgo_install_dir { get; set; } = "";
    }

    public static class SettingsManager
    {
        public static AppSettings LoadSettings()
        {
            string configPath = WindowsUserInfo.GetConfigPath();

            if (File.Exists(configPath))
            {
                string settingsJson = File.ReadAllText(configPath);
                return JsonConvert.DeserializeObject<AppSettings>(settingsJson);
            }

            return new AppSettings();
        }

        public static string CheckSettings()
        {
            var settings = LoadSettings();
            return string.IsNullOrEmpty(settings.csgo_install_dir) ? "CS:GO/CS2 Install Directory" : string.Empty;
        }
    }
}