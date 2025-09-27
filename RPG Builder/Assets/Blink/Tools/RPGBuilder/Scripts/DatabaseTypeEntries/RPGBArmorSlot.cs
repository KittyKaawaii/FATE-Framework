using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBArmorSlot : RPGBuilderDatabaseEntry
{
    
    public void UpdateEntryData(RPGBArmorSlot newEntryData)
    {
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
    }
}
