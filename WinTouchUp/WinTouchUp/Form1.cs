using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace WinTouchUp
{
    public partial class MainForm : Form
    {
        /***************************\
         * P/INVOKES AND OVERRIDES * 
        \***************************/

        // Window dragging

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Blur

        [StructLayout(LayoutKind.Sequential)]
        public struct AccentPolicy
        {
            public int AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowCompositionAttributeData
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(
            IntPtr hwnd,
            ref WindowCompositionAttributeData data
        );

        /********\
         * MAIN * 
        \********/

        // Sprow: I've tried my best to document my methods if they take values using summary blocks here for future developers.
        // Sprow: Well, that is if it's an internal method function. If it's just a WinForms event, there is no need.

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetRegHandles();
            RefreshGeneral();

            EnableBlur();
        }

        private void EnableBlur()
        {
            IntPtr accentPtr = IntPtr.Zero;
            try
            {
                var accent = new AccentPolicy
                {
                    AccentState = 4,
                    GradientColor = unchecked((int)0x9F000000)
                };

                var accentStructSize = Marshal.SizeOf(accent);
                accentPtr = Marshal.AllocHGlobal(accentStructSize);
                Marshal.StructureToPtr(accent, accentPtr, false);

                var data = new WindowCompositionAttributeData
                {
                    Attribute = 19,
                    SizeOfData = accentStructSize,
                    Data = accentPtr
                };

                // Sprow: Again, here we go with a discard to get my code editor to shut up.
                _ = SetWindowCompositionAttribute(this.Handle, ref data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while enabling Acrylic effect: {ex.Message}", "Error");
            }
            finally
            {
                if (accentPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(accentPtr);
                }
            }
        }

        private RegistryKey? overallThemeKey;
        private RegistryKey? explorerThemeKey;
        private RegistryKey? dwmThemeKey;

        internal enum ThemeElement
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

        private void GetRegHandles()
        {
            try
            {
                overallThemeKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
                explorerThemeKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent", true);
                dwmThemeKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\DWM", true);
                return;
            }
            catch (SecurityException)
            {
                MessageBox.Show($"An error occurred while trying to access a key.\n\nWhere? GetRegHandles\nWhat? Access Denied");
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show($"An error occurred while trying to access a key.\n\nWhere? GetRegHandles\nWhat? Not Found");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to access a key.\n\nWhere? GetRegHandles\nWhat? {ex}");
            }
            this.Close();
            return;
        }

        /// <summary>
        /// Takes a boolean and sets any DWord value requested to 0 if false or 1 if true.
        /// </summary>
        /// <param name="RegKey">The object of the registry key to edit</param>
        /// <param name="SubkeyName">The name of the subkey/value that you want to edit</param>
        /// <param name="Condition">The boolean to convert into an int</param>
        private static void RegSetBoolDword(RegistryKey? RegKey, string SubkeyName, bool Condition)
        {
            try
            {
                RegKey?.SetValue(SubkeyName, (Condition ? 0x01 : 0x00), RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to edit a value.\n\nWhere? RegSetBookDword ({SubkeyName})\nWhat? {ex}");
            }
        }

        private void CloseControl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeControl_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutWinTheme AboutWinTheme = new();
            AboutWinTheme.Show();
        }

        private void App_DragTitleBar(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Y <= 24)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // 0xA1: WM_NCLBUTTONDOWN // 0x2: HT_CAPTION
            }
        }

        private static int UserPickColorHex()
        {
            using var picker = new ColorDialog();
            picker.FullOpen = true;

            if (picker.ShowDialog() == DialogResult.OK)
            {
                Color chosenColor = picker.Color;
                int alpha = 255;

                int colorInt = (alpha << 24) | (chosenColor.R << 16) | (chosenColor.G << 8) | chosenColor.B;

                return colorInt;
            }

            return -1;
        }

        /// <summary>
        /// A method to return specific registry value at a provided offset index.
        /// </summary>
        /// <param name="index">The numeric index to retrieve the value</param>
        /// <returns>A numeric color value</returns>
        public string GetAccentPaletteValue(int index)
        {
            try
            {
                byte[]? AccentPalette = explorerThemeKey?.GetValue("AccentPalette") as byte[]
                    ?? throw new Exception("AccentPalette not found.");
                int byteOffset = index * 4;

                byte r = AccentPalette[byteOffset];
                byte g = AccentPalette[byteOffset + 1];
                byte b = AccentPalette[byteOffset + 2];

                return $"#{r:X2}{g:X2}{b:X2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to access a value.\n\nWhere? GetAccentPaletteValue\nWhat? {ex}");
                return "#000000";
            }
        }

        /// <summary>
        /// A method to set a specific index in a specific registry value to an integer of the same type.
        /// </summary>
        /// <param name="index">The index to choose where to set</param>
        /// <param name="value">The value to set the indexed offset to</param>
        private void SetAccentPaletteValue(int index, int value)
        {
            try
            {
                byte[]? AccentPalette = explorerThemeKey?.GetValue("AccentPalette") as byte[]
                    ?? throw new Exception("AccentPalette not found.");
                int byteOffset = index * 4;

                ReadOnlySpan<byte> newValue = [
                    (byte)((value >> 16) & 0xFF),
                    (byte)((value >> 8) & 0xFF),
                    (byte)(value & 0xFF),
                    0xFF
                ];

                newValue.CopyTo(AccentPalette.AsSpan(byteOffset, 4));

                explorerThemeKey?.SetValue("AccentPalette", AccentPalette, RegistryValueKind.Binary);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to edit a value.\n\nWhere? SetAccentPaletteValue\nWhat? {ex}");
            }
        }

        /// <summary>
        /// Sets a specific registry value at an index set via string.
        /// </summary>
        /// <param name="ControlName">The string-value index</param>
        /// <param name="HexCode">The color to set the registry value to</param>
        /// <param name="headless">Determines if a warning messagebox will show or not</param>
        private void HandleColorPickOfId(ThemeElement ControlName, int HexCode, bool headless = false)
        {
            if (!headless)
            {
                DialogResult messageBoxResult = MessageBox.Show("This change cannot be undone. Continue anyway?", "Warning", MessageBoxButtons.YesNo);
                if (messageBoxResult == DialogResult.No) { return; }
            }

            int ABGRHexCode = (int)(
                ((uint)HexCode & 0xFF00FF00) |
                (((uint)HexCode & 0x00FF0000) >> 16) |
                (((uint)HexCode & 0x000000FF) << 16)
            );

            try
            {
                switch (ControlName)
                {
                    case ThemeElement.Accent:
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[1](0xRRGGBBAA)
                        SetAccentPaletteValue(1, HexCode);
                        return;

                    case ThemeElement.Hover:
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[0](0xRRGGBBAA)
                        SetAccentPaletteValue(0, HexCode);
                        return;

                    case ThemeElement.Titlebar:
                        // SOFTWARE\Microsoft\Windows\DWM\AccentColor(0xRRGGBBAA)
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentColorMenu(0xRRGGBBAA)
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[2](0xRRGGBBAA)
                        dwmThemeKey?.SetValue("AccentColor", ABGRHexCode, RegistryValueKind.DWord);
                        dwmThemeKey?.SetValue("AccentColorMenu", ABGRHexCode, RegistryValueKind.DWord);
                        SetAccentPaletteValue(2, HexCode);
                        return;

                    case ThemeElement.Inactive:
                        // SOFTWARE\Microsoft\Windows\DWM\AccentColorInactive(0xRRGGBBAA)
                        dwmThemeKey?.SetValue("AccentColorInactive", ABGRHexCode, RegistryValueKind.DWord);
                        return;

                    case ThemeElement.SettingsIcon:
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[3](0xRRGGBBAA)
                        SetAccentPaletteValue(3, HexCode);
                        return;

                    case ThemeElement.Start:
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[4](0xRRGGBBAA)
                        SetAccentPaletteValue(4, HexCode);
                        return;

                    case ThemeElement.TaskbarFront:
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[5](0xRRGGBBAA)
                        SetAccentPaletteValue(5, HexCode);
                        return;

                    case ThemeElement.TaskbarBack:
                        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[6](0xRRGGBBAA)
                        SetAccentPaletteValue(6, HexCode);
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to edit a value.\n\nWhere? HandleColorPickOfId\nWhat? {ex}");
            }
        }

        private void AppContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppContainer.SelectedIndex == 0)
            {
                RefreshGeneral();
            }
            else if (AppContainer.SelectedIndex == 1)
            {
                RefreshColors();
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show($"An unexpected error occurred while trying to reload a process.\n\nWhere? ReloadButton_Click (explorer)\nWhat? {ex}");
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
                MessageBox.Show("Please re-run the application with administrative rights to reload window borders.", "Admin Rights Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to reload a process.\n\nWhere? ReloadButton_Click (dwm)\nWhat? {ex}");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                overallThemeKey?.Close();
                dwmThemeKey?.Close();
                explorerThemeKey?.Close();
            }
            catch (Exception) { }
        }

        /***************\
         * GENERAL TAB * 
        \***************/

        private void RefreshGeneral()
        {
            int LightEnabled;
            int ColorPrevalenceEnabled;
            int BorderColorEnabled;
            int TransparencyEnabled;
            try
            {
                // Sprow: If anyone wants to clean this up, please PR with the proposed changes.
                // Sprow: However, it has to be null-safe and have 0 nullability warnings/errors.
                // Sprow: This message will eventually be removed when I have the time to do it myself.

                object? ObjLightEnabled = overallThemeKey?.GetValue("AppsUseLightTheme");

                object? ObjColorPrevalenceEnabled = overallThemeKey?.GetValue("ColorPrevalence");
                object? ObjBorderColorEnabled = dwmThemeKey?.GetValue("ColorPrevalence");
                object? ObjTransparencyEnabled = overallThemeKey?.GetValue("EnableTransparency");

                if (ObjLightEnabled is null || ObjColorPrevalenceEnabled is null || ObjBorderColorEnabled is null || ObjTransparencyEnabled is null)
                {
                    throw new Exception("No registry key.");
                }

                LightEnabled = (int)ObjLightEnabled;

                ColorPrevalenceEnabled = (int)ObjColorPrevalenceEnabled;
                BorderColorEnabled = (int)ObjBorderColorEnabled;
                TransparencyEnabled = (int)ObjTransparencyEnabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to access a value.\n\nWhere? RefreshGeneral\nWhat? {ex}");
                return;
            }

            if (LightEnabled == 1)
            {
                LightThemeEnable.Checked = true;
            }
            else
            {
                DarkThemeEnable.Checked = true;
            }

            ColorPrevalenceToggle.Checked = ColorPrevalenceEnabled == 1;
            BorderColorToggle.Checked = BorderColorEnabled == 1;
            TransparencyEffectToggle.Checked = TransparencyEnabled == 1;
        }

        private void LightThemeEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (LightThemeEnable.Checked)
            {
                try
                {
                    overallThemeKey?.SetValue("AppsUseLightTheme", 0x01, RegistryValueKind.DWord);
                    overallThemeKey?.SetValue("SystemUsesLightTheme", 0x01, RegistryValueKind.DWord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while trying to set a value.\n\nWhere? LightThemeEnabled_CheckedChanged\nWhat? {ex}");
                }
            }
        }

        private void DarkThemeEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (DarkThemeEnable.Checked)
            {
                try
                {
                    overallThemeKey?.SetValue("AppsUseLightTheme", 0x00, RegistryValueKind.DWord);
                    overallThemeKey?.SetValue("SystemUsesLightTheme", 0x00, RegistryValueKind.DWord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while trying to set a value.\n\nWhere? DarkThemeEnabled_CheckedChanged\nWhat? {ex}");
                }
            }
        }

        private void ColorPrevalenceToggle_CheckedChanged(object sender, EventArgs e)
        {
            // Sprow: ColorPrevalence in this case is taskbar, start menu, and other similar toggles.
            RegSetBoolDword(overallThemeKey, "ColorPrevalence", ColorPrevalenceToggle.Checked);
        }

        private void BorderColorToggle_CheckedChanged(object sender, EventArgs e)
        {
            // Sprow: Then, ColorPrevalence here is window borders.
            RegSetBoolDword(dwmThemeKey, "ColorPrevalence", BorderColorToggle.Checked);
        }

        private void TransparencyEffectToggle_CheckedChanged(object sender, EventArgs e)
        {
            RegSetBoolDword(overallThemeKey, "EnableTransparency", TransparencyEffectToggle.Checked);
        }

        /**************\
         * COLORS TAB * 
        \**************/

        // overallThemeKey  = 0
        // explorerThemeKey = 1
        // dwmThemeKey      = 2

        // Sprow: If SubKey is a number (as a string, it will be cast later),
        // Sprow: that means it is part of the Explorer Accent key and will be managed by another function

        private readonly Dictionary<string, (int KeyIndex, string SubKey)> AdvancedElements = new()
        {
            { "Accent",       (1, "1") },
            { "Hover",        (1, "0") },
            { "Titlebar",     (2, "AccentColor") },
            { "Inactive",     (2, "AccentColorInactive") },
            { "SettingsIcon", (1, "3") },
            { "Start",        (1, "4") },
            { "TaskbarFront", (1, "5") },
            { "TaskbarBack",  (1, "6") }
        };

        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[1](0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[0](0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\DWM\AccentColor(0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\DWM\AccentColorInactive(0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[3](0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[4](0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[5](0xRRGGBBAA)
        // SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Accent\AccentPalette[6](0xRRGGBBAA)

        private void RefreshColors()
        {
            try
            {
                foreach (var (element, location) in AdvancedElements)
                {
                    string hexColor = "#000000";
                    if (location.KeyIndex == 1)
                    {
                        hexColor = GetAccentPaletteValue(int.Parse(location.SubKey));
                    }
                    else if (location.KeyIndex == 2)
                    {
                        int color_abgr = (int)dwmThemeKey?.GetValue(location.SubKey)!;
                        hexColor = $"#{(color_abgr >> 16) & 0xFF:X2}{(color_abgr >> 8) & 0xFF:X2}{color_abgr & 0xFF:X2}";
                    }

                    AdvancedControlsBox.Controls.OfType<Label>().FirstOrDefault(t => t.Name == element + "HexCode")!.Text = hexColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while trying to access a value.\n\nWhere? RefreshColors\nWhat? {ex}\n\nThis is not the program's fault. DO NOT OPEN AN ISSUE OR COMPLAIN. Please email developer for more info.");
            }
        }

        private void ThemeColorPick_Click(object sender, EventArgs e)
        {
            int hexValue = UserPickColorHex();

            if (hexValue == -1) { return; }

            // Sprow: Then we start the long, boring and extremely tedious conversion of ARGB -> CIELCH (we discard the alpha and just leave it in RAM for future purposes)
            byte baseA = (byte)((hexValue >> 24) & 0xFF);
            byte baseR = (byte)((hexValue >> 16) & 0xFF);
            byte baseG = (byte)((hexValue >> 8) & 0xFF);
            byte baseB = (byte)(hexValue & 0xFF);

            double ToLinear(double c) => (c > 0.04045) ? Math.Pow((c + 0.055) / 1.055, 2.4) : c / 12.92;
            double ToXyzComp(double v) => (v > 0.008856) ? Math.Pow(v, 1.0 / 3.0) : (7.787 * v) + (16.0 / 116.0);
            double FromXyzComp(double v) => (Math.Pow(v, 3) > 0.008856) ? Math.Pow(v, 3) : (v - 16.0 / 116.0) / 7.787;
            double ToRgbComp(double c) => (c > 0.0031308) ? 1.055 * Math.Pow(c, 1.0 / 2.4) - 0.055 : 12.92 * c;

            double rN = ToLinear(baseR / 255.0);
            double gN = ToLinear(baseG / 255.0);
            double bN = ToLinear(baseB / 255.0);

            double x = (rN * 0.4124 + gN * 0.3576 + bN * 0.1805) * 100;
            double y = (rN * 0.2126 + gN * 0.7152 + bN * 0.0722) * 100;
            double z = (rN * 0.0193 + gN * 0.1192 + bN * 0.9505) * 100;

            double xR = ToXyzComp(x / 95.047);
            double yR = ToXyzComp(y / 100.000);
            double zR = ToXyzComp(z / 108.883);

            double cieL = (116.0 * yR) - 16.0;
            double cieA = 500.0 * (xR - yR);
            double cieB = 200.0 * (yR - zR);

            double cieC = Math.Sqrt(cieA * cieA + cieB * cieB);
            double cieH = Math.Atan2(cieB, cieA) * (180.0 / Math.PI);
            if (cieH < 0) cieH += 360.0;

            var paletteTargets = new[]
            {
                new { Element = ThemeElement.Accent,       OffsetL = 18.5,  ScaleC = 0.85 },
                new { Element = ThemeElement.Hover,        OffsetL = 12.0,  ScaleC = 0.92 },
                new { Element = ThemeElement.Titlebar,     OffsetL = 6.0,   ScaleC = 0.98 },
                new { Element = ThemeElement.Inactive,     OffsetL = -10.0, ScaleC = 0.78 },
                new { Element = ThemeElement.SettingsIcon, OffsetL = 0.0,   ScaleC = 1.00 },
                new { Element = ThemeElement.Start,        OffsetL = -6.5,  ScaleC = 0.95 },
                new { Element = ThemeElement.TaskbarFront, OffsetL = -11.5, ScaleC = 0.88 },
                new { Element = ThemeElement.TaskbarBack,  OffsetL = -18.5, ScaleC = 0.78 }
            };

            foreach (var target in paletteTargets)
            {
                double targetL = Math.Max(0, Math.Min(100, cieL + target.OffsetL));
                double targetC = cieC * target.ScaleC;
                double targetH = cieH;

                double hRad = targetH * (Math.PI / 180.0);
                double tA = Math.Cos(hRad) * targetC;
                double tB = Math.Sin(hRad) * targetC;

                double tyY = (targetL + 16.0) / 116.0;
                double txX = tA / 500.0 + tyY;
                double tzZ = tyY - tB / 200.0;

                txX = FromXyzComp(txX);
                tyY = FromXyzComp(tyY);
                tzZ = FromXyzComp(tzZ);

                double tx = txX * 95.047 / 100.0;
                double ty = tyY * 100.000 / 100.0;
                double tz = tzZ * 108.883 / 100.0;

                double trR = tx * 3.2406 + ty * -1.5372 + tz * -0.4986;
                double tgG = tx * -0.9689 + ty * 1.8758 + tz * 0.0415;
                double tbB = tx * 0.0557 + ty * -0.2040 + tz * 1.0570;

                trR = ToRgbComp(trR);
                tgG = ToRgbComp(tgG);
                tbB = ToRgbComp(tbB);

                int finalR = Math.Max(0, Math.Min(255, (int)Math.Round(trR * 255.0)));
                int finalG = Math.Max(0, Math.Min(255, (int)Math.Round(tgG * 255.0)));
                int finalB = Math.Max(0, Math.Min(255, (int)Math.Round(tbB * 255.0)));

                int hexColorInt = (baseA << 24) | (finalR << 16) | (finalG << 8) | finalB;

                HandleColorPickOfId(target.Element, hexColorInt, true);
            }

            RefreshColors();
        }

        private void AdvancedViewButton_Click(object sender, EventArgs e)
        {
            AdvancedControlsBox.Visible = !AdvancedControlsBox.Visible;
        }

        private void PickButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string elementName = clickedButton.Name.Replace("Pick", "");

            int hexColorInt = UserPickColorHex();
            if (hexColorInt == -1) { return; }

            string hexColor = $"#{(hexColorInt & 0xFFFFFF):X6}";

            // Sprow: IMPORTANT: IT WILL NOT PROPOGATE IF NAMES ARE CHANGED RECKLESSLY
            var label = AdvancedControlsBox.Controls.OfType<Label>().FirstOrDefault(t => t.Name == elementName + "HexCode");
            label?.Text = hexColor;

            if (Enum.TryParse(elementName, out ThemeElement parsedElement))
            {
                HandleColorPickOfId(parsedElement, hexColorInt);
            }
            else
            {
                MessageBox.Show($"An unexpected error occurred while trying to access a value.\n\nWhere? RefreshGeneral\nWhat? Could not convert str -> enum");
                return;
            }
        }
    }
}