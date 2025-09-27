using System;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATECurrency.Runtime.DatabaseEntry
{
    public class RPGCurrency : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public Sprite icon;
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public string description;
    
    
        public int minValue;
        public int maxValue;
        public int baseValue;

        public int AmountToConvert;

        public int convertToCurrencyID = -1;

        public int lowestCurrencyID = -1;

        [Serializable]
        public class AboveCurrencyDATA
        {
            public int currencyID = -1;
        }

        public List<AboveCurrencyDATA> aboveCurrencies = new List<AboveCurrencyDATA>();

        public void UpdateEntryData(RPGCurrency newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;
        
            minValue = newEntryData.minValue;
            maxValue = newEntryData.maxValue;
            baseValue = newEntryData.baseValue;
            AmountToConvert = newEntryData.AmountToConvert;
            convertToCurrencyID = newEntryData.convertToCurrencyID;
            lowestCurrencyID = newEntryData.lowestCurrencyID;
            aboveCurrencies = newEntryData.aboveCurrencies;
        }
    }
}