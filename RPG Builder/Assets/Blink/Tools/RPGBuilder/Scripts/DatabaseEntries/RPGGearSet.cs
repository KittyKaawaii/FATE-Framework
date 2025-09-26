using System;
using System.Collections;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

public class RPGGearSet : RPGBuilderDatabaseEntry
{
    [HideInInspector] public string _name;
    [HideInInspector] public string _fileName;
    [HideInInspector] public string displayName;
    
    [Serializable]
    public class itemInSet
    {
        public int itemID = -1;
    }
    public List<itemInSet> itemsInSet = new List<itemInSet>();
    
    [Serializable]
    public class GearSetTier
    {
        public int equippedAmount;
        
        [Serializable]
        public class GearSetTierStat
        {
            public int statID = -1;
            public float amount;
            public bool isPercent;
        }
        public List<GearSetTierStat> gearSetTierStats = new List<GearSetTierStat>();
        
    }
    public List<GearSetTier> gearSetTiers = new List<GearSetTier>();

    public void UpdateEntryData(RPGGearSet newEntryData)
    {
        ID = newEntryData.ID;
        entryName = newEntryData.entryName;
        entryFileName = newEntryData.entryFileName;
        entryDisplayName = newEntryData.entryDisplayName;
        entryIcon = newEntryData.entryIcon;
        entryDescription = newEntryData.entryDescription;
        
        itemsInSet = newEntryData.itemsInSet;
        gearSetTiers = newEntryData.gearSetTiers;
    }
}
