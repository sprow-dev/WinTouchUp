using System.Diagnostics;

using WinTouchUp.Helpers;
using WinTouchUp.Helpers.Exceptions;

namespace WinTouchUp
{
    public partial class MainForm : Form
    {
        // Sprow: This is our safe RegMan class. Reduces checks outside of the class and improves DRY compliance.
        private readonly RegMan reg = new(new() {
            { "overallTheme", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize" },
            { "explorerTheme", "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Accent" },
            { "dwmKey", "SOFTWARE\\Microsoft\\Windows\\DWM" },
        });

        // Simplified init from boilerplate
        public MainForm() => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGeneral();
            EnableBlur();
        }

        private enum ThemeElement
        {
            Accent,
            Hover,
            Titlebar,
            Inactive,
            SettingsIcon,
            Start,
            TaskbarFront,
            TaskbarBack
        }

        private void AppContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppContainer.SelectedIndex == 0) RefreshGeneral();
            else if (AppContainer.SelectedIndex == 1) RefreshColors();
        }

        /// <summary>
        /// Reloads themes forcefully by restarting DWM and Explorer. !!! DANGEROUS !!!
        /// </summary>
        private void ReloadButton_Click(object sender, EventArgs e)
        {
            DialogResult warn = MessageBox.Show("Your screen WILL flicker.\nRarely, you may also see: Screen may black out and you will have to restart your system.", "Warning", MessageBoxButtons.YesNo)
            if (warn == DialogResult.No) return;
            
            try
            {
                Process[] explorerProcesses = Process.GetProcessesByName("explorer");
                foreach (Process proc in explorerProcesses)
                {
                    proc.Kill();
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                var exi = new RecoverableException($"attempting to restart explorer.exe",
                    "ProcessKill",
                    $"{ex.Message}",
                    "ReloadButton_Click",
                    false);
                exi.Show();

                return;
            }

            try
            {
                Process[] dwmProcesses = Process.GetProcessesByName("dwm");
                foreach (Process proc in dwmProcesses)
                {
                    proc.Kill();
                    proc.WaitForExit();
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                var ex = new RecoverableException($"attempting to restart dwm.exe",
                    "ProcessKill",
                    "You have not run this application with administrative rights. Please run it again with elevated permissions or reboot your system.",
                    "ReloadButton_Click",
                    true);
                ex.Show();
            }
            catch (Exception ex)
            {
                var exi = new RecoverableException($"attempting to restart dwm.exe",
                     "ProcessKill",
                     $"{ex.Message}",
                     "ReloadButton_Click",
                     false);
                exi.Show();

                return;
            }
        }
    }
}