using Newtonsoft.Json;

namespace Source2CPULightmap
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            AppSettings settings = SettingsManager.LoadSettings();
            csgoDirTextbox.Text = settings.csgo_install_dir;
        }

        private void SaveSettings()
        {
            AppSettings settings = new AppSettings
            {
                csgo_install_dir = csgoDirTextbox.Text
            };

            string settingsJson = JsonConvert.SerializeObject(settings);
            File.WriteAllText(WindowsUserInfo.GetConfigPath(), settingsJson);

            // show a message box to restart the app
            MessageBox.Show(
                $"Settings saved successfully! Press OK to restart the app.",
                "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // restart the app
            Application.Restart();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
        }

        private void settingsApplyButton_Click(object sender, EventArgs e)
        {
            // check if cs2.exe exists in csgo dir + game\bin\win64
            string cs2Path = Path.Combine(csgoDirTextbox.Text, "game", "bin", "win64", "cs2.exe");
            if (!File.Exists(cs2Path))
            {
                MessageBox.Show("cs2.exe not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveSettings();

            MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void settingsCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void csgoDirBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                csgoDirTextbox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}