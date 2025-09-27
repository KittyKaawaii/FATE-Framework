using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGWorldPosition : RPGBuilderDatabaseEntry
{
    [HideInInspector] public string _name;
    [HideInInspector] public string _fileName;
    [HideInInspector] public string displayName;

    
    public Vector3 position;
    public bool useRotation;
    public Vector3 rotation;

    public void UpdateEntryData(RPGWorldPosition newEntryData)
    {
        ID = newEntryData.ID;
        EntryName = newEntryData.EntryName;
        EntryFileName = newEntryData.EntryFileName;
        EntryDisplayName = newEntryData.EntryDisplayName;
        EntryIcon = newEntryData.EntryIcon;
        EntryDescription = newEntryData.EntryDescription;
        
        position = newEntryData.position;
        useRotation = newEntryData.useRotation;
        rotation = newEntryData.rotation;
    }
}