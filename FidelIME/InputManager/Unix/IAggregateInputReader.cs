namespace FidelIME.InputManager.Unix;

public interface IAggregateInputReader
{
    event InputReader.RaiseKeyPress OnKeyPress;
}