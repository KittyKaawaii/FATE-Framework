using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBDamageType : RPGBuilderDatabaseEntry
{
    public Color color = Color.white;
    public void UpdateEntryData(RPGBDamageType newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        color = newEntryData.color;
    }
}
