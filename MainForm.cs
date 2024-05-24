using BlueMystic;
using System.Diagnostics;

namespace Source2CPULightmap
{
    public partial class MainForm : Form
    {
        private DarkModeCS DM = null;

        public MainForm()
        {
            InitializeComponent();
            DM = new DarkModeCS(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CheckAndLoadSettings())
            {
                PopulateAddonList();
                HandleThreadCount();
                SetDefaultCompileOptions();
            }
        }

        private bool CheckAndLoadSettings()
        {
            string missingList = SettingsManager.CheckSettings();
            if (!string.IsNullOrEmpty(missingList))
            {
                DisplaySettingsWarning(missingList);
                return false;
            }

            return true;
        }

        private void DisplaySettingsWarning(string missingList)
        {
            addonLabel.Enabled = addonList.Enabled = mainGroupBox.Enabled = false;
            dirNotSetLabel.Visible = true;
            Messenger.MessageBox($"The following requirements are not set:\n{missingList}\nPlease set them in Settings",
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PopulateAddonList()
        {
            string csgoDir = SettingsManager.LoadSettings().csgo_install_dir;
            string addonsDir = Path.Combine(csgoDir, "content", "csgo_addons");

            if (!Directory.Exists(addonsDir))
            {
                Messenger.MessageBox("csgo_addons folder not found", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var addonFolders = Directory.GetDirectories(addonsDir)
                .Where(folder => !folder.EndsWith("addon_template") && !folder.EndsWith("workshop_items"));

            foreach (var folder in addonFolders)
            {
                addonList.Items.Add(Path.GetFileName(folder));
            }
        }

        private void HandleThreadCount()
        {
            int threadCount = Environment.ProcessorCount;
            cpuThreadCount.Maximum = threadCount;

            if (threadCount > 2) cpuThreadCount.Value = 4;
            else cpuThreadCount.Value = 2;

            availableCpuThreadLabel.Text += threadCount;
        }

        private void SetDefaultCompileOptions()
        {
            if (!lightmapGenerate.Checked)
            {
                lightmapGenDisabledLabel.Visible = true;
            }

            compilePresetList.SelectedItem = "Full";
        }

        private void compilePresetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (compilePresetList.SelectedItem.ToString())
            {
                case "Fast":
                    SetFastCompileOptions();
                    break;
                case "Full":
                    SetFullCompileOptions();
                    break;
                case "Final":
                    SetFinalCompileOptions();
                    break;
            }
        }

        private void SetFastCompileOptions()
        {
            lightmapGenerate.Checked = buildVis.Checked = bakeReverb.Checked = bakePaths.Checked = false;
            buildPhysics.Checked = buildNav.Checked = true;
        }

        private void SetFullCompileOptions()
        {
            lightmapGenerate.Checked = buildPhysics.Checked = buildVis.Checked = buildNav.Checked =
                bakeReverb.Checked = bakePaths.Checked = true;
            lightmapResList.SelectedItem = "1024";
            lightmapQualityList.SelectedItem = "Standard";
            lightmapCompression.Checked = lightmapNoiseRemoval.Checked = true;
            saudioThreads.Value = 4;
        }

        private void SetFinalCompileOptions()
        {
            lightmapGenerate.Checked = buildPhysics.Checked = buildVis.Checked = buildNav.Checked =
                bakeReverb.Checked = bakePaths.Checked = true;
            lightmapResList.SelectedItem = "2048";
            lightmapQualityList.SelectedItem = "Final";
            lightmapCompression.Checked = lightmapNoiseRemoval.Checked = true;
            saudioThreads.Value = 4;
        }

        private void lightmapGenerate_CheckedChanged(object sender, EventArgs e)
        {
            lightmapGenDisabledLabel.Visible = !lightmapGenerate.Checked;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Open GitHub readme link in browser
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            if (addonList.SelectedItem == null)
            {
                Messenger.MessageBox("No addon selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mapNameList.SelectedItem == null)
            {
                Messenger.MessageBox("No map selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string compileOptions = GetCompileOptions();
            new CompileForm(compileOptions).ShowDialog();
        }

        private string GetCompileOptions()
        {
            return $"{addonList.SelectedItem},{mapNameList.SelectedItem},{cpuThreadCount.Value}," +
                   $"{lightmapGenerate.Checked},{lightmapResList.SelectedItem},{lightmapQualityList.SelectedItem}," +
                   $"{lightmapCompression.Checked},{lightmapNoiseRemoval.Checked},{lightmapDisableCalc.Checked}," +
                   $"{buildPhysics.Checked},{buildVis.Checked},{buildNav.Checked}," +
                   $"{bakeReverb.Checked},{bakePaths.Checked},{saudioThreads.Value}";
        }

        private void addonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string csgoDir = SettingsManager.LoadSettings().csgo_install_dir;
            string addonName = addonList.SelectedItem.ToString();
            string mapDir = Path.Combine(csgoDir, "content", "csgo_addons", addonName, "maps");

            if (!Directory.Exists(mapDir))
            {
                Messenger.MessageBox("maps folder not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopulateMapList(mapDir);
        }

        private void PopulateMapList(string mapDir)
        {
            string[] maps = Directory.GetFiles(mapDir, "*.vmap");
            mapNameList.Items.Clear();
            foreach (var map in maps)
            {
                mapNameList.Items.Add(Path.GetFileName(map));
            }
        }
    }
}