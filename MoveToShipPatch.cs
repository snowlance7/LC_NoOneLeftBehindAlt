using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LC_NoOneLeftBehindAlt
{
    [HarmonyPatch]
    internal static class MoveToShipPatch
    {
        private static readonly MethodInfo tpPlayer = typeof(StartOfRound).GetMethod("TeleportPlayerInShipIfOutOfRoomBounds", BindingFlags.Instance | BindingFlags.NonPublic);
        private static bool aparatusTaken = false;
        private static ManualLogSource Logger { get; set; }

        public static void Init(ManualLogSource logger)
        {
            Logger = logger;
        }

        [HarmonyPatch(typeof(LungProp), nameof(LungProp.EquipItem))]
        [HarmonyPrefix]
        public static void ApparatusTaken(StartOfRound __instance)
        {
            aparatusTaken = true;
        }

        [HarmonyPatch(typeof(StartOfRound), "ShipLeave")]
        [HarmonyPrefix]
        public static void TpOnShipLeave(StartOfRound __instance)
        {
            if (!aparatusTaken)
            {
                Logger.LogInfo((object)"Teleporting player back to the ship...");
                tpPlayer?.Invoke(__instance, null);
            }
        }
    }
}
