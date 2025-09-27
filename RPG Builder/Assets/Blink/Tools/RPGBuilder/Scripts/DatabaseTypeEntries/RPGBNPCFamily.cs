using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBNPCFamily : RPGBuilderDatabaseEntry
{
    public Sprite icon;
    public Color color = Color.white;
    
    public void UpdateEntryData(RPGBNPCFamily newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        icon = newEntryData.icon;
        color = newEntryData.color;
    }
}
