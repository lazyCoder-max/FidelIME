using System;
using System.Threading.Tasks;

namespace FidelIME.Plugin.InputManager
{
    public interface IKeyboardManager
    {
        Task StartHookAsync();
        void StopHook();
        void Replace(string word);
        event EventHandler<string> KeyboardTyped;
        event EventHandler<string> WordCreated;
    }
}