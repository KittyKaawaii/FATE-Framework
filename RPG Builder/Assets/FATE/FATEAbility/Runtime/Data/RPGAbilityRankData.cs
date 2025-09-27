using System;
using System.Collections.Generic;
using BLINK.RPGBuilder.Templates;
using FATE.FATEAttribute.Runtime.Attribute;
using FATE.FATECombat.Runtime.Data;
using FATE.FATENPC.Runtime.DatabaseEntry;
using UnityEngine;

namespace FATE.FATEAbility.Runtime.Data
{
    [Serializable]
    public class RPGAbilityRankData
    {
        public bool ShowedInEditor;

        public int unlockCost;

        public string TooltipText;

        public AbilityActivationType activationType;

        public float castTime;

        public bool castInRun;

        public bool castBarVisible = true;

        public bool faceCursorWhileCasting = true;

        public bool faceCursorWhenOnCastStart = true;

        public bool faceCursorWhenOnCastEnd = true;

        public bool canBeUsedStunned;

        public bool animationTriggered;

        public bool comboStarsAfterCastComplete;

        public bool cancelStealth;

        public bool canUseWhileMounted;

        [RPGDataList] public List<RequirementsData.RequirementGroup> Requirements =
            new List<RequirementsData.RequirementGroup>();

        public bool UseRequirementsTemplate;

        public RequirementsTemplate RequirementsTemplate;

        public TARGET_TYPES targetType;

        public bool isToggle, isToggleCostOnTrigger;

        public float toggledTriggerInterval;

        public int MaxUnitHit = 1;

        public float minRange;

        public float maxRange;

        public float standTimeDuration;

        public bool canRotateInStandTime;

        public float castSpeedSlowAmount;

        public float castSpeedSlowTime;

        public float castSpeedSlowRate;

        public float AIAttackTime = 1;

        public float coneDegree;

        public int ConeHitCount = 1;

        public float ConeHitInterval;

        public float AOERadius;

        public int AOEHitCount = 1;

        public float AOEHitInterval;

        public float linearWidth;

        public float linearHeight;

        public float linearLength;

        public float projectileSpeed;

        public float projectileDistance;

        public float projectileAngleSpread;

        public int projectileCount = 1;

        public float firstProjectileDelay;

        public float projectileDelay;

        public float projectileDuration = 5;

        public float projectileComeBackTime;

        public float projectileComeBackSpeed;

        public bool isProjectileComeBack;

        public float projectileNearbyUnitDistanceMax;

        public float projectileNearbyUnitMaxHit;

        public bool isProjectileNearbyUnit;

        public bool projectileDestroyedByEnvironment = true;

        public LayerMask projectileDestroyLayers;

        public bool projectileAffectedByGravity;

        public bool projectileShootOnClickPosition;

        public float projectileDistanceMaxForNPC = 50;

        public bool mustLookAtTarget = true;

        public float squareWidth;

        public float squareLength;

        public float squareHeight;

        public float groundRadius;

        public float groundRange;

        public float groundHitTime;

        public int groundHitCount = 1;

        public float groundHitInterval;

        public bool CanHitPlayer, CanHitAlly, CanHitNeutral = true, CanHitEnemy = true, CanHitSelf, CanHitPet, CanHitOwner;

        public bool UsedOnALly;

        public bool LookAtTargetDuringCombatAction;

        public bool LookAtTargetOnCombatAction;

        public GameObject projectileEffect;

        [HideInInspector] public string projectileSocketName;

        [HideInInspector] public string projectileTargetSocketName;

        public RPGBNodeSocket projectileNodeSocket;

        public RPGBNodeSocket projectileTargetNodeSocket;

        public bool projectileUseNodeSocket;

        public bool projectileTargetUseNodeSocket;

        public bool projectileParentedToCaster;

        [HideInInspector] public AudioClip projectileSound;

        public SoundTemplate projectileSoundTemplate;

        public bool projectileSoundParentedToEffect;

        public bool useCustomCollision;

        public RPGNpc.NPCColliderType projectileColliderType;

        public Vector3 colliderCenter, colliderSize;

        public float colliderRadius, colliderHeight;

        public GameObject groundVisualEffect;

        public Vector3 effectPositionOffset;

        public float groundVisualEffectDuration = 5;

        public bool hitEffectUseSocket;

        public GameObject hitEffect;

        public float hitEffectDuration;

        [HideInInspector] public string hitEffectSocketName;

        public RPGBNodeSocket hitEffectNodeSocket;

        public Vector3 hitEffectPositionOffset;

        public bool hitAttachedToNode;

        public float channelTime;

        public float groundLeapDuration;

        public float groundLeapHeight;

        public float groundLeapSpeed;

        public LayerMask groundLeapBlockLayers;

        public bool isAttackSpeedCooldown;

        public bool isAttackSpeedGCD;

        public float cooldown;

        public bool isGCD;

        public bool startCDOnActivate = true;

        public bool CanUseDuringGCD;

        public bool isSharingCooldown;

        [HideInInspector] public string cooldownTag;

        public RPGBAbilityCooldownTag abilityCooldownTag;

        [RPGDataList] public List<AbilityEffectsApplied> effectsApplied = new List<AbilityEffectsApplied>();

        [RPGDataList] public List<AbilityEffectsApplied> casterEffectsApplied = new List<AbilityEffectsApplied>();


        public List<CombatData.AbilityAction> Actions = new List<CombatData.AbilityAction>();

        [RPGDataList] public List<VisualEffectEntry> VisualEffectEntries = new List<VisualEffectEntry>();

        [RPGDataList] public List<AnimationEntry> AnimationEntries = new List<AnimationEntry>();

        [RPGDataList] public List<SoundEntry> SoundEntries = new List<SoundEntry>();

        [RPGDataList] public List<RPGCombatDATA.CombatVisualEffect> visualEffects = new List<RPGCombatDATA.CombatVisualEffect>();

        [RPGDataList] public List<RPGCombatDATA.CombatVisualAnimation> visualAnimations =
            new List<RPGCombatDATA.CombatVisualAnimation>();

        [RPGDataList] public List<AbilityTagsData> tagsData = new List<AbilityTagsData>();

        [AbilityID] public int extraAbilityExecutedID;

        public RPGCombatDATA.CombatVisualActivationType extraAbilityExecutedActivationType;

    }
}