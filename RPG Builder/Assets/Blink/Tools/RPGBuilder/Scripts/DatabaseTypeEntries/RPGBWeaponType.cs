using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBWeaponType : RPGBuilderDatabaseEntry
{
    
    public void UpdateEntryData(RPGBWeaponType newEntryData)
    {
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
    }
}
