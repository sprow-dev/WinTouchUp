using System.Runtime.CompilerServices;

namespace WinTouchUp.Helpers
{
    public static class Dnoi
    {
        private static volatile object? _anchor;

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void RunDnoi()
        {
            var why = new WhatHaveYouDone();

            _anchor = why;

            dynamic? combined = why.__func1("a", "b");
            object? validated = why.__func2([combined], null);

            GC.KeepAlive(_anchor);
            GC.KeepAlive(validated);
        }
    }
}
