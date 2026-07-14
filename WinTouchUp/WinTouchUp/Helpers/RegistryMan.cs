using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Security;
using WinTouchUp.Helpers;
using WinTouchUp.Helpers.Exceptions;

namespace WinTouchUp.Helpers
{
    // Sprow: Helpers are static unless stateful.
    // Sprow: This is a stateful class and will not be marked static.

    // Sprow: I have made my best effort to comment this class thoroughly since it is extremely easy to get lost.
    public class RegMan
    {
        public Dictionary<string, string> RegKeys = new() { { "", "" } };

        // Sprow: IMPORTANT: This only supports HKCU. For any other types of modifications, typing will have to be changed to a string-tuple pair and the hive will have to be passed.
        public RegMan(Dictionary<string, string> KeyDict)
        {
            // Sprow: Do not investigate.
            // Sprow: Your brain will break if you do.
            // Sprow: For whatever cryptic reason, this code NEEDS to be here or it'll cause a race condition.
            // Sprow: I have spent 3 hours trying to find out why and I left with more questions than answers.
            Dnoi.RunDnoi();

            // Sprow: Local state context => global state context.
            RegKeys = KeyDict;

            // Sprow: Wrap the whole thing in a try-catch block; we are just doing registry sanitization.
            try
            {
                if (RegKeys.Count == 0 || (RegKeys.Count == 1 && RegKeys.All(kvp => kvp.Key == "" && kvp.Value == "")))
                {
                    // Sprow: The registry is not what is at fault; we simply mark it as recoverable for now. However, we will have to catch exceptions down the road.
                    // Sprow: Catching exceptions down the road may be more helpful to me when I am handling issue reports.
                    throw new RecoverableException("initializing Registry Manager",
                        "RegistryNull",
                        "No arguments provided.",
                        "RegMan",
                        false);
                }

                foreach (var kvp in RegKeys)
                {
                    // Sprow: To make sure intent is clear: I use a using statement AND a discard here instead of just one or the other to show that I don't actually need this key.
                    using RegistryKey? _ = Registry.CurrentUser.OpenSubKey(kvp.Value, true) ??
                    // Sprow: This exception is unrecoverable because it is an immediate threat to our code.
                    throw new UnrecoverableException("initializing Registry Manager",
                        "RegistryNull",
                        "Registry key required for program to run does not exist or user does not have permission to access it. Could this be a managed or stripped-down system?",
                        "RegMan",
                        true);
                }
            }
            catch (RecoverableException ex)
            {
                ex.Show();
            }
            catch (UnrecoverableException ex)
            {
                // Sprow: We do not load the form yet when this class is accessed, so we do not need to clean up its components.
                ex.Show();
                Application.Exit();
            }
            catch (UnauthorizedAccessException)
            {
                // Sprow: I use a separate exception variable here because we cannot re-throw and re-catch. It does the same thing, just not as pretty.
                var ex = new UnrecoverableException("initializing Registry Manager",
                            "RegistryNull",
                            "User does not have permission to read registry key required for program to run. Could this be a managed system?",
                            "RegMan",
                            true);

                // Sprow: I do not use a method here to replace these 2 lines because it is a method to literally run 2 lines of code.
                // Sprow: This is a reasonable amount of DRY violation. If I ever do have to change these 2, my logic is incorrect and I will refactor to a function.
                ex.Show();
                Application.Exit();
            }
            catch (Exception ex)
            {
                // Sprow: I use name 'exi' because it stands for 'exception internal'. I need the original exception so I can pass it.
                // Sprow: I use recoverable because I do not know if this will jeopardize the application's integrity yet. It's an unhandled error, after all.
                var exi = new RecoverableException("initializing Registry Manager",
                            "Unknown",
                            ex.Message,
                            "RegMan",
                            false);

                exi.Show();
            }
        }

        public void SetRegistryValue(string keyKey, string valueName, object value, RegistryValueKind type)
        {
            string keyPath;

            // Sprow: some idiot decided to make computers and now i have a 30-yard-long list of ways that my program could fail and no ways to fix them
            try
            {
                keyPath = RegKeys[keyKey];

                value = type switch
                {
                    RegistryValueKind.String or RegistryValueKind.ExpandString => Convert.ToString(value) ?? string.Empty,
                    RegistryValueKind.DWord => Convert.ToInt32(value), // Sprow: Int32 for internal Win32 handling (why is it that way? no clue. is it that way? yes)
                    RegistryValueKind.QWord => Convert.ToInt64(value), // Sprow: Same here but replace 32 with 64
                    RegistryValueKind.Binary => (object)value as byte[] ?? System.Text.Encoding.UTF8.GetBytes(value?.ToString() ?? string.Empty),
                    RegistryValueKind.MultiString => (object)value as string[] ?? [value?.ToString() ?? string.Empty],
                    _ => value ?? throw new RecoverableException($"attempting to set registry value {valueName}",
                        "RegistryKey",
                        "Expected value input; got null instead.",
                        "SetRegistryValue",
                        true)
                };

                using RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true) ??
                throw new RecoverableException($"attempting to set registry value {valueName}",
                    "RegistryKey",
                    "Registry value was not found.",
                    "SetRegistryValue",
                    true);


                key.SetValue(valueName, value, type);
            }
            catch (RecoverableException ex)
            {
                ex.Show();
                return;
            }
            catch (KeyNotFoundException)
            {
                var ex = new RecoverableException($"attempting to set registry value {valueName}",
                    "DictKey",
                    "When trying to get the name from an internal list, the element was not found.",
                    "SetRegistryValue",
                    false);
                ex.Show();

                return;
            }
            catch (FormatException)
            {
                var ex = new RecoverableException($"attempting to set registry value {valueName}",
                    "Conversion",
                    "Could not convert from provided format to requested format.",
                    "SetRegistryValue",
                    false);

                ex.Show();
                return;
            }
            catch (ArgumentException)
            {
                var ex = new RecoverableException($"attempting to set registry value {valueName}",
                    "ArgumentType",
                    "Registry value type did not match expected type.",
                    "SetRegistryValue",
                    false);

                ex.Show();
                return;
            }
            catch (Exception ex)
            {
                var exi = new RecoverableException($"attempting to set registry value {valueName}",
                    "Unknown",
                    ex.Message,
                    "SetRegistryValue",
                    false);

                exi.Show();
                return;
            }

            // Sprow: some idiot accused me of being ai, but i don't give a crap and I'm not "fixing" this code to be bad
            // Sprow: Is it just me or does anyone else notice the decline in code quality because of AI's popularity? I hope it's just me, but...
        }

        public object? GetRegistryValue(string keyKey, string valueName, RegistryValueKind type)
        {
            string keyPath;

            try
            {
                keyPath = RegKeys[keyKey];

                using RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, false) ??
                throw new RecoverableException($"attempting to get registry value {valueName}",
                    "RegistryKey",
                    "Registry key was not found.",
                    "GetRegistryValue",
                    true);

                object value = key.GetValue(valueName) ??
                throw new RecoverableException($"attempting to get registry value {valueName}",
                    "RegistryKey",
                    "Registry value was not found.",
                    "GetRegistryValue",
                    true);

                value = type switch
                {
                    RegistryValueKind.String or RegistryValueKind.ExpandString => Convert.ToString(value) ?? string.Empty,
                    RegistryValueKind.DWord => (int)value, // Sprow: int instead of uint for internal Win32 handling (why is it that way? no clue. is it that way? yes)
                    RegistryValueKind.QWord => (long)value, // Sprow: Same here but with long and ulong
                    RegistryValueKind.Binary => value as byte[] ?? System.Text.Encoding.UTF8.GetBytes(value?.ToString() ?? string.Empty),
                    RegistryValueKind.MultiString => value as string[] ?? [value?.ToString() ?? string.Empty],
                    _ => value ?? throw new RecoverableException($"attempting to get registry value {valueName}",
                        "RegistryKey",
                        "Expected value input; got null instead.",
                        "GetRegistryValue",
                        true)
                };

                return value;
            }
            catch (RecoverableException ex)
            {
                ex.Show();
                return null;
            }
            catch (KeyNotFoundException)
            {
                var ex = new RecoverableException($"attempting to get registry value {valueName}",
                    "DictKey",
                    "When trying to get the name from an internal list, the element was not found.",
                    "GetRegistryValue",
                    false);
                ex.Show();

                return null;
            }
            catch (FormatException)
            {
                var ex = new RecoverableException($"attempting to get registry value {valueName}",
                    "Conversion",
                    "Could not convert from provided format to requested format.",
                    "GetRegistryValue",
                    false);

                ex.Show();
                return null;
            }
            catch (Exception ex)
            {
                var exi = new RecoverableException($"attempting to get registry value {valueName}",
                    "Unknown",
                    ex.Message,
                    "GetRegistryValue",
                    false);

                exi.Show();
                return null;
            }
        }
    }
}