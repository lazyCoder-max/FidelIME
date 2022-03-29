using FidelIME.Plugin.IME.Interfaces;

namespace FidelIME.Plugin.IME
{
    /// <summary>
    /// Provides Syllable Control of Ethiopic Letters
    /// </summary>
    public class SyllableControl : IInputMethodControl
    {
        private IInputEditor _inputEditor;

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="editor"></param>
        public SyllableControl(InputEditor editor)
        {
            _inputEditor = new InputEditor();
        }
        /// <summary>
        /// check if input value is vowel
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see cref="bool"/></returns>
        private bool IsVowel(string value)
        {
            if (value == "a" || value == "A" || value == "E" || value == "e" || value == "i" || value == "I" || value == "o" || value == "O" || value == "U" || value == "u")
                return true;
            return false;
        }
        /// <summary>
        /// Returns Ethiopic vowel value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
                case "u":
                    return "ኡ";
                case "U":
                    return "ኡ";
            }
            return null;
        }

        /// <summary>
        /// Convert character to Ethiopic value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string? ToEthiopic(string value)
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

    }
}