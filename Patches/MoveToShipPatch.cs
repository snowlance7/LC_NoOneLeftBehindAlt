using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LC_NoOneLeftBehindAlt;

namespace LC_NoOneLeftBehindAlt.Patches
{
    [HarmonyPatch]
    internal static class MoveToShipPatch
    {
        private static readonly MethodInfo tpPlayer = typeof(StartOfRound).GetMethod("TeleportPlayerInShipIfOutOfRoomBounds", BindingFlags.Instance | BindingFlags.NonPublic);
        private static ManualLogSource Logger = Plugin.LoggerInstance;

        [HarmonyPatch(typeof(StartOfRound), "ShipLeave")]
        [HarmonyPrefix]
        public static void TpOnShipLeave(StartOfRound __instance)
        {
            Logger.LogDebug($"Aparatus Taken: {Plugin.Instance.aparatusTaken}");
            if (!Plugin.Instance.aparatusTaken)
            {
                Logger.LogInfo("Teleporting player back to the ship...");
                tpPlayer?.Invoke(__instance, null);
            }
        }
    }
}
