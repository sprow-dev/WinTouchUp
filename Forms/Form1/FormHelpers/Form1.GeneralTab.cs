using Microsoft.Win32;

namespace WinTouchUp
{
    partial class MainForm
    {
        /// <summary>
        /// Refreshes the general tab to match new registry values.
        /// </summary>
        private void RefreshGeneral()
        {
            // Sprow: I tell the compiler to shut up with a nullable object
            // Sprow: because we do a null check later aynway. C# compiler can be pessimistic with nullability
            int? LightEnabled = (int?)reg.GetRegistryValue("overallTheme", "AppsUseLightTheme", RegistryValueKind.DWord);

            int? ColorPrevalenceEnabled = (int?)reg.GetRegistryValue("overallTheme", "ColorPrevalence", RegistryValueKind.DWord);
            int? BorderColorEnabled = (int?)reg.GetRegistryValue("dwmKey", "ColorPrevalence", RegistryValueKind.DWord);
            int? TransparencyEnabled = (int?)reg.GetRegistryValue("overallTheme", "EnableTransparency", RegistryValueKind.DWord);

            // Sprow: Aforementioned null check
            if (LightEnabled is null || ColorPrevalenceEnabled is null || BorderColorEnabled is null || TransparencyEnabled is null)
            {
                return;
            }

            if (LightEnabled == 1) LightThemeEnable.Checked = true;
            else DarkThemeEnable.Checked = true;

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
                    reg.SetRegistryValue("overallTheme", "AppsUseLightTheme", 0x01, RegistryValueKind.DWord);
                    reg.SetRegistryValue("overallTheme", "AppsUseLightTheme", 0x01, RegistryValueKind.DWord);
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
                    reg.SetRegistryValue("overallTheme", "AppsUseLightTheme", 0x00, RegistryValueKind.DWord);
                    reg.SetRegistryValue("overallTheme", "AppsUseLightTheme", 0x00, RegistryValueKind.DWord);
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
            reg.SetRegistryValue("overallTheme", "ColorPrevalence", ColorPrevalenceToggle.Checked, RegistryValueKind.DWord);
        }

        private void BorderColorToggle_CheckedChanged(object sender, EventArgs e)
        {
            // Sprow: Then, ColorPrevalence here is window borders.
            reg.SetRegistryValue("dwmKey", "ColorPrevalence", BorderColorToggle.Checked, RegistryValueKind.DWord);
        }

        private void TransparencyEffectToggle_CheckedChanged(object sender, EventArgs e)
        {
            reg.SetRegistryValue("overallTheme", "EnableTransparency", TransparencyEffectToggle.Checked, RegistryValueKind.DWord);
        }
    }
}
