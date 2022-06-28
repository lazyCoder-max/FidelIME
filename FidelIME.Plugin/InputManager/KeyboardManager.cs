
using Desktop.Robot;
using Desktop.Robot.Extensions;
using FidelIME.Plugin.IME;
using FidelIME.Plugin.IME.Interfaces;
using SharpHook;

namespace FidelIME.Plugin.InputManager
{
    /// <summary>
    /// Keyboard Manager to start and stop the Hook
    /// </summary>
    public class KeyboardManager : IKeyboardManager
    {
        private TaskPoolGlobalHook hook { get; set; }
        ISyllableControl syllableControl = new SyllableControl(new InputEditor());
        Robot robot = new Robot();
        public KeyboardManager()
        {
        }

        /// <summary>
        /// Start Keyboard Hook
        /// </summary>
        public void StartHook()
        {
            hook = new TaskPoolGlobalHook();
            hook.HookEnabled += Hook_HookEnabled;
            hook.HookDisabled += Hook_HookDisabled;
            hook.KeyTyped += Hook_KeyTyped;
            hook.KeyReleased += Hook_KeyReleased;
            hook.KeyPressed += Hook_KeyPressed;
            hook.Run();
        }
        /// <summary>
        /// Dispose Keyboard Hook
        /// </summary>
        public void StopHook()
        {
            hook.HookEnabled -= Hook_HookEnabled;
            hook.HookDisabled -= Hook_HookDisabled;
            hook.KeyTyped -= Hook_KeyTyped;
            hook.KeyReleased -= Hook_KeyReleased;
            hook.KeyPressed -= Hook_KeyPressed;
            hook.Dispose();
        }
        private void Hook_KeyPressed(object sender, KeyboardHookEventArgs e)
        {

        }

        private void Hook_KeyReleased(object sender, KeyboardHookEventArgs e)
        {
        }
        bool isTyping = false;
        private void Hook_KeyTyped(object sender, KeyboardHookEventArgs e)
        {
            if (!isTyping)
            {
                if (e.Data.KeyChar != '\b' || !e.Data.KeyChar.ToString().Contains("\\"))
                {
                    if (e.Data.KeyChar != 'U')
                    {
                        isTyping = true;
                        robot.KeyPress(Key.Backspace);
                        var result = syllableControl.ToEthiopic(e.Data.KeyChar.ToString());
                        if (!string.IsNullOrEmpty(result))
                        {
                            var convertedVal = syllableControl.GetCharacterValue(result);
                            robot.CombineKeys(new Key[] { Key.Control, Key.Shift, Key.U });
                            robot.Type(convertedVal);
                            robot.Type(new Key[] { Key.Enter });
                            isTyping = false;
                        }
                    }
                }
            }
        }

        private void Hook_HookDisabled(object sender, HookEventArgs e)
        {

        }

        private void Hook_HookEnabled(object sender, HookEventArgs e)
        {
        }

    }
}