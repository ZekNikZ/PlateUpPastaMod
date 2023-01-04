using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenPastaMod.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenPastaMod.Appliances
{
    public class SaltProvider : ModAppliance
    {
        public override string UniqueNameID => "Source - Salt";
        public override string Description => "Provides salt";
        public override int BaseGameDataObjectID => ApplianceReferences.SourceOil;

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder()
        };

        public override List<IApplianceProperty> PostInitPropertiesToAttach => new()
        {
            new CItemProvider()
            {
                AutoPlaceOnHolder = true,
                Available = 1,
                Maximum = 1,
                PreventReturns = true,
            }.WithItem(Refs.Salt.ID)
        };

        public override IDictionary<Locale, ApplianceInfo> LocalisedInfo => new Dictionary<Locale, ApplianceInfo>()
        {
            { Locale.English, LocalisationUtils.CreateApplianceInfo("Salt Provider", "Provides Salt", new() { }, new() { "test" }) }
        };
    }
}
