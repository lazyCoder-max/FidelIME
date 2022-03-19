using System;
using FidelIME.InputManager.Interfaces;
using FidelIME.InputManager.Unix;
using FidelIME.InputManager.Unix.Interfaces;

namespace FidelIME.InputManager;

public class OSManager : IOSManager
{
    private IAggregateInputReader unixInputReader;
    private OperatingSystem GetOpreatingSystem
    {
        get
        {
            return Environment.OSVersion;
        }
    }

    public IAggregateInputReader GetListener()
    {
        var os = GetOpreatingSystem;
        if (os.Platform == PlatformID.Unix)
        {
            unixInputReader = new AggregateInputReader();
            return unixInputReader;
        }
        else if(os.Platform == PlatformID.MacOSX)
        {
             
        }

        return unixInputReader;
    }
}