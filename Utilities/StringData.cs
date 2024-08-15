using System.Collections.Generic;
using System;

namespace MyFirstPlugin.Utilities
{
    public class StringData
    {
        static internal Dictionary<string, List<string>> lists = new() 
        {
            { "signalTranslatorMessages", new List<string>{ "Im behind", "Run", "Alone?", "Kill them" } },
            { "terminalMessages", new List<string>{ "Test terminal msg" } }
        };
        
        static public string GetRandomMessage(string listKey)
        {
            if (lists.TryGetValue(listKey, out List<string> values))
            {
                Random rand = new();
                return values[rand.Next(0, values.Count)];
            }
            else
                Plugin.Log($"Cannot find list entry: {listKey} in GetRandomMessage()");
            return "";
        }

    }
}
