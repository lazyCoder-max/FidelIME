namespace FidelIME.Plugin.IME.Interfaces
{
    public interface ISyllableControl
    {
        string GetSyllable(string value);

        /// <summary>
        /// Convert character to Ethiopic value
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        string ToEthiopic(string[] values);

        /// <summary>
        /// Convert character to Ethiopic value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string ToEthiopic(string value);

        /// <summary>
        /// Convert string to UTF-16
        /// </summary>
        /// <param name="utf8String"></param>
        /// <returns></returns>
        string GetCharacterValue(string utf8String);
    }
}