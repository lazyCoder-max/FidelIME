using FidelIME.Plugin.InputManager.Unix.Enums;
using System;

namespace FidelIME.Plugin.InputManager.Unix
{
    /// <summary>
    /// Event controller for Mouse activity
    /// </summary>
    public class MouseMoveEvent : EventArgs
    {
        /// <summary>
        /// Constractor Method
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="amount"></param>
        /// 
        public MouseMoveEvent(MouseAxis axis, int amount)
        {
            Axis = axis;
            Amount = amount;
        }
        /// <summary>
        /// Returns Mouse Axis
        /// </summary>
        public MouseAxis Axis { get; }
        /// <summary>
        /// Get and Set Mouse Position
        /// </summary>
        public int Amount { get; set; }
    }
}