using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElGetter
{
    public static DBScript dBScript;
    public static AnimationLogin login;

    public static void Init(DBScript dB)
    {
        dBScript = dB;
    }

    public static void Init(AnimationLogin log)
    {
        login = log;
    }
}
