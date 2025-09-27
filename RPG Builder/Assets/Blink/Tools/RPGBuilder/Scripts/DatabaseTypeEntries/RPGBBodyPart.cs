using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBBodyPart : RPGBuilderDatabaseEntry
{
    public void UpdateEntryData(RPGBBodyPart newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
    }
}
