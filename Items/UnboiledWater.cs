using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenPastaMod.Items
{
    public class UnboiledWater : CustomItemGroup
    {
        public override string UniqueNameID => "Z Unboiled Water";
        public override GameObject Prefab => Prefabs.UncookedPastaInPot;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override Item DisposesTo => Refs.Pot;
        public override Item DirtiesTo => Refs.Pot;

        public override bool CanContainSide => true;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Min = 2,
                Max = 2,
                Items = new()
                {
                    Refs.SaltIngredient,
                    Refs.Water
                }
            },
            new ItemGroup.ItemSet()
            {
                Min = 1,
                Max = 1,
                IsMandatory = true,
                Items = new()
                {
                    Refs.Pot
                }
            }
        };
    }
}
