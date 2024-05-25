using Newtonsoft.Json;
using Source2CPULightmap.Classes.Darkmode;
using Source2CPULightmap.Classes.Settings;

namespace Source2CPULightmap
{
    public partial class SettingsForm : Form
    {
        private DarkModeCS DM = null;

        public SettingsForm()
        {
            InitializeComponent();
            DM = new DarkModeCS(this);
            LoadSettings();
        }

        private void LoadSettings()
        {
            csgoDirTextbox.Text = SettingsManager.LoadSettings().csgo_install_dir;
        }

        private void SaveSettings()
        {
            var settings = new AppSettings { csgo_install_dir = csgoDirTextbox.Text };
            string settingsJson = JsonConvert.SerializeObject(settings);
            File.WriteAllText(WindowsUserInfo.GetConfigPath(), settingsJson);

            Messenger.MessageBox("Settings saved successfully! Press OK to restart the app.", "Restart required",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Restart();
        }

        private void settingsApplyButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path.Combine(csgoDirTextbox.Text, "game", "bin", "win64", "cs2.exe")))
            {
                MessageBox.Show("cs2.exe not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveSettings();
        }

        private void settingsCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void csgoDirBrowseButton_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    csgoDirTextbox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}