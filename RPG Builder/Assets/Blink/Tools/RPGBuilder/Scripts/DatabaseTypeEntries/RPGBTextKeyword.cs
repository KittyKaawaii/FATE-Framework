using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBTextKeyword : RPGBuilderDatabaseEntry
{
    
    public void UpdateEntryData(RPGBTextKeyword newEntryData)
    {
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
    }
}
