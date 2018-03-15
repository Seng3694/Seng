using System.Runtime.InteropServices;

namespace Seng.Core
{
    public static class PInvoke
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
    }
}
