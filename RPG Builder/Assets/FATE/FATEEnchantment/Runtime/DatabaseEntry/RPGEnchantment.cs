using System.Collections.Generic;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;
using UnityEngine.Serialization;

namespace FATE.FATEEnchantment.Runtime.DatabaseEntry
{
    public class RPGEnchantment : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
    
        public enum ApplyRequirementType
        {
            ItemType, 
            ItemRarity,
            ArmorType,
            ArmorSlot,
            WeaponType,
            WeaponSlot
        }
    
        [System.Serializable]
        public class ApplyRequirements
        {
            public ApplyRequirementType type;
        
            [HideInInspector] public string itemType;
            public RPGBItemType ItemType;
            [FormerlySerializedAs("itemQuality")] public string itemRarity;
            public RPGBItemRarity ItemRarity;
            [HideInInspector] public string weaponType;
            public RPGBWeaponType WeaponType;
            [HideInInspector] public string armorType;
            public RPGBArmorType ArmorType;
            [HideInInspector] public string armorSlot;
            public RPGBArmorSlot ArmorSlot;
            [HideInInspector] public string weaponSlot;
            public RPGBWeaponHandSlot WeaponSlot;
        }
        public List<ApplyRequirements> applyRequirements = new List<ApplyRequirements>();
    
        [System.Serializable]
        public class CurrencyCost
        {
            public int currencyID = -1;
            public int amount;
        }
    
        [System.Serializable]
        public class ItemCost
        {
            public int itemID = -1;
            public int itemCount;
        }
    
        [System.Serializable]
        public class TierStat
        {
            public int statID = -1;
            public float amount;
            public bool isPercent;
        }
    
        [System.Serializable]
        public class EnchantmentTier
        {
            public List<CurrencyCost> currencyCosts = new List<CurrencyCost>();
            public List<ItemCost> itemCosts = new List<ItemCost>();

            public float successRate = 100f;
            public float enchantTime = 0f;
            public GameObject enchantingParticle;
        
            public int skillID = -1;
            public int skillXPAmount;
        
            public List<TierStat> stats = new List<TierStat>();
        }
        public List<EnchantmentTier> enchantmentTiers = new List<EnchantmentTier>();
    
        public void UpdateEntryData(RPGEnchantment newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;
        
            applyRequirements = newEntryData.applyRequirements;
            enchantmentTiers = newEntryData.enchantmentTiers;
        }
    }
}
