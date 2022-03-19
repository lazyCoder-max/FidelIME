using System.Collections.Generic;
using System.Timers;

namespace FidelIME.IME;

public interface IInputEditor
{
    /// <summary>
    /// Check if the character counter is on the first index
    /// </summary>
    bool IsFirstCharacter { get; }

    List<string> inputCharacter { get; set; }
}

public class InputEditor : IInputEditor
{
    public List<string> inputCharacter { get; set; }  
    private Timer _timer;

    public InputEditor()
    {
        inputCharacter = new List<string>();
        _timer = new Timer(3000);
        _timer.Elapsed+= TimerOnElapsed;
        _timer.Start();
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        // Reset input characters to default value
        inputCharacter.Clear();
    }
    
    
    /// <summary>
    /// Check if the character counter is on the first index
    /// </summary>
    public bool IsFirstCharacter
    {
        get
        {
            if (inputCharacter.Count == 1)
                return true;
            return false;
        }
    }
}