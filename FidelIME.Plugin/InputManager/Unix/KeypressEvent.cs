using FidelIME.Plugin.InputManager.Unix.Enums;
using System;

namespace FidelIME.Plugin.InputManager.Unix
{
    public class KeyPressEvent : EventArgs
    {
        public KeyPressEvent(EventCode code, KeyState state)
        {
            Code = code;
            State = state;
        }

        public EventCode Code { get; }

        public KeyState State { get; }
    }
}