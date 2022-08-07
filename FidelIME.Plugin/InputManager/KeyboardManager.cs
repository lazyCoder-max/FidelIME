
using Desktop.Robot;
using Desktop.Robot.Extensions;
using FidelIME.Plugin.IME;
using FidelIME.Plugin.IME.Interfaces;
using SharpHook;
using System;
using System.Threading.Tasks;

namespace FidelIME.Plugin.InputManager
{
    /// <summary>
    /// Keyboard Manager to start and stop the Hook
    /// </summary>
    public class KeyboardManager : IKeyboardManager
    {
        private TaskPoolGlobalHook hook { get; set; }
        private EventSimulator Simulator { get; set; }
        ISyllableControl syllableControl = new SyllableControl(new InputEditor());
        Robot robot = new Robot();
        public KeyboardManager()
        {
            Simulator = new EventSimulator();
        }

        /// <summary>
        /// Start Keyboard Hook
        /// </summary>
        public async Task StartHookAsync()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32S:
                    break;
                case PlatformID.Win32Windows:
                    break;
                case PlatformID.Win32NT:
                    //here
                    hook = new TaskPoolGlobalHook();
                    hook.HookEnabled += Hook_HookEnabled;
                    if(!hook.IsRunning)
                    {
                        hook.KeyTyped += Hook_KeyTyped;
                        await hook.RunAsync();
                    }
                    break;
                case PlatformID.WinCE:
                    break;
                case PlatformID.Unix:
                    break;
                case PlatformID.Xbox:
                    break;
                case PlatformID.MacOSX:
                    break;
                case PlatformID.Other:
                    break;
                default:
                    break;
            }

        }
        
        private void Hook_KeyTyped(object sender, KeyboardHookEventArgs e)
        {
            if(hook.IsRunning)
            {
                if(e.Data.KeyChar == 'a')
                {
                    Simulator.SimulateKeyPress(SharpHook.Native.KeyCode.VcLeftControl);
                    Simulator.SimulateKeyPress(SharpHook.Native.KeyCode.VcA);
                    Simulator.SimulateKeyRelease(SharpHook.Native.KeyCode.VcLeftControl);
                    Simulator.SimulateKeyRelease(SharpHook.Native.KeyCode.VcA);
                }
            }
        }

        private void Hook_HookEnabled(object sender, HookEventArgs e)
        {
            
        }

        public void StopHook()
        {
            throw new NotImplementedException();
        }
    }
}