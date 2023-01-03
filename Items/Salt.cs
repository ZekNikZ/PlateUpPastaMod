using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenPastaMod.Items
{
    public class Salt: CustomItem
    {
        public override string UniqueNameID => "Z Salt";
        public override GameObject Prefab => Prefabs.Apple;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
    }
}
