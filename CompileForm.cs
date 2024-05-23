using System.Diagnostics;

namespace Source2CPULightmap
{
    public partial class CompileForm : Form
    {
        public string compile_options;
        private Process process;

        public CompileForm(string _compile_options)
        {
            compile_options = _compile_options;
            InitializeComponent();
        }

        private void CompileForm_Load(object sender, EventArgs e)
        {
            AppSettings settings = SettingsManager.LoadSettings();
            string csgoDir = settings.csgo_install_dir;

            string compiler_path = Path.Combine(csgoDir, "game", "bin", "win64", "resourcecompiler.exe");

            string[] options = compile_options.Split(',');

            string addon_name = options[0];
            string map_name = options[1];

            // string cpu_threads = options[2];

            string map_path = Path.Combine(csgoDir, "content", "csgo_addons", addon_name, "maps", map_name);

            string arguments =
                $"-lightmapcpu -threads 4 -fshallow -maxtextureres 256 -dxlevel 110 -quiet -unbufferedio -i \"{map_path}\" -noassert  -world";

            string generate_lightmap = options[3];
            string lightmap_res = options[4];
            string lightmap_quality = options[5];

            string lightmap_quality_int;

            if (lightmap_quality == "Fast")
            {
                lightmap_quality_int = "0";
            }
            else if (lightmap_quality == "Standard")
            {
                lightmap_quality_int = "1";
            }
            else
            {
                lightmap_quality_int = "2";
            }

            string lightmap_compression = options[6];
            string lightmap_noise_removal = options[7];
            string lightmap_disable_calc = options[8];

            if (generate_lightmap.ToLower() == "true")
            {
                arguments +=
                    $" -bakelighting -lightmapMaxResolution {lightmap_res} -lightmapDoWeld -lightmapVRadQuality {lightmap_quality_int}";

                if (lightmap_noise_removal.ToLower() == "false")
                {
                    arguments += " -lightmapDisableFiltering";
                }

                arguments += " -lightmapLocalCompile";

                if (lightmap_compression.ToLower() == "false")
                {
                    arguments += " -lightmapCompressionDisabled";
                }

                if (lightmap_disable_calc.ToLower() == "true")
                {
                    arguments += " -disableLightingCalculations";
                }
            }
            else if (lightmap_disable_calc.ToLower() == "true")
            {
                arguments += " -nolightmaps";
            }

            string build_physics = options[9];

            if (build_physics.ToLower() == "true")
            {
                arguments += " -phys";
            }

            string build_vis = options[10];

            if (build_vis.ToLower() == "true")
            {
                arguments += " -vis";
            }

            string build_nav = options[11];

            if (build_nav.ToLower() == "true")
            {
                arguments += " -nav";
            }

            string bake_reverb = options[12];
            string bake_paths = options[13];
            string saudio_threads = options[14];

            if (bake_reverb.ToLower() == "true")
            {
                arguments += $" -sareverb -sareverb_threads {saudio_threads}";
            }

            if (bake_paths.ToLower() == "true")
            {
                arguments += $" -sapaths -sareverb_threads {saudio_threads}";
            }

            string outroot = Path.Combine(csgoDir, "game");

            arguments += $" -retail -breakpad -nop4 -outroot \"{outroot}\"";

            AppendText($"Running command: {Environment.NewLine} \"{compiler_path}\" {arguments} {Environment.NewLine}");

            // Run the command asynchronously when the form loads
            Task.Run(() => RunCommand(compiler_path, arguments));
        }

        private async Task RunCommand(string compiler_path, string arguments)
        {
            if (!File.Exists(compiler_path))
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
                        FileName = compiler_path,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (e.Data != null)
                    {
                        // Append the command output to the TextBox
                        AppendText(e.Data + Environment.NewLine);
                    }
                });

                process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
                {
                    if (e.Data != null)
                    {
                        // Append the command error output to the TextBox
                        AppendText("ERROR: " + e.Data + Environment.NewLine);
                    }
                });

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // Wait for the process to exit
                await process.WaitForExitAsync();

                // Check the exit code to determine success or failure
                if (process.ExitCode == 0)
                {
                    AppendText("Map compiled successfully" + Environment.NewLine);
                    compileDoneButton.Invoke((MethodInvoker)delegate { compileDoneButton.Enabled = true; });
                    compileCancelButton.Invoke((MethodInvoker)delegate { compileCancelButton.Enabled = true; });
                }
                else
                {
                    AppendText($"Command exited with code {process.ExitCode}." + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                AppendText("Exception: " + ex.Message + Environment.NewLine);
            }
        }

        private void AppendText(string text)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendText), new object[] { text });
                return;
            }

            outputTextbox.AppendText(text);
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