using HarmonyLib;
using UnityEngine;

namespace MyFirstPlugin
{
    public class PluginInit
    {
        [HarmonyPatch(typeof(HUDManager), "Awake")]
        public class GetHUDInstance : HUDManager
        {
            [HarmonyPostfix]
            static void Postfix(HUDManager __instance)
            {
                Plugin.instance.hudManInstance = __instance;
            }
        }
    }
}

