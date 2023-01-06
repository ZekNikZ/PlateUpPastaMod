using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace KitchenPastaMod.Items
{
    public class Salt: CustomItem
    {
        public override string UniqueNameID => "Z Salt";
        public override GameObject Prefab => Prefabs.Oil;
        public override bool AllowSplitMerging => true;
        public override bool IsIndisposable => true;
        public override ItemValue ItemValue => ItemValue.Small;
        public override bool PreventExplicitSplit => true;
        public override int Reward => 3;
        public override int SplitCount => 999;
        public override float SplitSpeed => 1;
        public override Item SplitSubItem => Refs.SaltIngredient;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override Appliance DedicatedProvider => Refs.SaltProvider;
    }
}
