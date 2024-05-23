namespace Source2CPULightmap
{
    partial class CompileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompileForm));
            outputTextbox = new TextBox();
            compileDoneButton = new Button();
            compileCancelButton = new Button();
            SuspendLayout();
            // 
            // outputTextbox
            // 
            outputTextbox.Location = new Point(12, 12);
            outputTextbox.Multiline = true;
            outputTextbox.Name = "outputTextbox";
            outputTextbox.ReadOnly = true;
            outputTextbox.ScrollBars = ScrollBars.Vertical;
            outputTextbox.Size = new Size(776, 393);
            outputTextbox.TabIndex = 0;
            // 
            // compileDoneButton
            // 
            compileDoneButton.Enabled = false;
            compileDoneButton.Location = new Point(713, 415);
            compileDoneButton.Name = "compileDoneButton";
            compileDoneButton.Size = new Size(75, 23);
            compileDoneButton.TabIndex = 1;
            compileDoneButton.Text = "Done";
            compileDoneButton.UseVisualStyleBackColor = true;
            compileDoneButton.Click += compileDoneButton_Click;
            // 
            // compileCancelButton
            // 
            compileCancelButton.Location = new Point(632, 415);
            compileCancelButton.Name = "compileCancelButton";
            compileCancelButton.Size = new Size(75, 23);
            compileCancelButton.TabIndex = 2;
            compileCancelButton.Text = "Cancel";
            compileCancelButton.UseVisualStyleBackColor = true;
            compileCancelButton.Click += compileCancelButton_Click;
            // 
            // CompileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 448);
            Controls.Add(compileCancelButton);
            Controls.Add(compileDoneButton);
            Controls.Add(outputTextbox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CompileForm";
            RightToLeftLayout = true;
            Text = "Compile";
            Load += CompileForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox outputTextbox;
        private Button compileDoneButton;
        private Button compileCancelButton;
    }
}