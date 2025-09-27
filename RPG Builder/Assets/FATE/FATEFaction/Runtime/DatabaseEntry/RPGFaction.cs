using System.Collections.Generic;
using BLINK.RPGBuilder.Combat;
using FATE.FATECustomAttribute.Runtime.AttributeParam;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEFaction.Runtime.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace FATE.FATEFaction.Runtime.DatabaseEntry
{
    public class RPGFaction : RPGBuilderDatabaseEntry
    {
        [FormerlySerializedAs("factionStances"),ReadOnlyFieldWithName("Отношения")]public List<FactionStanceData> FactionStances = new();

        [FormerlySerializedAs("factionInteractions"),ReadOnlyFieldWithName("Отношения фракций")]public List<FactionInteractionData> FactionInteractions = new();
    
        public void UpdateEntryData(RPGFaction newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            FactionStances = newEntryData.FactionStances;
            FactionInteractions = newEntryData.FactionInteractions;
        }
    }

}
