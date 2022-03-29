namespace FidelIME.Plugin.InputManager.Unix.Interfaces
{
    public interface IAggregateInputReader
    {
        event InputReader.RaiseKeyPress OnKeyPress;
    }
}