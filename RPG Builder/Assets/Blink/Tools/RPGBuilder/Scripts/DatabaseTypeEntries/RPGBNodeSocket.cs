using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBNodeSocket : RPGBuilderDatabaseEntry
{
    
    public void UpdateEntryData(RPGBNodeSocket newEntryData)
    {
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
    }
}
