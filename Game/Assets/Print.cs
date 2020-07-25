using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Print
{
    //Example on how to use: Print.Log("Mission Added!", scriptName, scriptColour);
    public static void Log(string text, string name, string colour)
    {
        Debug.Log("<color=" + colour + "><b>[" + name + "]</b> " + text + "</color>");
    }

    public static void Warning(string text, string name, string colour)
    {
        Debug.LogWarning("<color=" + colour + "><b>[" + name + "]</b> " + text + "</color>");
    }

    public static void Error()
    {

    }
}
