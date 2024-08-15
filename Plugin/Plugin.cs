using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection; // Used to get assembly

using System;
using Unity;
using UnityEngine;

namespace MyFirstPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        public static class PluginInfo
        {
            public const string PLUGIN_GUID = "quote121.MyFirstPlugin";
            public const string PLUGIN_NAME = "TestPlugin";
            public const string PLUGIN_VERSION = "0.0.1";
        }

        internal static new ManualLogSource Logger;

        public static int LightCount { get; internal set; } = 0;

        // HudManager
        public HUDManager hudManInstance;

        // Called externally
        private void Awake()
        {
            // Plugin startup logic
            Plugin.instance = this;
            Plugin.Logger = base.Logger;

            Log($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }

        // Publically accessable logging function
        public static void Log(string message)
        {
            Plugin.Logger.LogInfo(message);
        }
    }
}
