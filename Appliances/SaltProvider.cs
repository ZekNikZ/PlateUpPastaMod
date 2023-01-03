using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenPastaMod.Appliances
{
    public class SaltProvider : CustomAppliance
    {
        public override string UniqueNameID => "Source - Salt";
        public override int BaseGameDataObjectID => ApplianceReferences.SourceOil;

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            new CItemHolder(),
            new CItemProvider()
            {
                AutoPlaceOnHolder = true,
                Available = 1,
                Maximum = 1,
                PreventReturns = true,
                ProvidedItem = Refs.Apple.ID
            }
        };
    }
}
