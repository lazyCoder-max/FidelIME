using System;
using FidelIME.Enums;

namespace FidelIME.InputManager.Unix;

public class MouseMoveEvent : EventArgs
{
    public MouseMoveEvent(MouseAxis axis, int amount)
    {
        Axis = axis;
        Amount = amount;
    }
    
    public MouseAxis Axis { get; }
    
    public int Amount { get; set; }
}