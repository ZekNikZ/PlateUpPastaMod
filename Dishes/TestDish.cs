using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenPastaMod.Dishes
{
    public class TestDish : ModDish
    {
        public override string UniqueNameID => "Penne";
        public override DishType Type => DishType.Base;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override GameObject DisplayPrefab => Prefabs.UncookedPasta;
        public override GameObject IconPrefab => Prefabs.UncookedPasta;

        public override List<string> StartingNameSet => new()
        {
            "Penne for your thoughts",
            "Pasta la Vista"
        };

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override bool IsUnlockable => true;

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;

        public override HashSet<Item> MinimumIngredients => new()
        {
            Refs.Plate,
            Refs.Flour,
            Refs.Egg,
            Refs.Water,
            Refs.Tomato,
            Refs.Pot,
            Refs.Salt
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            Refs.Cook,
            Refs.Chop
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new Dish.MenuItem()
            {
                Item = Refs.RawPastaInPot
            }
        };

        public override IDictionary<Locale, string> LocalisedRecipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Make Pasta" }
        };

        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Test Dish", "Test Dish Description", "Test Dish Flavour Text") }
        };
    }
}
