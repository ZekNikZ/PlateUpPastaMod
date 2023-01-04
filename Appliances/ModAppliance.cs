using KitchenData;
using KitchenLib.Customs;
using PastaMod.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
