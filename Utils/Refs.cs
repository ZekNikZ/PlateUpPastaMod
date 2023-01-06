using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenPastaMod.Appliances;
using KitchenPastaMod.Dishes;
using KitchenPastaMod.Items;

namespace KitchenPastaMod
{
    internal class Refs
    {
        #region Vanilla References
        public static Item Apple => Find<Item>(ItemReferences.Apple);
        public static Item CrackedEgg => Find<Item>(ItemReferences.EggCracked);
        public static Item DoughBall => Find<Item>(ItemReferences.Dough);
        public static Item Egg => Find<Item>(ItemReferences.Egg);
        public static Item Flour => Find<Item>(ItemReferences.Flour);
        public static Item GratedCheese => Find<Item>(ItemReferences.CheeseGrated);
        public static Item Plate => Find<Item>(ItemReferences.Plate);
        public static Item Pot => Find<Item>(ItemReferences.Pot);
        public static Item Tomato => Find<Item>(ItemReferences.Tomato);
        public static Item TomatoSauce => Find<Item>(ItemReferences.TomatoSauce);
        public static Item Water => Find<Item>(ItemReferences.Water);
        public static Process Chop => Find<Process>(ProcessReferences.Chop);
        public static Process Cook => Find<Process>(ProcessReferences.Cook);
        #endregion

        #region Modded References
        public static Appliance SaltProvider => Find<Appliance, SaltProvider>();
        public static Item RawPasta => Find<Item, RawPasta>();
        public static Item RawPastaInPot => Find<Item, UnboiledWater>();
        public static Item Salt => Find<Item, Salt>();
        public static Item SaltIngredient => Find<Item, SaltIngredient>();
        public static Dish TestDish => Find<Dish, TestDish>();
        #endregion

        private static T Find<T>(int id) where T: GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }

        private static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return (T)GDOUtils.GetCustomGameDataObject<C>().GameDataObject;
        }
    }
}
