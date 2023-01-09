using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenPastaMod.Items
{
    public class RawPasta : CustomItemGroup
    {
        public override string UniqueNameID => "Z Raw Penne";
        public override GameObject Prefab => Prefabs.UncookedPasta;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override bool IsMergeableSide => true;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Min = 2,
                Max = 2,
                Items = new List<Item>
                {
                    Refs.CrackedEgg,
                    Refs.Flour
                }
            }
        };
    }
}
