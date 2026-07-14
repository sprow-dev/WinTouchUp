using System.Runtime.InteropServices;
using WinTouchUp.Helpers.Exceptions;

namespace WinTouchUp
{
    partial class MainForm
    {
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

        IntPtr accentPtr = IntPtr.Zero;

        // Sprow: Although I believe I cleaned the memory leak up, it is best practice to not
        // Sprow: execute this class twice. Keep that in mind.

        /// <summary>
        /// Enables the Acrylic blur effect on Window.
        /// Warning: This uses an undocumented Windows API. If it breaks, not my fault.
        /// </summary>
        private void EnableBlur()
        {
            var accent = new AccentPolicy
            {
                AccentState = 4,
                GradientColor = unchecked((int)0x9F000000)
            };

            var accentStructSize = Marshal.SizeOf(accent);

            try
            {
                accentPtr = Marshal.AllocHGlobal(accentStructSize);
                Marshal.StructureToPtr(accent, accentPtr, false);

                var data = new WindowCompositionAttributeData
                {
                    Attribute = 19,
                    SizeOfData = accentStructSize,
                    Data = accentPtr
                };

                // Sprow: Here we go with a discard to get my code editor to shut up.
                _ = SetWindowCompositionAttribute(this.Handle, ref data);
            }
            catch (EntryPointNotFoundException)
            {
                var ex = new UnrecoverableException("initializing Acrylic effect",
                    "APIAdjustment",
                    "It appears an update has changed an undocumented Windows API required for the blur effect to initialize.",
                    "MainForm_Load",
                    false);
                ex.Show();
                this.Close();
                // Sprow: If form does not close, this block executes
                Application.Exit();
            }
            finally
            {
                // Sprow: Free memory right when it is not needed anymore or after an exception
                // Sprow: We leak if this isn't done
                if (accentPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(accentPtr);
                }
            }
        }
    }
}
