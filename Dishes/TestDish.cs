﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override List<string> StartingNameSet => new List<string> {
            "Penne for your thoughts",
            "Pasta la Vista"
        };

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        public override bool IsUnlockable => true;

        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Plate,
            Refs.Flour,
            Refs.Egg,
            Refs.Water,
            Refs.Tomato,
            Refs.Pot
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook,
            Refs.Chop
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>()
        {
            new Dish.MenuItem()
            {
                Item = Refs.RawPasta
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
