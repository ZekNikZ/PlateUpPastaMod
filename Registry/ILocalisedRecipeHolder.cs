using KitchenData;
using System.Collections.Generic;

namespace KitchenPastaMod.Registry
{
    public interface ILocalisedRecipeHolder
    {
        IDictionary<Locale, string> LocalisedRecipe { get; }
    }
}
