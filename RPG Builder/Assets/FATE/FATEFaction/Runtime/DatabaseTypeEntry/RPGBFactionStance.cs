using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATEFaction.Runtime.DatabaseTypeEntry
{
    public class RPGBFactionStance : RPGBuilderDatabaseEntry
    {
        public Color color = Color.white;
    
        public void UpdateEntryData(RPGBFactionStance newEntryData)
        {
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            color = newEntryData.color;
        }
    }
}
