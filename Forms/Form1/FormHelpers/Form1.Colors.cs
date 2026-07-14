using Microsoft.Win32;
using WinTouchUp.Helpers.Exceptions;

namespace WinTouchUp
{
    partial class MainForm
    {
        // Sprow: This table stores data for HandleColorPickOfId to use a fast lookup
        // Sprow: No more massive switch-cases
        private readonly Dictionary<ThemeElement, int> ThemeElementTable = new() {
            { ThemeElement.Accent, 1  },
            { ThemeElement.Hover, 0  },
            { ThemeElement.Titlebar , 2 },
            { ThemeElement.Inactive, -1  },
            { ThemeElement.SettingsIcon , 3 },
            { ThemeElement.Start , 4 },
            { ThemeElement.TaskbarFront , 5 },
            { ThemeElement.TaskbarBack , 6 }
        };

        /// <summary>
        /// Opens a color picker dialog for the user
        /// </summary>
        /// <returns>Integer: Hex Color Value (ARGB)</returns>
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
                (uint)HexCode & 0xFF00FF00 |
                ((uint)HexCode & 0x00FF0000) >> 16 |
                ((uint)HexCode & 0x000000FF) << 16
            );

            try
            {
                if (ControlName == ThemeElement.Titlebar)
                {
                    reg.SetRegistryValue("dwmKey", "AccentColor", ABGRHexCode, RegistryValueKind.DWord);
                    reg.SetRegistryValue("dwmKey", "AccentColorMenu", ABGRHexCode, RegistryValueKind.DWord);
                }
                else if (ControlName == ThemeElement.Inactive)
                {
                    reg.SetRegistryValue("dwmKey", "AccentColorInactive", ABGRHexCode, RegistryValueKind.DWord);
                    return;
                }

                SetAccentPaletteValue(ThemeElementTable[ControlName], HexCode);
            }
            catch (KeyNotFoundException)
            {
                var ex = new RecoverableException($"attempting to customize value {ControlName}",
                    "DictKey",
                    "When trying to get the name from an internal list, the element was not found.",
                    "HandleColorPickOfId",
                    false);
                ex.Show();

                return;
            }
            catch (Exception ex)
            {
                var exi = new RecoverableException($"attempting to customize value {ControlName}",
                    "Unknown",
                    ex.Message,
                    "HandleColorPickOfId",
                    false);

                exi.Show();
                return;
            }
        }

        /// <summary>
        /// Returns the value of an index of AccentPalette value
        /// </summary>
        /// <param name="index">Int: Value Retrieval Index</param>
        /// <returns>String: Hex Color Value (RGB)</returns>
        public string GetAccentPaletteValue(int index)
        {
            try
            {
                byte[]? AccentPalette = (byte[]?)reg.GetRegistryValue("explorerTheme", "AccentPalette", RegistryValueKind.Binary)
                    ?? throw new RecoverableException("getting accent palette values","RegistryNull","Could not find the value AccentPalette","GetAccentPaletteValue",true);
                int byteOffset = index * 4;

                byte r = AccentPalette[byteOffset];
                byte g = AccentPalette[byteOffset + 1];
                byte b = AccentPalette[byteOffset + 2];

                return $"#{r:X2}{g:X2}{b:X2}";
            }
            catch (RecoverableException ex)
            {
                ex.Show();
                return "#000000";
            }
        }
        /// <summary>
        /// Sets an index of AccentPalette value to specified color
        /// </summary>
        /// <param name="index">Int: Value Set Index</param>
        /// <param name="value">Int: Hex Color Value (RGBA)</param>
        private void SetAccentPaletteValue(int index, int value)
        {
            try
            {
                byte[]? AccentPalette = (byte[]?)reg.GetRegistryValue("explorerTheme", "AccentPalette", RegistryValueKind.Binary)
                    ?? throw new RecoverableException("setting accent palette values", "RegistryNull", "Could not find the value AccentPalette", "SetAccentPaletteValue", true);
                int byteOffset = index * 4;

                ReadOnlySpan<byte> newValue = [
                    (byte)((value >> 16) & 0xFF),
                    (byte)((value >> 8) & 0xFF),
                    (byte)(value & 0xFF),
                    0xFF
                ];

                newValue.CopyTo(AccentPalette.AsSpan(byteOffset, 4));

                reg.SetRegistryValue("explorerTheme", "AccentPalette", AccentPalette, RegistryValueKind.Binary);
            }
            catch (RecoverableException ex)
            {
                ex.Show();
            }
        }
    }
}
