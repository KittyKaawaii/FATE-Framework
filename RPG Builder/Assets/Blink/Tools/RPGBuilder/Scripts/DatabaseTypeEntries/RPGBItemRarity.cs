using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBItemRarity : RPGBuilderDatabaseEntry
{
    public Sprite background;
    public Color color = Color.white;
    
    public void UpdateEntryData(RPGBItemRarity newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        background = newEntryData.background;
        color = newEntryData.color;
    }
}
