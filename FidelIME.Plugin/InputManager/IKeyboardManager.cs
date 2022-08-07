﻿using System.Threading.Tasks;

namespace FidelIME.Plugin.InputManager
{
    public interface IKeyboardManager
    {
        Task StartHookAsync();
        void StopHook();
    }
}