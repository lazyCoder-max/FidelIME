using FidelIME.Plugin.InputManager.Unix.Interfaces;

namespace FidelIME.Plugin.InputManager.Interfaces
{
    /// <summary>
    /// Interface class for <see cref="OSManager"/>
    /// </summary>
    public interface IOSManager
    {
        /// <summary>
        /// Get Input Listener value for the specified opreating system
        /// </summary>
        IAggregateInputReader GetListener { get; }
    }
}