using System;
using System.Threading.Tasks;

namespace FidelIME.Plugin.InputManager
{
    public interface IKeyboardManager
    {
        Task StartHookAsync();
        void StopHook();
        event EventHandler<string> KeyboardTyped;
        event EventHandler<string> WordCreated;
    }
}