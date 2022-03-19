using FidelIME.IME.Interfaces;
using FidelIME.IME.Models;

namespace FidelIME.IME;

public class SyllableControl: IInputMethodControl
{
    private IInputEditor _inputEditor;

    public SyllableControl(InputEditor editor)
    {
        _inputEditor = new InputEditor();
    }
    private bool IsVowel(string value)
    {
        if (value == "E" || value=="e" || value=="i"|| value=="I"|| value=="a"|| value=="A"|| value=="i" || value=="o"|| value=="O"|| value=="U"|| value=="u")
            return true;
        return false;
    }

    private string? GetVowelValue(string value)
    {
        switch (value)
        {
            case "a":
                return "ኣ";
            case "A":
                return "እ";
            case "E":
                return "አ";
            case "e":
                return "አ";
            case "i":
                return "ኢ";
            case "I":
                return "ኢ";
            case "O":
                return "ኦ";
            case "o":
                return "ኦ";
        }

        return null;
    }

    

    public string? GetEquivalentValue(string value)
    {
        string? result = null;
        if (_inputEditor.IsFirstCharacter)
        {
            if (IsVowel(value))
            {
                result = GetVowelValue(value);
            }
            else
            {
                
            }
        }
        else
        {
            
        }
        return result;
    }

    public string GetEquivalentValue(char value)
    {
        throw new System.NotImplementedException();
    }
}