using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBStatCategory : RPGBuilderDatabaseEntry
{
    public void UpdateEntryData(RPGBStatCategory newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
    }
}
