namespace Source2CPULightmap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string missingList = SettingsManager.CheckSettings();
            if (!string.IsNullOrEmpty(missingList))
            {
                addonLabel.Enabled = false;
                addonList.Enabled = false;
                dirNotSetLabel.Visible = true;
                mainGroupBox.Enabled = false;
                MessageBox.Show(
                    $"The following requirements are not set:\n{missingList}\nPlease set them in Settings",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string csgoDir = SettingsManager.LoadSettings().csgo_install_dir;
                // get folders in csgoDir + content\csgo_addons
                string addonsDir = Path.Combine(csgoDir, "content", "csgo_addons");
                if (!Directory.Exists(addonsDir))
                {
                    MessageBox.Show("csgo_addons folder not found", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                string[] csgoAddonsFolders = Directory.GetDirectories(addonsDir);

                // exclude "addon_template" and "workshop_items" folders
                csgoAddonsFolders = csgoAddonsFolders.Where(folder =>
                    !folder.EndsWith("addon_template") && !folder.EndsWith("workshop_items")).ToArray();

                // set the folders as options in the combobox
                foreach (string folder in csgoAddonsFolders)
                {
                    addonList.Items.Add(Path.GetFileName(folder));
                }

                if (!lightmapGenerate.Checked)
                {
                    lightmapGenDisabledLabel.Visible = true;
                }

                compilePresetList.SelectedItem = "Full";
            }
        }

        private void compilePresetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (compilePresetList.SelectedItem.ToString() == "Fast")
            {
                FastCompileSelected();
            }
            else if (compilePresetList.SelectedItem.ToString() == "Full")
            {
                FullCompileSelected();
            }
            else if (compilePresetList.SelectedItem.ToString() == "Final")
            {
                FinalCompileSelected();
            }
        }

        private void FastCompileSelected()
        {
            lightmapGenerate.Checked = false;
            buildPhysics.Checked = true;
            buildVis.Checked = false;
            buildNav.Checked = true;
            bakeReverb.Checked = false;
            bakePaths.Checked = false;
        }

        private void FullCompileSelected()
        {
            lightmapGenerate.Checked = true;
            lightmapResList.SelectedItem = "1024";
            lightmapQualityList.SelectedItem = "Standard";
            lightmapCompression.Checked = true;
            lightmapNoiseRemoval.Checked = true;
            buildPhysics.Checked = true;
            buildVis.Checked = true;
            buildNav.Checked = true;
            bakeReverb.Checked = true;
            bakePaths.Checked = true;
            saudioThreads.Value = 4;
        }

        private void FinalCompileSelected()
        {
            lightmapGenerate.Checked = true;
            lightmapResList.SelectedItem = "2048";
            lightmapQualityList.SelectedItem = "Final";
            lightmapCompression.Checked = true;
            lightmapNoiseRemoval.Checked = true;
            buildPhysics.Checked = true;
            buildVis.Checked = true;
            buildNav.Checked = true;
            bakeReverb.Checked = true;
            bakePaths.Checked = true;
            saudioThreads.Value = 4;
        }

        private void lightmapGenerate_CheckedChanged(object sender, EventArgs e)
        {
            lightmapGenDisabledLabel.Visible = !lightmapGenerate.Checked;
        }

        private void compileButton_Click(object sender, EventArgs e)
        {
            // Check if all required fields are set (map and addon)
            if (addonList.SelectedItem == null)
            {
                MessageBox.Show("No addon selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mapNameList.SelectedItem == null)
            {
                MessageBox.Show("No map selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string compile_options =
                $"{addonList.SelectedItem},{mapNameList.SelectedItem},3,{lightmapGenerate.Checked},{lightmapResList.SelectedItem},{lightmapQualityList.SelectedItem},{lightmapCompression.Checked},{lightmapNoiseRemoval.Checked},{lightmapDisableCalc.Checked},{buildPhysics.Checked},{buildVis.Checked},{buildNav.Checked},{bakeReverb.Checked},{bakePaths.Checked},{saudioThreads.Value}";
            CompileForm compileForm = new CompileForm(compile_options);
            compileForm.ShowDialog();
        }

        private void addonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSettings settings = SettingsManager.LoadSettings();
            string csgoDir = settings.csgo_install_dir;
            string mapDir = Path.Combine(csgoDir, "content", "csgo_addons", addonList.SelectedItem.ToString(), "maps");
            if (!Directory.Exists(mapDir))
            {
                MessageBox.Show("maps folder not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] maps = Directory.GetFiles(mapDir, "*.vmap");
            mapNameList.SelectedItem = null;
            mapNameList.Items.Clear();
            foreach (string map in maps)
            {
                mapNameList.Items.Add(Path.GetFileName(map));
            }
        }
    }
}