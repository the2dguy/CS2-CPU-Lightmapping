namespace Source2CPULightmap
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenuStrip = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            mainGroupBox = new GroupBox();
            cpuThreadGroupbox = new GroupBox();
            availableCpuThreadLabel = new Label();
            cpuThreadCount = new NumericUpDown();
            useCPUThreadsLabel = new Label();
            mapNameLabel = new Label();
            mapNameList = new ComboBox();
            compilePresetListLabel = new Label();
            compilePresetList = new ComboBox();
            compileButton = new Button();
            steamAudioGroupBox = new GroupBox();
            saudioThreadRecomLabel = new Label();
            steamAudioThreadsLabel = new Label();
            saudioThreads = new NumericUpDown();
            bakePaths = new CheckBox();
            bakeReverb = new CheckBox();
            navGroupBox = new GroupBox();
            buildNav = new CheckBox();
            visibilityGroupBox = new GroupBox();
            buildVis = new CheckBox();
            physicsGroupBox = new GroupBox();
            buildPhysics = new CheckBox();
            bakedLightningGroupBox = new GroupBox();
            lightmapGenDisabledLabel = new Label();
            lightmapCompression = new CheckBox();
            lightmapDisableCalc = new CheckBox();
            lightmapNoiseRemoval = new CheckBox();
            lightmapQualityList = new ComboBox();
            lightmapQualityLabel = new Label();
            lightmapResList = new ComboBox();
            lightmapResLabel = new Label();
            lightmapGenerate = new CheckBox();
            addonLabel = new Label();
            addonList = new ComboBox();
            dirNotSetLabel = new Label();
            mainMenuStrip.SuspendLayout();
            mainGroupBox.SuspendLayout();
            cpuThreadGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cpuThreadCount).BeginInit();
            steamAudioGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)saudioThreads).BeginInit();
            navGroupBox.SuspendLayout();
            visibilityGroupBox.SuspendLayout();
            physicsGroupBox.SuspendLayout();
            bakedLightningGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, helpToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.RenderMode = ToolStripRenderMode.System;
            mainMenuStrip.Size = new Size(485, 24);
            mainMenuStrip.TabIndex = 0;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // mainGroupBox
            // 
            mainGroupBox.Controls.Add(cpuThreadGroupbox);
            mainGroupBox.Controls.Add(mapNameLabel);
            mainGroupBox.Controls.Add(mapNameList);
            mainGroupBox.Controls.Add(compilePresetListLabel);
            mainGroupBox.Controls.Add(compilePresetList);
            mainGroupBox.Controls.Add(compileButton);
            mainGroupBox.Controls.Add(steamAudioGroupBox);
            mainGroupBox.Controls.Add(navGroupBox);
            mainGroupBox.Controls.Add(visibilityGroupBox);
            mainGroupBox.Controls.Add(physicsGroupBox);
            mainGroupBox.Controls.Add(bakedLightningGroupBox);
            mainGroupBox.Location = new Point(12, 61);
            mainGroupBox.Name = "mainGroupBox";
            mainGroupBox.Size = new Size(461, 469);
            mainGroupBox.TabIndex = 1;
            mainGroupBox.TabStop = false;
            // 
            // cpuThreadGroupbox
            // 
            cpuThreadGroupbox.Controls.Add(availableCpuThreadLabel);
            cpuThreadGroupbox.Controls.Add(cpuThreadCount);
            cpuThreadGroupbox.Controls.Add(useCPUThreadsLabel);
            cpuThreadGroupbox.Location = new Point(255, 18);
            cpuThreadGroupbox.Name = "cpuThreadGroupbox";
            cpuThreadGroupbox.Size = new Size(200, 61);
            cpuThreadGroupbox.TabIndex = 10;
            cpuThreadGroupbox.TabStop = false;
            cpuThreadGroupbox.Text = "CPU Threads";
            // 
            // availableCpuThreadLabel
            // 
            availableCpuThreadLabel.AutoSize = true;
            availableCpuThreadLabel.Location = new Point(107, 28);
            availableCpuThreadLabel.Name = "availableCpuThreadLabel";
            availableCpuThreadLabel.Size = new Size(61, 15);
            availableCpuThreadLabel.TabIndex = 2;
            availableCpuThreadLabel.Text = "Available: ";
            // 
            // cpuThreadCount
            // 
            cpuThreadCount.Location = new Point(42, 26);
            cpuThreadCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            cpuThreadCount.Name = "cpuThreadCount";
            cpuThreadCount.Size = new Size(57, 23);
            cpuThreadCount.TabIndex = 1;
            cpuThreadCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // useCPUThreadsLabel
            // 
            useCPUThreadsLabel.AutoSize = true;
            useCPUThreadsLabel.Location = new Point(10, 28);
            useCPUThreadsLabel.Name = "useCPUThreadsLabel";
            useCPUThreadsLabel.Size = new Size(26, 15);
            useCPUThreadsLabel.TabIndex = 0;
            useCPUThreadsLabel.Text = "Use";
            // 
            // mapNameLabel
            // 
            mapNameLabel.AutoSize = true;
            mapNameLabel.Location = new Point(12, 25);
            mapNameLabel.Name = "mapNameLabel";
            mapNameLabel.Size = new Size(31, 15);
            mapNameLabel.TabIndex = 9;
            mapNameLabel.Text = "Map";
            // 
            // mapNameList
            // 
            mapNameList.DropDownStyle = ComboBoxStyle.DropDownList;
            mapNameList.FormattingEnabled = true;
            mapNameList.Location = new Point(49, 22);
            mapNameList.Name = "mapNameList";
            mapNameList.Size = new Size(196, 23);
            mapNameList.TabIndex = 8;
            // 
            // compilePresetListLabel
            // 
            compilePresetListLabel.AutoSize = true;
            compilePresetListLabel.Location = new Point(12, 60);
            compilePresetListLabel.Name = "compilePresetListLabel";
            compilePresetListLabel.Size = new Size(87, 15);
            compilePresetListLabel.TabIndex = 7;
            compilePresetListLabel.Text = "Compile preset";
            // 
            // compilePresetList
            // 
            compilePresetList.DropDownStyle = ComboBoxStyle.DropDownList;
            compilePresetList.FormattingEnabled = true;
            compilePresetList.Items.AddRange(new object[] { "Fast", "Full", "Final" });
            compilePresetList.Location = new Point(105, 56);
            compilePresetList.Name = "compilePresetList";
            compilePresetList.Size = new Size(140, 23);
            compilePresetList.TabIndex = 6;
            compilePresetList.SelectedIndexChanged += compilePresetList_SelectedIndexChanged;
            // 
            // compileButton
            // 
            compileButton.Location = new Point(380, 437);
            compileButton.Name = "compileButton";
            compileButton.Size = new Size(75, 23);
            compileButton.TabIndex = 5;
            compileButton.Text = "Compile";
            compileButton.UseVisualStyleBackColor = true;
            compileButton.Click += compileButton_Click;
            // 
            // steamAudioGroupBox
            // 
            steamAudioGroupBox.Controls.Add(saudioThreadRecomLabel);
            steamAudioGroupBox.Controls.Add(steamAudioThreadsLabel);
            steamAudioGroupBox.Controls.Add(saudioThreads);
            steamAudioGroupBox.Controls.Add(bakePaths);
            steamAudioGroupBox.Controls.Add(bakeReverb);
            steamAudioGroupBox.Location = new Point(6, 381);
            steamAudioGroupBox.Name = "steamAudioGroupBox";
            steamAudioGroupBox.Size = new Size(449, 50);
            steamAudioGroupBox.TabIndex = 4;
            steamAudioGroupBox.TabStop = false;
            steamAudioGroupBox.Text = "Steam audio";
            // 
            // saudioThreadRecomLabel
            // 
            saudioThreadRecomLabel.AutoSize = true;
            saudioThreadRecomLabel.Location = new Point(303, 22);
            saudioThreadRecomLabel.Name = "saudioThreadRecomLabel";
            saudioThreadRecomLabel.Size = new Size(102, 15);
            saudioThreadRecomLabel.TabIndex = 3;
            saudioThreadRecomLabel.Text = "(4 recommended)";
            // 
            // steamAudioThreadsLabel
            // 
            steamAudioThreadsLabel.AutoSize = true;
            steamAudioThreadsLabel.Location = new Point(191, 23);
            steamAudioThreadsLabel.Name = "steamAudioThreadsLabel";
            steamAudioThreadsLabel.Size = new Size(48, 15);
            steamAudioThreadsLabel.TabIndex = 0;
            steamAudioThreadsLabel.Text = "Threads";
            // 
            // saudioThreads
            // 
            saudioThreads.Location = new Point(245, 18);
            saudioThreads.Name = "saudioThreads";
            saudioThreads.Size = new Size(52, 23);
            saudioThreads.TabIndex = 2;
            // 
            // bakePaths
            // 
            bakePaths.AutoSize = true;
            bakePaths.Location = new Point(102, 22);
            bakePaths.Name = "bakePaths";
            bakePaths.Size = new Size(83, 19);
            bakePaths.TabIndex = 1;
            bakePaths.Text = "Bake Paths";
            bakePaths.UseVisualStyleBackColor = true;
            // 
            // bakeReverb
            // 
            bakeReverb.AutoSize = true;
            bakeReverb.Location = new Point(6, 22);
            bakeReverb.Name = "bakeReverb";
            bakeReverb.Size = new Size(90, 19);
            bakeReverb.TabIndex = 0;
            bakeReverb.Text = "Bake Reverb";
            bakeReverb.UseVisualStyleBackColor = true;
            // 
            // navGroupBox
            // 
            navGroupBox.Controls.Add(buildNav);
            navGroupBox.Location = new Point(6, 325);
            navGroupBox.Name = "navGroupBox";
            navGroupBox.Size = new Size(449, 50);
            navGroupBox.TabIndex = 3;
            navGroupBox.TabStop = false;
            navGroupBox.Text = "Nav";
            // 
            // buildNav
            // 
            buildNav.AutoSize = true;
            buildNav.Location = new Point(6, 22);
            buildNav.Name = "buildNav";
            buildNav.Size = new Size(75, 19);
            buildNav.TabIndex = 0;
            buildNav.Text = "Build nav";
            buildNav.UseVisualStyleBackColor = true;
            // 
            // visibilityGroupBox
            // 
            visibilityGroupBox.Controls.Add(buildVis);
            visibilityGroupBox.Location = new Point(6, 269);
            visibilityGroupBox.Name = "visibilityGroupBox";
            visibilityGroupBox.Size = new Size(449, 50);
            visibilityGroupBox.TabIndex = 2;
            visibilityGroupBox.TabStop = false;
            visibilityGroupBox.Text = "Visibility";
            // 
            // buildVis
            // 
            buildVis.AutoSize = true;
            buildVis.Location = new Point(6, 22);
            buildVis.Name = "buildVis";
            buildVis.Size = new Size(70, 19);
            buildVis.TabIndex = 0;
            buildVis.Text = "Build vis";
            buildVis.UseVisualStyleBackColor = true;
            // 
            // physicsGroupBox
            // 
            physicsGroupBox.Controls.Add(buildPhysics);
            physicsGroupBox.Location = new Point(6, 213);
            physicsGroupBox.Name = "physicsGroupBox";
            physicsGroupBox.Size = new Size(449, 50);
            physicsGroupBox.TabIndex = 1;
            physicsGroupBox.TabStop = false;
            physicsGroupBox.Text = "Physics";
            // 
            // buildPhysics
            // 
            buildPhysics.AutoSize = true;
            buildPhysics.Location = new Point(6, 22);
            buildPhysics.Name = "buildPhysics";
            buildPhysics.Size = new Size(95, 19);
            buildPhysics.TabIndex = 0;
            buildPhysics.Text = "Build physics";
            buildPhysics.UseVisualStyleBackColor = true;
            // 
            // bakedLightningGroupBox
            // 
            bakedLightningGroupBox.Controls.Add(lightmapGenDisabledLabel);
            bakedLightningGroupBox.Controls.Add(lightmapCompression);
            bakedLightningGroupBox.Controls.Add(lightmapDisableCalc);
            bakedLightningGroupBox.Controls.Add(lightmapNoiseRemoval);
            bakedLightningGroupBox.Controls.Add(lightmapQualityList);
            bakedLightningGroupBox.Controls.Add(lightmapQualityLabel);
            bakedLightningGroupBox.Controls.Add(lightmapResList);
            bakedLightningGroupBox.Controls.Add(lightmapResLabel);
            bakedLightningGroupBox.Controls.Add(lightmapGenerate);
            bakedLightningGroupBox.Location = new Point(6, 85);
            bakedLightningGroupBox.Name = "bakedLightningGroupBox";
            bakedLightningGroupBox.Size = new Size(449, 122);
            bakedLightningGroupBox.TabIndex = 0;
            bakedLightningGroupBox.TabStop = false;
            bakedLightningGroupBox.Text = "Baked Lightning";
            // 
            // lightmapGenDisabledLabel
            // 
            lightmapGenDisabledLabel.AutoSize = true;
            lightmapGenDisabledLabel.ForeColor = Color.Red;
            lightmapGenDisabledLabel.Location = new Point(141, 11);
            lightmapGenDisabledLabel.MaximumSize = new Size(300, 0);
            lightmapGenDisabledLabel.Name = "lightmapGenDisabledLabel";
            lightmapGenDisabledLabel.Size = new Size(268, 30);
            lightmapGenDisabledLabel.TabIndex = 8;
            lightmapGenDisabledLabel.Text = "Warning: the following options won't work when Generate Lightmaps is set to off.";
            lightmapGenDisabledLabel.Visible = false;
            // 
            // lightmapCompression
            // 
            lightmapCompression.AutoSize = true;
            lightmapCompression.Location = new Point(285, 46);
            lightmapCompression.Name = "lightmapCompression";
            lightmapCompression.Size = new Size(96, 19);
            lightmapCompression.TabIndex = 9;
            lightmapCompression.Text = "Compression";
            lightmapCompression.UseVisualStyleBackColor = true;
            // 
            // lightmapDisableCalc
            // 
            lightmapDisableCalc.AutoSize = true;
            lightmapDisableCalc.Location = new Point(6, 98);
            lightmapDisableCalc.Name = "lightmapDisableCalc";
            lightmapDisableCalc.Size = new Size(388, 19);
            lightmapDisableCalc.TabIndex = 8;
            lightmapDisableCalc.Text = "Disable lightning calculations (debug texel density / chart allocation)";
            lightmapDisableCalc.UseVisualStyleBackColor = true;
            // 
            // lightmapNoiseRemoval
            // 
            lightmapNoiseRemoval.AutoSize = true;
            lightmapNoiseRemoval.Location = new Point(6, 73);
            lightmapNoiseRemoval.Name = "lightmapNoiseRemoval";
            lightmapNoiseRemoval.Size = new Size(105, 19);
            lightmapNoiseRemoval.TabIndex = 7;
            lightmapNoiseRemoval.Text = "Noise Removal";
            lightmapNoiseRemoval.UseVisualStyleBackColor = true;
            // 
            // lightmapQualityList
            // 
            lightmapQualityList.DropDownStyle = ComboBoxStyle.DropDownList;
            lightmapQualityList.FormattingEnabled = true;
            lightmapQualityList.Items.AddRange(new object[] { "Fast", "Standard", "Final" });
            lightmapQualityList.Location = new Point(192, 44);
            lightmapQualityList.Name = "lightmapQualityList";
            lightmapQualityList.Size = new Size(80, 23);
            lightmapQualityList.TabIndex = 4;
            // 
            // lightmapQualityLabel
            // 
            lightmapQualityLabel.AutoSize = true;
            lightmapQualityLabel.Location = new Point(141, 47);
            lightmapQualityLabel.Name = "lightmapQualityLabel";
            lightmapQualityLabel.Size = new Size(45, 15);
            lightmapQualityLabel.TabIndex = 3;
            lightmapQualityLabel.Text = "Quality";
            // 
            // lightmapResList
            // 
            lightmapResList.DropDownStyle = ComboBoxStyle.DropDownList;
            lightmapResList.FormattingEnabled = true;
            lightmapResList.Items.AddRange(new object[] { "8192", "4096", "2048", "1024", "512" });
            lightmapResList.Location = new Point(75, 44);
            lightmapResList.Name = "lightmapResList";
            lightmapResList.Size = new Size(60, 23);
            lightmapResList.TabIndex = 2;
            // 
            // lightmapResLabel
            // 
            lightmapResLabel.AutoSize = true;
            lightmapResLabel.Location = new Point(6, 47);
            lightmapResLabel.Name = "lightmapResLabel";
            lightmapResLabel.Size = new Size(63, 15);
            lightmapResLabel.TabIndex = 1;
            lightmapResLabel.Text = "Resolution";
            // 
            // lightmapGenerate
            // 
            lightmapGenerate.AutoSize = true;
            lightmapGenerate.Location = new Point(6, 22);
            lightmapGenerate.Name = "lightmapGenerate";
            lightmapGenerate.Size = new Size(132, 19);
            lightmapGenerate.TabIndex = 0;
            lightmapGenerate.Text = "Generate Lightmaps";
            lightmapGenerate.UseVisualStyleBackColor = true;
            lightmapGenerate.CheckedChanged += lightmapGenerate_CheckedChanged;
            // 
            // addonLabel
            // 
            addonLabel.AutoSize = true;
            addonLabel.Location = new Point(12, 35);
            addonLabel.Name = "addonLabel";
            addonLabel.Size = new Size(43, 15);
            addonLabel.TabIndex = 2;
            addonLabel.Text = "Addon";
            // 
            // addonList
            // 
            addonList.DropDownStyle = ComboBoxStyle.DropDownList;
            addonList.FormattingEnabled = true;
            addonList.Location = new Point(61, 32);
            addonList.Name = "addonList";
            addonList.Size = new Size(196, 23);
            addonList.TabIndex = 3;
            addonList.SelectedIndexChanged += addonList_SelectedIndexChanged;
            // 
            // dirNotSetLabel
            // 
            dirNotSetLabel.AutoSize = true;
            dirNotSetLabel.BackColor = SystemColors.Control;
            dirNotSetLabel.ForeColor = Color.Red;
            dirNotSetLabel.Location = new Point(295, 36);
            dirNotSetLabel.Name = "dirNotSetLabel";
            dirNotSetLabel.Size = new Size(156, 15);
            dirNotSetLabel.TabIndex = 4;
            dirNotSetLabel.Text = "CSGO/CS2 Directory not set!";
            dirNotSetLabel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 542);
            Controls.Add(dirNotSetLabel);
            Controls.Add(addonList);
            Controls.Add(addonLabel);
            Controls.Add(mainGroupBox);
            Controls.Add(mainMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip;
            MaximizeBox = false;
            MaximumSize = new Size(501, 581);
            MinimumSize = new Size(501, 581);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Counter-Strike 2 SDK CPU Based Lightmap Compiler";
            Load += MainForm_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            mainGroupBox.ResumeLayout(false);
            mainGroupBox.PerformLayout();
            cpuThreadGroupbox.ResumeLayout(false);
            cpuThreadGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cpuThreadCount).EndInit();
            steamAudioGroupBox.ResumeLayout(false);
            steamAudioGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)saudioThreads).EndInit();
            navGroupBox.ResumeLayout(false);
            navGroupBox.PerformLayout();
            visibilityGroupBox.ResumeLayout(false);
            visibilityGroupBox.PerformLayout();
            physicsGroupBox.ResumeLayout(false);
            physicsGroupBox.PerformLayout();
            bakedLightningGroupBox.ResumeLayout(false);
            bakedLightningGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private GroupBox mainGroupBox;
        private GroupBox bakedLightningGroupBox;
        private CheckBox lightmapGenerate;
        private ComboBox lightmapQualityList;
        private Label lightmapQualityLabel;
        private ComboBox lightmapResList;
        private Label lightmapResLabel;
        private CheckBox lightmapNoiseRemoval;
        private GroupBox physicsGroupBox;
        private CheckBox buildPhysics;
        private CheckBox lightmapDisableCalc;
        private GroupBox steamAudioGroupBox;
        private CheckBox bakeReverb;
        private GroupBox navGroupBox;
        private CheckBox buildNav;
        private GroupBox visibilityGroupBox;
        private CheckBox buildVis;
        private NumericUpDown saudioThreads;
        private CheckBox bakePaths;
        private Button compileButton;
        private Label steamAudioThreadsLabel;
        private Label addonLabel;
        private ComboBox addonList;
        private Label dirNotSetLabel;
        private CheckBox lightmapCompression;
        private Label compilePresetListLabel;
        private ComboBox compilePresetList;
        private Label lightmapGenDisabledLabel;
        private Label mapNameLabel;
        private ComboBox mapNameList;
        private Label saudioThreadRecomLabel;
        private GroupBox cpuThreadGroupbox;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label availableCpuThreadLabel;
        private NumericUpDown cpuThreadCount;
        private Label useCPUThreadsLabel;
    }
}
