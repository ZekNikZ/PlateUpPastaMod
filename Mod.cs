using Kitchen;
using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using KitchenPastaMod.Appliances;
using KitchenPastaMod.Dishes;
using KitchenPastaMod.Items;
using KitchenPastaMod.Registry;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using System.Linq;

// Namespace should have "Kitchen" in the beginning
namespace KitchenPastaMod
{
    public class Mod : BaseMod, IModSystem
    {
        // guid must be unique and is recommended to be in reverse domain name notation
        // mod name that is displayed to the player and listed in the mods menu
        // mod version must follow semver e.g. "1.2.3"
        public const string MOD_GUID = "pastamod";
        public const string MOD_NAME = "PastaMod";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "ZekNikZ";
        public const string MOD_GAMEVERSION = ">=1.1.1";
        public const bool DEBUG_MODE = true;
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.1" current and all future
        // e.g. ">=1.1.1 <=1.2.3" for all from/until

        private EntityQuery MenuItemQuery;

        public static AssetBundle Bundle;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void Initialise()
        {
            base.Initialise();

            // For log file output so the official plateup support staff can identify if/which a mod is being used
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
            
            MenuItemQuery = GetEntityQuery(new QueryHelper()
                .All(typeof(CDishChoice)));
        }

        protected void AddGameData()
        {
            LogInfo("Attempting to register game data...");

            // Appliances
            AddGameDataObject<SaltProvider>();

            // Items
            AddGameDataObject<RawPasta>();
            AddGameDataObject<SaltIngredient>();
            AddGameDataObject<Salt>();
            AddGameDataObject<UnboiledWater>();

            // Dishes
            AddGameDataObject<TestDish>();
            AddGameDataObject<TestSide>();

            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
            if (!DEBUG_MODE) return;

            if (Refs.TestDish == null) return;

            var menuChoices = MenuItemQuery.ToEntityArray(Allocator.TempJob);
            foreach (var menuChoice in menuChoices)
            {
                CDishChoice cDishChoice = EntityManager.GetComponentData<CDishChoice>(menuChoice);
                cDishChoice.Dish = Refs.TestDish.ID;
                EntityManager.SetComponentData(menuChoice, cDishChoice);
            }
            menuChoices.Dispose();
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            //LogInfo("Attempting to load asset bundle...");
            //Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            //LogInfo("Done loading asset bundle.");

            AddGameData();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                ModRegistry.HandleBuildGameDataEvent(args);
            };
        }

        #region Logging
        // You can remove this, I just prefer a more standardized logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
