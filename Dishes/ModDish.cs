using KitchenData;
using KitchenLib.Customs;
using PastaMod.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenPastaMod.Dishes
{
    public abstract class ModDish : CustomDish, ILocalisedRecipeHolder
    {
        public virtual IDictionary<Locale, string> LocalisedRecipe { get; }

        public virtual IDictionary<Locale, UnlockInfo> LocalisedInfo { get; }

        public override LocalisationObject<UnlockInfo> Info
        {
            get
            {
                var info = new LocalisationObject<UnlockInfo>();

                foreach (var entry in LocalisedInfo)
                {
                    info.Add(entry.Key, entry.Value);
                }

                return info;
            }
        }

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Dish dish = gameDataObject as Dish;
            ModRegistry.AddLocalisedRecipe(this, dish);
        }
    }
}
