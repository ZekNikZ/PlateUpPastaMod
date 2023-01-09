using KitchenData;
using KitchenLib.Customs;
using KitchenPastaMod.Registry;
using System.Collections.Generic;

namespace KitchenPastaMod.Appliances
{
    public abstract class ModAppliance : CustomAppliance
    {
        public virtual IDictionary<Locale, ApplianceInfo> LocalisedInfo { get; }

        public override LocalisationObject<ApplianceInfo> Info
        {
            get
            {
                var info = new LocalisationObject<ApplianceInfo>();

                foreach (var entry in LocalisedInfo)
                {
                    info.Add(entry.Key, entry.Value);
                }

                return info;
            }
        }

        public virtual List<IApplianceProperty> PostInitPropertiesToAttach { get; }

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Appliance appliance = gameDataObject as Appliance;
            ModRegistry.AddPostInitApplianceProperties(this, appliance);
        }
    }
}
