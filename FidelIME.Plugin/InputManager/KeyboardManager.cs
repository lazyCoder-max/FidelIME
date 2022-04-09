
using Desktop.Robot;
using Desktop.Robot.Extensions;
using FidelIME.Plugin.IME;
using FidelIME.Plugin.IME.Interfaces;
using SharpHook;

namespace FidelIME.Plugin.InputManager
{
    public class KeyboardManager
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
        private void Hook_KeyTyped(object sender, KeyboardHookEventArgs e)
        {
            if (e.Data.KeyChar != '\b' || !e.Data.KeyChar.ToString().Contains("\\"))
            {
                robot.KeyPress(Key.Backspace);
                var result = syllableControl.ToEthiopic(e.Data.KeyChar.ToString());
                var convertedVal = syllableControl.GetCharacterValue(result);
                robot.Type(convertedVal);
                robot.CombineKeys(new Key[] { Key.Alt, Key.X });//s1235
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