using Microsoft.Win32;
using WinTouchUp.Helpers.Exceptions;

namespace WinTouchUp
{
    partial class MainForm
    {

        // overallThemeKey  = 0
        // explorerThemeKey = 1
        // dwmThemeKey      = 2

        // Sprow: If SubKey is a number (as a string, it will be cast later),
        // Sprow: that means it is part of the Explorer Accent key and will be managed by another function

        // Sprow: I apoligize that this is hard to follow, but it's the only clean way to run RefreshColors
        // Sprow: At least, without writing 2000 lines of enums and structs and whatever.
        // Sprow: I'd, at that point, have to create EnumSpaghetti.cs and NO C# dev EVER wants to do that or *shudder* read it later.
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

        /// <summary>
        /// Refreshes the colors tab to match new registry values.
        /// </summary>
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
                        int color_abgr = (int?)reg.GetRegistryValue("dwmKey", location.SubKey, RegistryValueKind.DWord) ??
                            throw new RecoverableException("refreshing the colors tab","RegistryNull","Value under dwmKey was not found.","RefreshColors",true);
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

        /// <summary>
        /// Runs complex conversions to and from CIELCH to determine the values of different colors to set in the Windows registry.
        /// </summary>
        private void ThemeColorPick_Click(object sender, EventArgs e)
        {
            int hexValue = UserPickColorHex();

            if (hexValue == -1) return;

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

        /// <summary>
        /// Standardized function to show and manage a color picker and set the value in the registry to the picked color.
        /// </summary>
        private void PickButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string elementName = clickedButton.Name.Replace("Pick", "");

            int hexColorInt = UserPickColorHex();
            if (hexColorInt == -1) return;

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
