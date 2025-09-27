using System;
using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using FATE.FATEItem.Runtime.Data;
using UnityEngine;

namespace FATE.FATEItem.Runtime.DatabaseEntry
{
    public class RPGItem : RPGBuilderDatabaseEntry
    {
        [HideInInspector] public string _name;
        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public Sprite icon;

    
        [HideInInspector] public string equipmentSlot;
        public RPGBArmorSlot ArmorSlot;
        [HideInInspector] public string itemType;
        public RPGBItemType ItemType;
        [HideInInspector] public string weaponType;
        public RPGBWeaponType WeaponType;
        [HideInInspector] public string armorType;
        public RPGBArmorType ArmorType;
        [HideInInspector] public string slotType;
        public RPGBWeaponHandSlot WeaponSlot;
        [HideInInspector] public string rarity;
        public RPGBItemRarity ItemRarity;
    
        public string itemModelName;
        public GameObject weaponModel;
        public Material modelMaterial;

        [Serializable]
        public class WeaponPositionData
        {
            public int raceID = -1;

            [Serializable]
            public class GenderPositionData
            {
                public Vector3 CombatPositionInSlot = Vector3.zero;
                public Vector3 CombatRotationInSlot = Vector3.zero;
                public Vector3 CombatScaleInSlot = Vector3.one;
                public Vector3 RestPositionInSlot = Vector3.zero;
                public Vector3 RestRotationInSlot = Vector3.zero;
                public Vector3 RestScaleInSlot = Vector3.one;
            
                public Vector3 CombatPositionInSlot2 = Vector3.zero;
                public Vector3 CombatRotationInSlot2 = Vector3.zero;
                public Vector3 CombatScaleInSlot2 = Vector3.one;
                public Vector3 RestPositionInSlot2 = Vector3.zero;
                public Vector3 RestRotationInSlot2 = Vector3.zero;
                public Vector3 RestScaleInSlot2 = Vector3.one;
            }
            public List<GenderPositionData> genderPositionDatas = new List<GenderPositionData>();
        }
        public List<WeaponPositionData> weaponPositionDatas = new List<WeaponPositionData>();
        public bool showWeaponPositionData;
        public List<WeaponTransform> WeaponTransforms = new List<WeaponTransform>();
        public bool UseWeaponTransformTemplate;
        public WeaponTransformTemplate WeaponTransformTemplate;
    
        public float AttackSpeed;
        public int minDamage;
        public int maxDamage;

        public int autoAttackAbilityID = -1;

        [Serializable]
        public class ITEM_STATS
        {
            public int statID = -1;
            public float amount;
            public bool isPercent;
        }

        public List<ITEM_STATS> stats = new List<ITEM_STATS>();

        public List<RPGItemDATA.RandomizedStatData> randomStats = new List<RPGItemDATA.RandomizedStatData>();
        public int randomStatsMax;
    
        public int sellPrice;
        public int convertToCurrency = -1;
        public int sellCurrencyID = -1;
        public int buyPrice;
        public int buyCurrencyID = -1;
        public int stackLimit = 1;
        public string description;

        public bool dropInWorld;
        public GameObject itemWorldModel;
        public float durationInWorld = 60f;
        public int worldInteractableLayer;

        public int enchantmentID = -1;
        public bool isEnchantmentConsumed;
    
        [Serializable]
        public class SOCKETS_DATA
        {
            [HideInInspector] public string socketType;
            public RPGBGemSocketType GemSocketType;
        }
        public List<SOCKETS_DATA> sockets = new List<SOCKETS_DATA>();
    
        [Serializable]
        public class GEM_DATA
        {
            [HideInInspector] public string socketType;
            public RPGBGemSocketType GemSocketType;
        
            [Serializable]
            public class GEM_STATS
            {
                public int statID = -1;
                public float amount;
                public bool isPercent;
            }
            public List<GEM_STATS> gemStats = new List<GEM_STATS>();
        }
        public GEM_DATA gemData = new GEM_DATA();
    
        public List<RequirementsData.RequirementGroup> Requirements = new List<RequirementsData.RequirementGroup>();
        public bool UseRequirementsTemplate;
        public RequirementsTemplate RequirementsTemplate;
    
        public List<RPGCombatDATA.ActionAbilityDATA> actionAbilities = new List<RPGCombatDATA.ActionAbilityDATA>();

        public List<GameActionsData.GameAction> GameActions = new List<GameActionsData.GameAction>();
        public bool UseGameActionsTemplate;
        public GameActionsTemplate GameActionsTemplate;

        public BodyCullingTemplate BodyCullingTemplate;
    
        public void UpdateEntryData(RPGItem newEntryData)
        {
            ID = newEntryData.ID;
            EntryName = newEntryData.EntryName;
            EntryFileName = newEntryData.EntryFileName;
            EntryDisplayName = newEntryData.EntryDisplayName;
            EntryIcon = newEntryData.EntryIcon;
            EntryDescription = newEntryData.EntryDescription;
        
            ItemType = newEntryData.ItemType;
            WeaponType = newEntryData.WeaponType;
            ArmorType = newEntryData.ArmorType;
            WeaponSlot = newEntryData.WeaponSlot;
            itemModelName = newEntryData.itemModelName;
            ArmorSlot = newEntryData.ArmorSlot;
            weaponModel = newEntryData.weaponModel;
            modelMaterial = newEntryData.modelMaterial;
            WeaponTransforms = newEntryData.WeaponTransforms;
            UseWeaponTransformTemplate = newEntryData.UseWeaponTransformTemplate;
            WeaponTransformTemplate = newEntryData.WeaponTransformTemplate;
            AttackSpeed = newEntryData.AttackSpeed;
            minDamage = newEntryData.minDamage;
            maxDamage = newEntryData.maxDamage;
            stats = newEntryData.stats;
            sellPrice = newEntryData.sellPrice;
            buyPrice = newEntryData.buyPrice;
            stackLimit = newEntryData.stackLimit;
            convertToCurrency = newEntryData.convertToCurrency;
            sellCurrencyID = newEntryData.sellCurrencyID;
            buyCurrencyID = newEntryData.buyCurrencyID;
            Requirements = newEntryData.Requirements;
            GameActions = newEntryData.GameActions;
            UseGameActionsTemplate = newEntryData.UseGameActionsTemplate;
            GameActionsTemplate = newEntryData.GameActionsTemplate;
            autoAttackAbilityID = newEntryData.autoAttackAbilityID;
            ItemRarity = newEntryData.ItemRarity;
            dropInWorld = newEntryData.dropInWorld;
            itemWorldModel = newEntryData.itemWorldModel;
            durationInWorld = newEntryData.durationInWorld;
            randomStats = newEntryData.randomStats;
            enchantmentID = newEntryData.enchantmentID;
            isEnchantmentConsumed = newEntryData.isEnchantmentConsumed;
            sockets = newEntryData.sockets;
            gemData = newEntryData.gemData;
            actionAbilities = newEntryData.actionAbilities;
            randomStatsMax = newEntryData.randomStatsMax;
            worldInteractableLayer = newEntryData.worldInteractableLayer;
            UseRequirementsTemplate = newEntryData.UseRequirementsTemplate;
            RequirementsTemplate = newEntryData.RequirementsTemplate;
            BodyCullingTemplate = newEntryData.BodyCullingTemplate;
        }
    }
}