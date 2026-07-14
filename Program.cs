namespace WinTouchUp
{
    internal static class Program
    {
        private static Mutex? _dedup_mtx;

        [STAThread]
        static void Main()
        {
            _dedup_mtx = new Mutex(true, "WTU_DedupMtx", out bool isNewInstance);
            if (!isNewInstance) return;

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}