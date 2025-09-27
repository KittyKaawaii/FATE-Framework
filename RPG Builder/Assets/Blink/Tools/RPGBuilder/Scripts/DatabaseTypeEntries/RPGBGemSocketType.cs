using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGBGemSocketType : RPGBuilderDatabaseEntry
{
    public void UpdateEntryData(RPGBGemSocketType newEntryData)
    {
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
    }
}
