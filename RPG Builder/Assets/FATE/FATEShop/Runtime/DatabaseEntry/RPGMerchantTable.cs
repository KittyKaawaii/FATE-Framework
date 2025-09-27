using System;
using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATEShop.Runtime.DatabaseEntry
{
    public class RPGMerchantTable : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;

        [Serializable]
        public class ON_SALE_ITEMS_DATA
        {
            public int itemID = -1;
            public int currencyID = -1;
            public int cost;
        }

        public List<ON_SALE_ITEMS_DATA> onSaleItems = new List<ON_SALE_ITEMS_DATA>();

        public void UpdateEntryData(RPGMerchantTable newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            onSaleItems = newEntryData.onSaleItems;
        }
    }
}