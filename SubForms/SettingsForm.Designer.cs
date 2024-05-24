namespace Source2CPULightmap
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            csgoDirLabel = new Label();
            csgoDirTextbox = new TextBox();
            settingsApplyButton = new Button();
            settingsCancelButton = new Button();
            csgoDirBrowseButton = new Button();
            SuspendLayout();
            // 
            // csgoDirLabel
            // 
            csgoDirLabel.AutoSize = true;
            csgoDirLabel.Location = new Point(12, 9);
            csgoDirLabel.MaximumSize = new Size(460, 0);
            csgoDirLabel.Name = "csgoDirLabel";
            csgoDirLabel.Size = new Size(175, 15);
            csgoDirLabel.TabIndex = 0;
            csgoDirLabel.Text = "CSGO/CS2 Installation Directory";
            // 
            // csgoDirTextbox
            // 
            csgoDirTextbox.Location = new Point(12, 27);
            csgoDirTextbox.Name = "csgoDirTextbox";
            csgoDirTextbox.PlaceholderText = "(e.g. C:\\Program Files (x86)\\Steam\\steamapps\\common\\Counter Strike Global Offensive)";
            csgoDirTextbox.Size = new Size(310, 23);
            csgoDirTextbox.TabIndex = 1;
            // 
            // settingsApplyButton
            // 
            settingsApplyButton.Location = new Point(328, 56);
            settingsApplyButton.Name = "settingsApplyButton";
            settingsApplyButton.Size = new Size(75, 23);
            settingsApplyButton.TabIndex = 2;
            settingsApplyButton.Text = "Apply";
            settingsApplyButton.UseVisualStyleBackColor = true;
            settingsApplyButton.Click += settingsApplyButton_Click;
            // 
            // settingsCancelButton
            // 
            settingsCancelButton.Location = new Point(247, 56);
            settingsCancelButton.Name = "settingsCancelButton";
            settingsCancelButton.Size = new Size(75, 23);
            settingsCancelButton.TabIndex = 3;
            settingsCancelButton.Text = "Cancel";
            settingsCancelButton.UseVisualStyleBackColor = true;
            settingsCancelButton.Click += settingsCancelButton_Click;
            // 
            // csgoDirBrowseButton
            // 
            csgoDirBrowseButton.Location = new Point(328, 27);
            csgoDirBrowseButton.Name = "csgoDirBrowseButton";
            csgoDirBrowseButton.Size = new Size(75, 23);
            csgoDirBrowseButton.TabIndex = 4;
            csgoDirBrowseButton.Text = "Browse";
            csgoDirBrowseButton.UseVisualStyleBackColor = true;
            csgoDirBrowseButton.Click += csgoDirBrowseButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 87);
            Controls.Add(csgoDirBrowseButton);
            Controls.Add(settingsCancelButton);
            Controls.Add(settingsApplyButton);
            Controls.Add(csgoDirTextbox);
            Controls.Add(csgoDirLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(431, 126);
            MinimumSize = new Size(431, 126);
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label csgoDirLabel;
        private TextBox csgoDirTextbox;
        private Button settingsApplyButton;
        private Button settingsCancelButton;
        private Button csgoDirBrowseButton;
    }
}