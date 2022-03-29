using FidelIME.Plugin.InputManager.Interfaces;
using FidelIME.Plugin.InputManager.Unix;
using FidelIME.Plugin.InputManager.Unix.Interfaces;
using System;

namespace FidelIME.Plugin.InputManager
{
    /// <summary>
    /// Determine Opreating System and Set Controller for the OS
    /// </summary>
    public class OSManager : IOSManager
    {
        private IAggregateInputReader unixInputReader;

        private OperatingSystem GetOpreatingSystem
        {
            get
            {
                return Environment.OSVersion;
            }
        }

        /// <summary>
        /// Get Input Listener value for the specified opreating system
        /// </summary>
        public IAggregateInputReader GetListener
        {
            get
            {
                var os = GetOpreatingSystem;
                if (os.Platform == PlatformID.Unix)
                {
                    unixInputReader = new AggregateInputReader();
                    return unixInputReader;
                }
                else if (os.Platform == PlatformID.MacOSX)
                {

                }

                return unixInputReader;
            }
        }
    }
}