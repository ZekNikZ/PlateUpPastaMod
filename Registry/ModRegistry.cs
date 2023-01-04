using KitchenData;
using KitchenLib.Event;
using KitchenPastaMod.Appliances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaMod.Registry
{
    public class ModRegistry
    {
        private static readonly List<Tuple<ILocalisedRecipeHolder, Dish>> recipeHolders = new();
        private static readonly List<Tuple<ModAppliance, Appliance>> postInitApplianceProperties = new();

        public static void AddLocalisedRecipe(ILocalisedRecipeHolder holder, Dish dish)
        {
            recipeHolders.Add(new Tuple<ILocalisedRecipeHolder, Dish>(holder, dish));
        }

        public static void AddPostInitApplianceProperties(ModAppliance modAppliance, Appliance appliance)
        {
            postInitApplianceProperties.Add(new Tuple<ModAppliance, Appliance>(modAppliance, appliance));
        }

        public static void HandleBuildGameDataEvent(BuildGameDataEventArgs args)
        {
            // Recipe holders
            foreach (var holder in recipeHolders)
            {
                foreach (var entry in holder.Item1.LocalisedRecipe)
                {
                    args.gamedata.GlobalLocalisation.Recipes.Info.Get(entry.Key).Text.Add(holder.Item2, entry.Value);
                }
            }

            // Appliance properties
            foreach (var applianceEntry in postInitApplianceProperties)
            {
                foreach (var prop in applianceEntry.Item1.PostInitPropertiesToAttach)
                {
                    applianceEntry.Item2.Properties.Add(prop);
                }
            }
        }
    }
}
