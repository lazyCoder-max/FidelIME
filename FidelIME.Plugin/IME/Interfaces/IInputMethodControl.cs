namespace FidelIME.Plugin.IME.Interfaces
{
    /// <summary>
    /// Input Method Controls
    /// </summary>
    public interface IInputMethodControl
    {
        /// <summary>
        /// Convert character to Ethiopic value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string? ToEthiopic(string value);
    }
}