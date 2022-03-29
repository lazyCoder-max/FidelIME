using FidelIME.Plugin.InputManager.Interfaces;
using FidelIME.Plugin.InputManager.Unix;

namespace FidelIME.Plugin.InputManager
{
    public class KeyboardManager : IKeyboardManager
    {
        private Unix.Interfaces.IAggregateInputReader listener;
        public void StartKeyboardListener()
        {
            IOSManager osManager = new OSManager();
            listener = osManager.GetListener;
            listener.OnKeyPress += ListenerOnOnKeyPress;
        }

        private void ListenerOnOnKeyPress(KeyPressEvent e)
        {

        }

        public void DisposeKeyboardListener()
        {
            listener.OnKeyPress -= ListenerOnOnKeyPress;
        }
    }
}