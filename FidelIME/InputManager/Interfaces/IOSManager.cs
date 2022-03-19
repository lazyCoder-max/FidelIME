using FidelIME.InputManager.Unix.Interfaces;

namespace FidelIME.InputManager.Interfaces;

public interface IOSManager
{
    IAggregateInputReader GetListener();
}