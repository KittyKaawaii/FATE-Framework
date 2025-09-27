using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBHealingType : RPGBuilderDatabaseEntry
{
    public Color color = Color.white;
    public void UpdateEntryData(RPGBHealingType newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        color = newEntryData.color;
    }
}
