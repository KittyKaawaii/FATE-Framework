using System.Collections.Generic;
using BLINK.RPGBuilder.Combat;
using FATE.FATECustomAttribute.Runtime.AttributeParam;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEFaction.Runtime.Data;
using UnityEngine;

namespace FATE.FATEFaction.Runtime.DatabaseEntry
{
    public class RPGFaction : RPGBuilderDatabaseEntry
    {
        [ReadOnlyField]public List<FactionStanceData> factionStances = new();

        [ReadOnlyField]public List<FactionInteractionData> factionInteractions = new();
    
        public void UpdateEntryData(RPGFaction newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;
        
            factionStances = newEntryData.factionStances;
            factionInteractions = newEntryData.factionInteractions;
        }
    }

}
