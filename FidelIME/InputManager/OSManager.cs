using System;
using FidelIME.InputManager.Unix;

namespace FidelIME.InputManager;

public interface IOSManager
{
    IAggregateInputReader GetListener();
}

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

        return null;
    }
}