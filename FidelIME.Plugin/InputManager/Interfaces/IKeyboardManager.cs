namespace FidelIME.Plugin.InputManager.Interfaces
{
    public interface IKeyboardManager
    {
        /// <summary>
        /// Starts Listening keyboard input
        /// </summary>
        void StartKeyboardListener();
        /// <summary>
        /// Stop Listening keyboard input
        /// </summary>
        void DisposeKeyboardListener();
    }
}