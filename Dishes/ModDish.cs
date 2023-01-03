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
        public class CustomUnlockInfo
        {
            public string Name;
            public string FlavourText;
            public string Description;

            public CustomUnlockInfo() { }

            public UnlockInfo Convert()
            {
                UnlockInfo unlockInfo = ScriptableObject.CreateInstance<UnlockInfo>();
                unlockInfo.Name = Name;
                unlockInfo.FlavourText = FlavourText;
                unlockInfo.Description = Description;
                return unlockInfo;
            }
        }


        public virtual IDictionary<Locale, string> LocalisedRecipe { get; }
        public virtual IDictionary<Locale, CustomUnlockInfo> LocalisedInfo { get; }

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Dish dish = gameDataObject as Dish;

            //LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
            //foreach (var entry in LocalisedInfo)
            //{
            //    info.Add(entry.Key, entry.Value.Convert());
            //}
            //dish.Info = info;
            //dish.Localise(Localisation.CurrentLocale, GameData.Main.Substitutions); // shim needed until KL is fixed

            ModRegistry.AddLocalisedRecipe(this, dish);
        }
    }
}
