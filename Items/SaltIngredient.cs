using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace KitchenPastaMod.Items
{
    public class SaltIngredient : CustomItem
    {
        public override string UniqueNameID => "Z Salt - Ingredient";

        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Small;

        public override GameObject Prefab => Prefabs.Apple;

        public override int Reward => 3;
    }
}
