using Kitchen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenPastaMod.Utils
{
    public static class Extensions
    {
        public static CItemProvider WithItem(this CItemProvider provider, int itemId)
        {
            var field = typeof(CItemProvider).GetField("Item", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            TypedReference reference = __makeref(provider);
            field.SetValueDirect(reference, itemId);

            provider.Attach();

            return provider;
        }
    }
}
