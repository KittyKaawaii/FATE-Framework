using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBAbilityCooldownTag : RPGBuilderDatabaseEntry
{
    
    public void UpdateEntryData(RPGBAbilityCooldownTag newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
    }
}
