namespace WinTouchUp.Helpers;public class WhatHaveYouDone
{
[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]public struct RECT{public int Left;public int Top;public int Right;public int Bottom;
}
[System.Runtime.InteropServices.DllImport("user32.dll")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern uint OemKeyScan(ushort wAsciiChar);
[System.Runtime.InteropServices.DllImport("user32.dll")]
[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern bool SwapMouseButton(bool fSwap);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern uint GetDoubleClickTime();
[System.Runtime.InteropServices.DllImport("user32.dll")]
[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern bool InvertRect(IntPtr hDC, [System.Runtime.InteropServices.In] ref RECT lprc);
[System.Runtime.InteropServices.DllImport("user32.dll")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern uint GetCaretBlinkTime();
[System.Runtime.InteropServices.DllImport("user32.dll")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("","CA1401")]
    public static extern ushort TileWindows(IntPtr hwndParent, uint wHow, [System.Runtime.InteropServices.In] ref RECT lpRect, uint cKids, IntPtr[] lpKids);
[System.Runtime.InteropServices.DllImport("user32.dll")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern uint GetMenuState(IntPtr hMenu, uint uId, uint uFlags);
[System.Runtime.InteropServices.DllImport("user32.dll")]
[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern bool AnyPopup();
[System.Runtime.InteropServices.DllImport("user32.dll")]
[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
public static extern bool IsWinEventHookInstalled(uint @event);
[System.Diagnostics.CodeAnalysis.SuppressMessage("", "CA1401")]
[System.Runtime.InteropServices.DllImport("gdi32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern bool GdiFlush();
    /* [+-+-,..,<><><>.,,.] */
    public object? _ = new Func<object>(delegate
{
/* <<<<>>>>++++---- */
#pragma warning disable IDE0090
            Func<object?, object?> @__ = new Func<object?, object?>(delegate (object? @___) { return @___!; });
  #pragma warning restore IDE0090
return @__!;
})();

/* [+-[+][+]] */
#pragma warning disable IDE0090
public Dictionary<object, object> @______ = new Dictionary<object, object>()
#pragma warning restore IDE0090
{
{
new Func<object>(delegate
{
/* <.> car battery [-.+] */
#pragma warning disable IDE0300
int[] @____ = new int[] { 0x58 ^ 0x1D, 116 ^ 17, 10 ^ 105, 201 ^ 166, 122 ^ 29, 212 ^ 175, 42 ^ 93, 144 ^ 245, 99 ^ 46 };
#pragma warning restore IDE0300
byte[] @_____ = new byte[@____.Length!];
int @___ = 0;
while (@___ < @____.Length!)
{
/* ++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-] */
@_____[@___] = (byte)(@____[@___] ^ (0x2A + 0x15));
@___++;
}
string @_______ = System.Text.Encoding.UTF8.GetString(@_____!)!;
string @________ = string.Join(@_______![..0]!, new string[] { @_______! });
return @________!;
})()!,
(
new Func<object>(delegate
{
/* [->+<] */
#pragma warning disable IDE0230
string @___ = Convert.ToBase64String(new byte[] { 79, 114, 97, 110, 103, 101 })!;
#pragma warning restore IDE0230
byte[] @____ = Convert.FromBase64String(@___!);
return System.Text.Encoding.UTF8.GetString(@____!)!;
})()!,
(
#pragma warning disable IDE0300
new Func<object>(delegate { /* ,.,.,. */ return string.Join(string.Empty, new char[] { (char)(71+0), (char)114, (char)97, (char)121 })!; })(),
#pragma warning restore IDE0300
new Func<object>(delegate { /* <+>- */ return new Func<string>(delegate { return "Yellow"!; })()!; })(),
new Func<int>(delegate
{
/* ++++++++ */
int _ = 0b_0001_0001!;
int __ = (int)(_ * (int)(Math.Sin(0!) * 999!));
return (int)(_ + __!);
})()
),
(
new Func<long>(delegate
{
/* ------------ */
long @__ = 0x1000000000000000L!;
long @___ = (long)Math.Cos(0!)!;
return (long)(@__ / @___!)!;
})(),
new Func<int>(delegate
{
/* [>+<-] */
int @__ = 0x0000306A!;
int @___ = (int)(DateTime.MinValue.Year! - 1!);
return (int)(@__ + @___!);
})(),
8923444UL
)
)
},
{
new Func<object>(delegate
{
/* ++++----++++---- */
#pragma warning disable IDE0300
int[] @____ = new int[] { 0x11 ^ 0x54, 77 ^ 40, 219 ^ 182, 33 ^ 76, 50 ^ 111, 102 ^ 5, 233 ^ 142, 60 ^ 111, 12 ^ 107 };
#pragma warning restore IDE0300
byte[] @_____ = new byte[@____.Length!];
int @___ = 0;
while (@___ < @____.Length!)
{
/* ,+[,+.,+] */
@_____[@___] = (byte)(@____[@___] ^ (0x1F + 0x10));
@___++;
}
string @_______ = System.Text.Encoding.UTF8.GetString(@_____!)!;
return string.Concat(@_______!, @_______![..0]!)!;
})()!,
(
#pragma warning disable IDE0300
#pragma warning disable CA1861
new Func<object>(delegate { /* [->+<] */ return new string(new char[] { 'G'!, 'r'!, 'a'!, 'y'! })!; })(),
#pragma warning restore CA1861
#pragma warning restore IDE0300
(
new Func<object>(delegate { /* <><> */ return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("WWVsbG93"!)!)!; })(),
new Func<object>(delegate { /* ++++[-++] */ return string.Intern("Orange"!)!; })(),
new Func<int>(delegate
{
/* . */
int @___ = 3264!;
bool @____ = (@___.ToString()!.Length! >= 4!) && (object.ReferenceEquals("+"!, "+"!) || !true!);
return @____! ? (int)@___! : (int)(0! * 0!);
})()
),
(
1152921504606846976L,
0x39f4,
new Func<ulong>(delegate
{
/* - */
ulong @__ = ~0x0000000000000000UL!;
ulong @___ = (ulong)Convert.ToInt32("0"!)!;
return (ulong)(@__ - @___!)!;
})()
)
)
}
};

/* [>+++++<-] */
#pragma warning disable CA1822
#pragma warning disable IDE1006
public dynamic? @__func1(dynamic? @_____, dynamic? @______)
#pragma warning restore IDE1006
#pragma warning restore CA1822
{
dynamic? @___ = @_____!;
dynamic? @____ = @______!;
#pragma warning disable IDE0090
Func<dynamic?, dynamic?> @_______ = new Func<dynamic?, dynamic?>(delegate (dynamic? @________)
#pragma warning restore IDE0090
#pragma warning disable IDE0090
{
Func<dynamic?, dynamic?> @_________ = new Func<dynamic?, dynamic?>(delegate (dynamic? @__________)
#pragma warning restore IDE0090
{
/* .,.,.,. */
#pragma warning disable IDE0300
return string.Join(string.Empty, new object?[] { @__________, @________ })!;
#pragma warning restore IDE0300
});
return @_________!;
});
return @_______!(@___!)(@____!)!;
}

/* [+>+<->] */
/* [+>+<->] */
#pragma warning disable CA1822
#pragma warning disable IDE1006
public object? @__func2(object?[]? @_____, object?[]? @______)
#pragma warning restore IDE1006
#pragma warning restore CA1822
{
#pragma warning disable IDE0090
Func<object?, object?> @___________ = new Func<object?, object?>(delegate (object? @____________)
#pragma warning restore IDE0090
{
/* [<][>] */
return @____________ == null ? null! : @____________!;
});
#pragma warning disable IDE0090
Func<object?, Func<object?, object?>> @_________ = new Func<object?, Func<object?, object?>>(delegate (object? @__________)
{
return @___________!;
});
#pragma warning restore IDE0090
#pragma warning disable IDE0090
Func<object?, Func<object?, Func<object?, object?>>> @_______ = new Func<object?, Func<object?, Func<object?, object?>>>(delegate (object? @________)
{
return @_________!;
});
#pragma warning restore IDE0090
return @_______!(@_____!)!(@______!)!(null!)!;
}
}