namespace WinTouchUp.Helpers.Exceptions
{
    // Sprow: Frick SoC. This is already set as a WinForms app and so WinForms code is shoved down your throat no matter what.
    // Sprow: Just doing it here is faster since we don't have an extra using for this namespace. (It's publicly done)
    public class WTUException(string when, string what, string how, string where, bool userError) : Exception(message: how)
    {
        public string When { get; } = when;
        public string What { get; } = what;
        public string How { get; } = how;
        public string Where { get; } = where;

        protected string UserError() => userError ?
        "Do not open issue on GitHub. Please contact privately via the contact form in the readme and provide email in subject line for resolution."
        : "Please open an issue on GitHub. Do not contact through the contact form in the readme.";
    }

    public class RecoverableException(string when, string what, string how, string where, bool userError) :
        WTUException(when, what, how, where, userError)
    {

        public void Show()
        {
            
            MessageBox.Show($"An error occurred while {When}.\n\nError: Recoverable{What}Exception -- {How}\nWhere? {Where}\n\n{UserError()}", "Error");
        }
    }
    public class UnrecoverableException(string when, string what, string how, string where, bool userError) :
        WTUException(when, what, how, where, userError)
    {

        public void Show()
        {
            MessageBox.Show($"An error occurred while {When}.\n\nError: Unrecoverable{What}Exception -- {How}\nWhere? {Where}\n\n{UserError()}\nTo prevent damage, the program will be closed.", "Critical");
        }
    }
}
