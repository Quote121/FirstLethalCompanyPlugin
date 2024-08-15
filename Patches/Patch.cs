using HarmonyLib;
using UnityEngine;
using MyFirstPlugin;

namespace MyFirstPlugin
{
    public class Patch
    {
        [HarmonyPatch(typeof(ShipLights), "SetShipLightsServerRpc")]
        public class ShipLightsPatchLog : ShipLights
        {
            static void Prefix()
            {
                Plugin.Log($"{Plugin.PluginInfo.PLUGIN_GUID} Successful injection into prefix ToggleShipLights");
                //// If on planet
                //if (!StartOfRound.Instance.inShipPhase)
                //{
                //    if (StartOfRound.Instance.currentLevel.name == "Level1Experimentation")
                //    {
                //        Plugin.Log("We are on experimentation.");
                //        return;
                //    }
                //}
            }

            static void Postfix()
            {
                //string val = Utilities.Numbers<string>.GetRandomArrayVal(ref Utilities.StringData.signalTranslatorMessages);
                Plugin.Log($"{Plugin.PluginInfo.PLUGIN_GUID} Successful injection into post ToggleShipLights: {Plugin.LightCount}");
                Plugin.instance.hudManInstance.UseSignalTranslatorClientRpc(Utilities.StringData.GetRandomMessage("signalTranslatorMessages"), 1);
            }
        }

        [HarmonyPatch(typeof(TimeOfDay), "MoveGlobalTime")]
        public class TimeOfDayStop : TimeOfDay
        {
            
            //static void Prefix()
            //{
            //    Plugin.Log($"{Plugin.PluginInfo.PLUGIN_GUID} MoveGlobalTime Prefix");
            //    return;
            //}

            //static void Postfix(TimeOfDay __instance)
            //{
            //    Plugin.Log($"{Plugin.PluginInfo.PLUGIN_GUID} MoveGlobalTime Postfix time: {__instance.timeUntilDeadline}");
            //    __instance.timeUntilDeadline += 10; // Undo time move
            //}
        }

        // Infinite door power
        [HarmonyPatch(typeof(HangarShipDoor), "Update")]
        public class ForceDoorClosed : HangarShipDoor
        {
            static void Postfix(HangarShipDoor __instance)
            {
                __instance.doorPower = 1.0f;
            }
        }


        [HarmonyPatch(typeof(GrabbableObject), "Update")]
        public class JetPack : GrabbableObject
        { 
            static void Postfix(GrabbableObject __instance)
            {
                __instance.insertedBattery.charge = 1.0f;
            }

        }
    }
}
