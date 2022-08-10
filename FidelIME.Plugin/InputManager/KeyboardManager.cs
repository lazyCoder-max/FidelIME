
using Desktop.Robot;
using Desktop.Robot.Extensions;
using FidelIME.Plugin.IME;
using FidelIME.Plugin.IME.Interfaces;
using GregsStack.InputSimulatorStandard;
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
        ISyllableControl syllableControl;
        public bool IsInputAutomated { get; set; } = true;
        public bool IsSpaceClicked { get; set; } = false;
        public InputSimulator Simulator { get; set; }
        public event EventHandler<string> KeyboardTyped;
        public event EventHandler<string> WordCreated;
        public string Word { get; set; }

        Robot robot = new Robot();
        public KeyboardManager()
        {

        }

        /// <summary>
        /// Start Keyboard Hook
        /// </summary>
        public async Task StartHookAsync()
        {
            Simulator = new InputSimulator();
            syllableControl = new SyllableControl();
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
                    if (!hook.IsRunning)
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
            if (hook.IsRunning)
            {
                if (e.Data.RawCode == 32)
                {
                    IsSpaceClicked = true;
                    syllableControl.ResetInputManager();
                    OnWordCreated(Word);
                    Word = "";
                }
                if (syllableControl.IsPerformClean && e.Data.KeyChar == 'A')
                    syllableControl.ResetInputManager();
                if (e.Data.KeyChar != '\b' && e.Data.RawCode != 32)
                {
                    try
                    {
                        ClickBackspace();
                        var result = syllableControl.ToEthiopic(e.Data.KeyChar);
                        if (syllableControl.IsPerformClean)
                            ClickBackspace();
                        Word += result;
                        IsInputAutomated = true;
                        OnKeyboardTyped(Word);
                        Simulator.Keyboard.TextEntry(result);
                        
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    if (!IsInputAutomated && e.Data.KeyChar == '\b')
                    {
                        // syllableControl.ResetInputManager();
                    }
                    else
                        IsInputAutomated = false;
                }
            }
        }

        private void Hook_HookEnabled(object sender, HookEventArgs e)
        {

        }

        public void StopHook()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32S:
                    break;
                case PlatformID.Win32Windows:
                    break;
                case PlatformID.Win32NT:
                    //here
                    if (hook != null)
                    {
                        hook.HookEnabled -= Hook_HookEnabled;
                        if (hook.IsRunning)
                        {
                            hook.KeyTyped -= Hook_KeyTyped;
                        }
                        hook.Dispose();
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
            Reset();
        }
        public void Reset()
        {
            IsInputAutomated = true;
            IsSpaceClicked = false;
            syllableControl = null;
            Word = "";
        }
        protected virtual void OnKeyboardTyped(string word)
        {
            if(word.Length>=2)
            {
                KeyboardTyped?.Invoke(this, word);
            }
        }
        protected virtual void OnWordCreated(string word)
        {
            if (word.Length >= 3)
            {
                WordCreated?.Invoke(this, word);
            }
        }
        private void ClickBackspace()
        {
            if (!IsSpaceClicked)
            {
               if (Word?.Length >= 1 && syllableControl.IsPerformClean)
                    Word = Word.Remove(Word.Length - 1,1);
                IsInputAutomated = true;
                robot.KeyPress(Key.Backspace);
                IsInputAutomated = false;
                syllableControl.IsPerformClean = false;
            }
            else
            {
                IsSpaceClicked = false;
                IsInputAutomated = true;
                robot.KeyPress(Key.Backspace);
                IsInputAutomated = false;
            }
        }
    }
}