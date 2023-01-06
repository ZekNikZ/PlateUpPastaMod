using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenPastaMod.Dishes
{
    public class TestSide : ModDish
    {
        public override string UniqueNameID => "Meatballs";
        public override DishType Type => DishType.Side;
        public override CardType CardType => CardType.Default;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override GameObject DisplayPrefab => Prefabs.Apple;
        public override GameObject IconPrefab => Prefabs.Apple;

        public override List<string> StartingNameSet => new List<string> {
        };

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override bool IsUnlockable => true;

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Apple
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>()
        {
            new Dish.MenuItem()
            {
                Item = Refs.Apple
            }
        };

        public override IDictionary<Locale, string> LocalisedRecipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Make Apple" }
        };

        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Test Side", "Test Side Description", "Test Side Flavour Text") }
        };

        public override HashSet<Dish> PrerequisiteDishesEditor => new HashSet<Dish>()
        {
            Refs.TestDish
        };

        public override List<Unlock> HardcodedRequirements => new List<Unlock>()
        {
            Refs.TestDish
        };
    }
}
