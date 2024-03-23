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
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "Snowlance.LC_NoOneLeftBehindAlt";
        private const string modName = "LC_NoOneLeftBehindAlt";
        private const string modVersion = "1.0.3";

        private readonly Harmony harmony = new Harmony(modGUID);
        public static Plugin Instance;
        
        public static ManualLogSource LoggerInstance { get; private set; }
        public bool aparatusTaken = !FindObjectOfType<LungProp>().isLungDocked;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            LoggerInstance = this.Logger;
            LoggerInstance.LogInfo($"Plugin {modName} loaded successfully.");

            harmony.PatchAll();
        }
    }
}
