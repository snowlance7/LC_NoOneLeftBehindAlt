using BepInEx.Logging;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_NoOneLeftBehindAlt
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class JammedControlsBase : BaseUnityPlugin
    {
        private const string modGUID = "Snowlance.LC_NoOneLeftBehindAlt";
        private const string modName = "LC_NoOneLeftBehindAlt";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static JammedControlsBase Instance;

        public static ManualLogSource LoggerInstance { get; private set; }

        private void Awake()
        {
            if ((Object)(object)Instance == (Object)null)
            {
                Instance = this;
            }
            LoggerInstance = this.Logger;
            LoggerInstance.LogInfo($"Plugin {modName} loaded successfully.");
            MoveToShipPatch.Init(LoggerInstance);
            harmony.PatchAll();
        }
    }
}
