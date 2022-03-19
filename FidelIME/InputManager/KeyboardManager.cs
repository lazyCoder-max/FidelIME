using System;
using FidelIME.InputManager.Interfaces;
using FidelIME.InputManager.Unix;
using FidelIME.InputManager.Unix.Interfaces;

namespace FidelIME.InputManager
{
    public class KeyboardManager : IKeyboardManager
    {
        private IAggregateInputReader listener;
        public void StartKeyboardListener()
        {
            IOSManager osManager = new OSManager();
            listener = osManager.GetListener();
            listener.OnKeyPress+=ListenerOnOnKeyPress;
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