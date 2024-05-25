using Source2CPULightmap.Classes.Darkmode;
using Source2CPULightmap.Classes.Settings;
using System.Diagnostics;

namespace Source2CPULightmap
{
    public partial class CompileForm : Form
    {
        private DarkModeCS DM = null;
        private Process process;
        private string compileOptions;

        public CompileForm(string _compileOptions)
        {
            compileOptions = _compileOptions;
            InitializeComponent();
            DM = new DarkModeCS(this);
        }

        private void CompileForm_Load(object sender, EventArgs e)
        {
            string csgoDir = SettingsManager.LoadSettings().csgo_install_dir;
            string compilerPath = Path.Combine(csgoDir, "game", "bin", "win64", "resourcecompiler.exe");

            string[] options = compileOptions.Split(',');

            string addonName = options[0];
            string mapName = options[1];
            string mapPath = Path.Combine(csgoDir, "content", "csgo_addons", addonName, "maps", mapName);

            // TODO: Implement how many CPU threads can be used
            // string cpu_threads = options[2];

            string arguments = BuildArguments(csgoDir, mapPath, options);

            AppendText($"Running command: {Environment.NewLine}\"{compilerPath}\" {arguments}{Environment.NewLine}");

            // Run the command asynchronously when the form loads
            Task.Run(() => RunCommand(compilerPath, arguments));
        }

        private string BuildArguments(string csgoDir, string mapPath, string[] options)
        {
            string arguments =
                $"-lightmapcpu -threads 4 -fshallow -maxtextureres 256 -dxlevel 110 -quiet -unbufferedio -i \"{mapPath}\" -noassert -world";

            if (options[3].ToLower() == "true")
            {
                arguments +=
                    $" -bakelighting -lightmapMaxResolution {options[4]} -lightmapDoWeld -lightmapVRadQuality {(options[5] == "Fast" ? "0" : (options[5] == "Standard" ? "1" : "2"))}";

                if (options[7].ToLower() == "false")
                {
                    arguments += " -lightmapDisableFiltering";
                }

                arguments += " -lightmapLocalCompile";

                if (options[6].ToLower() == "false")
                {
                    arguments += " -lightmapCompressionDisabled";
                }

                if (options[8].ToLower() == "true")
                {
                    arguments += " -disableLightingCalculations";
                }
            }
            else if (options[8].ToLower() == "true")
            {
                arguments += " -nolightmaps";
            }

            if (options[9].ToLower() == "true") arguments += " -phys";
            if (options[10].ToLower() == "true") arguments += " -vis";
            if (options[11].ToLower() == "true") arguments += " -nav";
            if (options[12].ToLower() == "true") arguments += $" -sareverb -sareverb_threads {options[14]}";
            if (options[13].ToLower() == "true") arguments += $" -sapaths -sareverb_threads {options[14]}";

            arguments += $" -retail -breakpad -nop4 -outroot \"{Path.Combine(csgoDir, "game")}\"";

            return arguments;
        }

        private async Task RunCommand(string compilerPath, string arguments)
        {
            if (!File.Exists(compilerPath))
            {
                AppendText("resourcecompiler.exe not found at the specified location." + Environment.NewLine);
                return;
            }

            try
            {
                process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = compilerPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.OutputDataReceived += (sender, e) => AppendText(e.Data + Environment.NewLine);
                process.ErrorDataReceived += (sender, e) => AppendText("ERROR: " + e.Data + Environment.NewLine);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                AppendText(process.ExitCode == 0
                    ? "Map compiled successfully" + Environment.NewLine
                    : $"Command exited with code {process.ExitCode}." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                AppendText("Exception: " + ex.Message + Environment.NewLine);
            }
            finally
            {
                EnableButtons();
            }
        }

        private void EnableButtons()
        {
            compileDoneButton.Invoke((MethodInvoker)(() => compileDoneButton.Enabled = true));
            compileCancelButton.Invoke((MethodInvoker)(() => compileCancelButton.Enabled = false));
        }

        private void AppendText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendText), text);
                return;
            }

            try
            {
                outputTextbox.AppendText(text);
            }
            catch (InvalidOperationException)
            {
                // Ignore
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (process != null && !process.HasExited)
            {
                try
                {
                    process.Kill();
                    AppendText("Process terminated by user." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    AppendText("Exception while terminating process: " + ex.Message + Environment.NewLine);
                }
            }
        }

        private void compileDoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void compileCancelButton_Click(object sender, EventArgs e)
        {
            if (process != null && !process.HasExited)
            {
                try
                {
                    process.Kill();
                    AppendText("Process terminated by user." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    AppendText("Exception while terminating process: " + ex.Message + Environment.NewLine);
                }
            }

            Close();
        }
    }
}