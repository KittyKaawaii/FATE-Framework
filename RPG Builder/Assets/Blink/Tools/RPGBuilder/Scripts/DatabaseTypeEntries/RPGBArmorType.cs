using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBArmorType : RPGBuilderDatabaseEntry
{
    
    public void UpdateEntryData(RPGBArmorType newEntryData)
    {
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
    }
}
