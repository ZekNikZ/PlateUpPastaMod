using KitchenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaMod.Registry
{
    public interface ILocalisedRecipeHolder
    {
        IDictionary<Locale, string> LocalisedRecipe { get; }
    }
}
