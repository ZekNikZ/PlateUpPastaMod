using Kitchen;
using KitchenData;
using KitchenLib.Event;
using KitchenPastaMod.Appliances;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace KitchenPastaMod.Registry
{
    [UpdateBefore(typeof(GrantUpgrades))]
    internal class ModRegistry : GenericSystemBase
    {
        private EntityQuery Upgrades;

        private static readonly List<Tuple<ILocalisedRecipeHolder, Dish>> RecipeHolders = new();
        private static readonly List<Tuple<ModAppliance, Appliance>> PostInitApplianceProperties = new();
        private static readonly List<Dish> BaseDishes = new();

        public static void AddLocalisedRecipe(ILocalisedRecipeHolder holder, Dish dish)
        {
            RecipeHolders.Add(new Tuple<ILocalisedRecipeHolder, Dish>(holder, dish));
        }

        public static void AddPostInitApplianceProperties(ModAppliance modAppliance, Appliance appliance)
        {
            PostInitApplianceProperties.Add(new Tuple<ModAppliance, Appliance>(modAppliance, appliance));
        }

        public static void AddBaseDish(Dish dish)
        {
            BaseDishes.Add(dish);
        }

        public static void HandleBuildGameDataEvent(BuildGameDataEventArgs args)
        {
            // Recipe holders
            foreach (var holder in RecipeHolders)
            {
                foreach (var entry in holder.Item1.LocalisedRecipe)
                {
                    args.gamedata.GlobalLocalisation.Recipes.Info.Get(entry.Key).Text.Add(holder.Item2, entry.Value);
                    Mod.LogInfo($"Registered recipe \"{entry.Key}\" localization entry for dish {holder.Item2.Name} ({holder.Item2.ID}): \"{entry.Value}\"");
                }
            }

            // Appliance properties
            foreach (var applianceEntry in PostInitApplianceProperties)
            {
                foreach (var prop in applianceEntry.Item1.PostInitPropertiesToAttach)
                {
                    applianceEntry.Item2.Properties.Add(prop);
                }
            }
        }

        protected override void Initialise()
        {
            Upgrades = GetEntityQuery(typeof(CUpgrade));
        }

        protected override void OnUpdate()
        {
            NativeArray<CUpgrade> existing = Upgrades.ToComponentDataArray<CUpgrade>(Allocator.Temp);

            // Base dishes
            foreach (var dish in BaseDishes)
            {
                foreach (CUpgrade item in existing)
                {
                    if (item.ID == dish.ID)
                    {
                        goto next_dish;
                    }
                }

                var entity = EntityManager.CreateEntity(typeof(CUpgrade), typeof(CPersistThroughSceneChanges));
                EntityManager.AddComponentData(entity, new CUpgrade
                {
                    ID = dish.ID
                });
                Mod.LogInfo($"Registered base dish {dish.Name} ({dish.ID})");

                next_dish: { }
            }

            existing.Dispose();
        }
    }
}
