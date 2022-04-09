﻿namespace FidelIME.Plugin.IME.Interfaces
{
    public interface ISyllableControl
    {
        string GetSyllable(string value);
        string ToEthiopic(string[] values);
        string ToEthiopic(string value);
    }
}