using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATEAbility.Runtime.Data;
using FATE.FATECombat.Runtime.Data;
using FATE.FATEDatabase.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATEAbility.Runtime.DatabaseEntry
{
    public class RPGAbility : RPGBuilderDatabaseEntry
    {
        [Header("-----BASE DATA-----")] [HideInInspector]
        public string _name;

        [HideInInspector] public string _fileName;
        [HideInInspector] public string displayName;
        [HideInInspector] public Sprite icon;

        public bool learnedByDefault;

        public AbilityType abilityType;


        public List<RPGAbilityRankData> ranks = new List<RPGAbilityRankData>();

        public void UpdateEntryData(RPGAbility newEntryData)
        {
            ID = newEntryData.ID;
            entryName = newEntryData.entryName;
            entryFileName = newEntryData.entryFileName;
            entryDisplayName = newEntryData.entryDisplayName;
            entryIcon = newEntryData.entryIcon;
            entryDescription = newEntryData.entryDescription;

            ranks = newEntryData.ranks;
            learnedByDefault = newEntryData.learnedByDefault;
            abilityType = newEntryData.abilityType;
        }

        public void CopyEntryData(RPGAbilityRankData original, RPGAbilityRankData copied)
        {
            original.TooltipText = copied.TooltipText;
            original.unlockCost = copied.unlockCost;
            original.activationType = copied.activationType;
            original.castTime = copied.castTime;
            original.castInRun = copied.castInRun;
            original.castBarVisible = copied.castBarVisible;
            original.faceCursorWhileCasting = copied.faceCursorWhileCasting;
            original.faceCursorWhenOnCastEnd = copied.faceCursorWhenOnCastEnd;
            original.faceCursorWhenOnCastStart = copied.faceCursorWhenOnCastStart;
            original.canBeUsedStunned = copied.canBeUsedStunned;
            original.animationTriggered = copied.animationTriggered;
            original.Requirements = copied.Requirements;
            original.UseRequirementsTemplate = copied.UseRequirementsTemplate;
            original.RequirementsTemplate = copied.RequirementsTemplate;
            original.comboStarsAfterCastComplete = copied.comboStarsAfterCastComplete;
            original.cancelStealth = copied.cancelStealth;
            original.AIAttackTime = copied.AIAttackTime;
            original.canUseWhileMounted = copied.canUseWhileMounted;

            original.targetType = copied.targetType;

            original.isToggle = copied.isToggle;
            original.isToggleCostOnTrigger = copied.isToggleCostOnTrigger;
            original.toggledTriggerInterval = copied.toggledTriggerInterval;


            original.MaxUnitHit = copied.MaxUnitHit;
            original.minRange = copied.minRange;
            original.maxRange = copied.maxRange;

            original.standTimeDuration = copied.standTimeDuration;
            original.canRotateInStandTime = copied.canRotateInStandTime;
            original.castSpeedSlowAmount = copied.castSpeedSlowAmount;
            original.castSpeedSlowTime = copied.castSpeedSlowTime;
            original.castSpeedSlowRate = copied.castSpeedSlowRate;

            original.coneDegree = copied.coneDegree;
            original.ConeHitCount = copied.ConeHitCount;
            original.ConeHitInterval = copied.ConeHitInterval;
            original.AOERadius = copied.AOERadius;
            original.AOEHitCount = copied.AOEHitCount;
            original.AOEHitInterval = copied.AOEHitInterval;
            original.linearWidth = copied.linearWidth;
            original.linearHeight = copied.linearHeight;
            original.linearLength = copied.linearLength;
            original.projectileSpeed = copied.projectileSpeed;
            original.projectileDistance = copied.projectileDistance;
            original.projectileAngleSpread = copied.projectileAngleSpread;
            original.projectileCount = copied.projectileCount;
            original.projectileDelay = copied.projectileDelay;
            original.firstProjectileDelay = copied.firstProjectileDelay;
            original.projectileComeBackTime = copied.projectileComeBackTime;
            original.projectileComeBackSpeed = copied.projectileComeBackSpeed;
            original.isProjectileComeBack = copied.isProjectileComeBack;
            original.projectileNearbyUnitDistanceMax = copied.projectileNearbyUnitDistanceMax;
            original.projectileNearbyUnitMaxHit = copied.projectileNearbyUnitMaxHit;
            original.isProjectileNearbyUnit = copied.isProjectileNearbyUnit;
            original.projectileDestroyedByEnvironment = copied.projectileDestroyedByEnvironment;
            original.projectileAffectedByGravity = copied.projectileAffectedByGravity;
            original.projectileShootOnClickPosition = copied.projectileShootOnClickPosition;
            original.projectileSoundTemplate = copied.projectileSoundTemplate;
            original.projectileDistanceMaxForNPC = copied.projectileDistanceMaxForNPC;
            original.mustLookAtTarget = copied.mustLookAtTarget;
            original.squareWidth = copied.squareWidth;
            original.squareLength = copied.squareLength;
            original.squareHeight = copied.squareHeight;
            original.groundRadius = copied.groundRadius;
            original.groundRange = copied.groundRange;
            original.groundHitTime = copied.groundHitTime;
            original.groundHitCount = copied.groundHitCount;
            original.groundHitInterval = copied.groundHitInterval;

            original.projectileEffect = copied.projectileEffect;
            original.projectileNodeSocket = copied.projectileNodeSocket;
            original.projectileTargetNodeSocket = copied.projectileTargetNodeSocket;
            original.hitEffectNodeSocket = copied.hitEffectNodeSocket;
            original.projectileUseNodeSocket = copied.projectileUseNodeSocket;
            original.projectileTargetUseNodeSocket = copied.projectileTargetUseNodeSocket;
            original.hitEffect = copied.hitEffect;
            original.hitEffectDuration = copied.hitEffectDuration;
            original.projectileParentedToCaster = copied.projectileParentedToCaster;
            original.projectileSound = copied.projectileSound;
            original.projectileSoundParentedToEffect = copied.projectileSoundParentedToEffect;
            original.useCustomCollision = copied.useCustomCollision;
            original.projectileColliderType = copied.projectileColliderType;
            original.projectileDestroyLayers = copied.projectileDestroyLayers;
            original.colliderCenter = copied.colliderCenter;
            original.colliderRadius = copied.colliderRadius;
            original.colliderSize = copied.colliderSize;
            original.colliderHeight = copied.colliderHeight;
            original.groundVisualEffect = copied.groundVisualEffect;
            original.effectPositionOffset = copied.effectPositionOffset;
        
            original.CanHitPlayer = copied.CanHitPlayer;
            original.CanHitAlly = copied.CanHitAlly;
            original.CanHitNeutral = copied.CanHitNeutral;
            original.CanHitEnemy = copied.CanHitEnemy;
            original.CanHitSelf = copied.CanHitSelf;
            original.CanHitPet = copied.CanHitPet;
            original.CanHitOwner = copied.CanHitOwner;
        
            original.UsedOnALly = copied.UsedOnALly;
            original.LookAtTargetDuringCombatAction = copied.LookAtTargetDuringCombatAction;
            original.LookAtTargetOnCombatAction = copied.LookAtTargetOnCombatAction;

            original.channelTime = copied.channelTime;
            original.groundLeapDuration = copied.groundLeapDuration;
            original.groundLeapHeight = copied.groundLeapHeight;
            original.groundLeapSpeed = copied.groundLeapSpeed;
            original.groundLeapBlockLayers = copied.groundLeapBlockLayers;

            original.isAttackSpeedCooldown = copied.isAttackSpeedCooldown;
            original.isAttackSpeedGCD = copied.isAttackSpeedGCD;
            original.cooldown = copied.cooldown;
            original.isGCD = copied.isGCD;
            original.startCDOnActivate = copied.startCDOnActivate;
            original.CanUseDuringGCD = copied.CanUseDuringGCD;
            original.isSharingCooldown = copied.isSharingCooldown;
            original.abilityCooldownTag = copied.abilityCooldownTag;

            original.effectsApplied = new List<AbilityEffectsApplied>();
            for (var index = 0; index < copied.effectsApplied.Count; index++)
            {
                AbilityEffectsApplied newRef = new AbilityEffectsApplied
                {
                    chance = copied.effectsApplied[index].chance,
                    target = copied.effectsApplied[index].target,
                    EffectID = copied.effectsApplied[index].EffectID,
                    effectRank = copied.effectsApplied[index].effectRank,
                    isSpread = copied.effectsApplied[index].isSpread,
                    spreadDistanceMax = copied.effectsApplied[index].spreadDistanceMax,
                    spreadUnitMax = copied.effectsApplied[index].spreadUnitMax,
                    tooltipText = copied.effectsApplied[index].tooltipText
                };
                original.effectsApplied.Add(newRef);
            }
        
            original.casterEffectsApplied = new List<AbilityEffectsApplied>();
            for (var index = 0; index < copied.casterEffectsApplied.Count; index++)
            {
                AbilityEffectsApplied newRef = new AbilityEffectsApplied();
                newRef.chance = copied.casterEffectsApplied[index].chance;
                newRef.target = copied.casterEffectsApplied[index].target;
                newRef.EffectID = copied.casterEffectsApplied[index].EffectID;
                newRef.effectRank = copied.casterEffectsApplied[index].effectRank;
                newRef.isSpread = copied.casterEffectsApplied[index].isSpread;
                newRef.spreadDistanceMax = copied.casterEffectsApplied[index].spreadDistanceMax;
                newRef.spreadUnitMax = copied.casterEffectsApplied[index].spreadUnitMax;
                original.casterEffectsApplied.Add(newRef);
            }

            original.Actions = new List<CombatData.AbilityAction>();
            for (var index = 0; index < copied.Actions.Count; index++)
            {
                CombatData.AbilityAction newRef = new CombatData.AbilityAction
                {
                    RequirementsTarget = copied.Actions[index].RequirementsTarget,
                    RequirementsTemplate = copied.Actions[index].RequirementsTemplate,
                    ActionsTarget = copied.Actions[index].ActionsTarget,
                    GameActionsTemplate = copied.Actions[index].GameActionsTemplate,
                };
                original.Actions.Add(newRef);
            }

            original.VisualEffectEntries = new List<VisualEffectEntry>();
            for (var index = 0; index < copied.VisualEffectEntries.Count; index++)
            {
                VisualEffectEntry newVisualEffectEntry = new VisualEffectEntry
                {
                    ActivationType = copied.VisualEffectEntries[index].ActivationType,
                    Template = copied.VisualEffectEntries[index].Template,
                    NodeSocket = copied.VisualEffectEntries[index].NodeSocket,
                    ParentedToCaster = copied.VisualEffectEntries[index].ParentedToCaster,
                    UseNodeSocket = copied.VisualEffectEntries[index].UseNodeSocket,
                    Duration = copied.VisualEffectEntries[index].Duration,
                    Delay = copied.VisualEffectEntries[index].Delay,
                    Scale = copied.VisualEffectEntries[index].Scale,
                    PositionOffset = copied.VisualEffectEntries[index].PositionOffset,
                };

                original.VisualEffectEntries.Add(newVisualEffectEntry);
            }

            original.AnimationEntries = new List<AnimationEntry>();
            for (var index = 0; index < copied.AnimationEntries.Count; index++)
            {
                AnimationEntry newAnimationEntry = new AnimationEntry
                {
                    ActivationType = copied.AnimationEntries[index].ActivationType,
                    Template = copied.AnimationEntries[index].Template,
                    Delay = copied.AnimationEntries[index].Delay,
                    ShowWeapons = copied.AnimationEntries[index].ShowWeapons,
                    ShowWeaponsDuration = copied.AnimationEntries[index].ShowWeaponsDuration,
                    ModifySpeed = copied.AnimationEntries[index].ModifySpeed,
                    ModifierSpeed = copied.AnimationEntries[index].ModifierSpeed,
                    SpeedParameterName = copied.AnimationEntries[index].SpeedParameterName,
                };
                original.AnimationEntries.Add(newAnimationEntry);
            }

            original.SoundEntries = new List<SoundEntry>();
            for (var index = 0; index < copied.SoundEntries.Count; index++)
            {
                SoundEntry newAnimationEntry = new SoundEntry
                {
                    ActivationType = copied.SoundEntries[index].ActivationType,
                    Template = copied.SoundEntries[index].Template,
                    Delay = copied.SoundEntries[index].Delay,
                };
                original.SoundEntries.Add(newAnimationEntry);
            }

            original.tagsData = new List<AbilityTagsData>();
            for (var index = 0; index < copied.tagsData.Count; index++)
            {
                AbilityTagsData newRef = new AbilityTagsData
                {
                    tag = copied.tagsData[index].tag, effectID = copied.tagsData[index].effectID
                };
                original.tagsData.Add(newRef);
            }

            original.Actions = new List<CombatData.AbilityAction>();
            for (var index = 0; index < copied.Actions.Count; index++)
            {
                CombatData.AbilityAction newRef = new CombatData.AbilityAction
                {
                    RequirementsTarget = copied.Actions[index].RequirementsTarget,
                    RequirementsTemplate = copied.Actions[index].RequirementsTemplate,
                    ActionsTarget = copied.Actions[index].ActionsTarget,
                    GameActionsTemplate = copied.Actions[index].GameActionsTemplate,
                };
                original.Actions.Add(newRef);
            }

            original.extraAbilityExecutedID = copied.extraAbilityExecutedID;
            original.extraAbilityExecutedActivationType = copied.extraAbilityExecutedActivationType;

            original.Requirements = new List<RequirementsData.RequirementGroup>();
            for (var index = 0; index < copied.Requirements.Count; index++)
            {
                RequirementsData.RequirementGroup newGroup = new RequirementsData.RequirementGroup
                {
                    checkCount = copied.Requirements[index].checkCount,
                    requiredCount = copied.Requirements[index].requiredCount,
                };

                foreach (var newData in copied.Requirements[index].Requirements)
                {
                    RequirementsData.Requirement requirement = new RequirementsData.Requirement
                    {
                        type = newData.type,
                        condition = newData.condition,
                        AbilityID = newData.AbilityID,
                        BonusID = newData.BonusID,
                        RecipeID = newData.RecipeID,
                        ResourceID = newData.ResourceID,
                        EffectID = newData.EffectID,
                        NPCID = newData.NPCID,
                        StatID = newData.StatID,
                        FactionID = newData.FactionID,
                        ComboID = newData.ComboID,
                        RaceID = newData.RaceID,
                        LevelsID = newData.LevelsID,
                        ClassID = newData.ClassID,
                        SpeciesID = newData.SpeciesID,
                        ItemID = newData.ItemID,
                        CurrencyID = newData.CurrencyID,
                        PointID = newData.PointID,
                        TalentTreeID = newData.TalentTreeID,
                        SkillID = newData.SkillID,
                        SpellbookID = newData.SpellbookID,
                        WeaponTemplateID = newData.WeaponTemplateID,
                        EnchantmentID = newData.EnchantmentID,
                        GearSetID = newData.GearSetID,
                        GameSceneID = newData.GameSceneID,
                        QuestID = newData.QuestID,
                        DialogueID = newData.DialogueID,

                        Knowledge = newData.Knowledge,
                        State = newData.State,
                        Comparison = newData.Comparison,
                        Value = newData.Value,
                        Ownership = newData.Ownership,
                        ItemCondition = newData.ItemCondition,
                        Progression = newData.Progression,
                        Entity = newData.Entity,
                        PointType = newData.PointType,
                        DialogueNodeState = newData.DialogueNodeState,
                        EffectCondition = newData.EffectCondition,
                        AmountType = newData.AmountType,

                        Amount1 = newData.Amount1,
                        Amount2 = newData.Amount2,
                        Float1 = newData.Float1,
                        Consume = newData.Consume,
                        BoolBalue1 = newData.BoolBalue1,
                        BoolBalue2 = newData.BoolBalue2,
                        BoolBalue3 = newData.BoolBalue3,
                        IsPercent = newData.IsPercent,

                        EffectTag = newData.EffectTag,
                        EffectType = newData.EffectType,
                        FactionStance = newData.FactionStance,
                        ItemType = newData.ItemType,
                        WeaponType = newData.WeaponType,
                        WeaponSlot = newData.WeaponSlot,
                        ArmorType = newData.ArmorType,
                        ArmorSlot = newData.ArmorSlot,
                        Gender = newData.Gender,
                        QuestState = newData.QuestState,
                        DialogueNode = newData.DialogueNode,
                    };
                    newGroup.Requirements.Add(requirement);
                }

                original.Requirements.Add(newGroup);
            }
        }

    }
}