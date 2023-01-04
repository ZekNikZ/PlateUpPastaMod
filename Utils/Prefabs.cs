using KitchenData;
using KitchenLib;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace KitchenPastaMod
{
    internal class Prefabs
    {
        public static GameObject UncookedPasta => FindPrefab(ItemReferences.Potato);
        public static GameObject Apple => FindPrefab(ItemReferences.Apple);
        public static GameObject Oil => FindPrefab(ItemReferences.Oil);
        public static GameObject UncookedPastaInPot => FindPrefab(ItemGroupReferences.BoiledPotatoRaw);

        private static GameObject FindPrefab(int id)
        {
            return ((Item) GDOUtils.GetExistingGDO(id)).Prefab;
        }
    }
}
