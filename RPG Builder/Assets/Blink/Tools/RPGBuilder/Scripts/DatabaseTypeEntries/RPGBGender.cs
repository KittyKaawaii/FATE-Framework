using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBGender : RPGBuilderDatabaseEntry
{
    public Sprite background;
    public Color color = Color.white;
    
    public void UpdateEntryData(RPGBGender newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        background = newEntryData.background;
        color = newEntryData.color;
    }
}
