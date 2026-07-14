using System.Runtime.InteropServices;

namespace WinTouchUp
{
    partial class MainForm
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

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

        /// <summary>
        /// Uses documented Windows API to enable dragging the form by the top 22 pixels.
        /// </summary>
        private void App_DragTitleBar(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Y <= 22)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0); // 0xA1: WM_NCLBUTTONDOWN // 0x2: HT_CAPTION
            }
        }
    }
}
