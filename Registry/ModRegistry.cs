using KitchenData;
using KitchenLib.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaMod.Registry
{
    public class ModRegistry
    {
        private static List<Tuple<ILocalisedRecipeHolder, Dish>> recipeHolders = new List<Tuple<ILocalisedRecipeHolder, Dish>>();

        public static void AddLocalisedRecipe(ILocalisedRecipeHolder holder, Dish dish)
        {
            recipeHolders.Add(new Tuple<ILocalisedRecipeHolder, Dish>(holder, dish));
        }

        public static void HandleBuildGameDataEvent(BuildGameDataEventArgs args)
        {
            foreach (var holder in recipeHolders)
            {
                foreach (var entry in holder.Item1.LocalisedRecipe)
                {
                    args.gamedata.GlobalLocalisation.Recipes.Info.Get(entry.Key).Text.Add(holder.Item2, entry.Value);
                }
            }
        }
    }
}
