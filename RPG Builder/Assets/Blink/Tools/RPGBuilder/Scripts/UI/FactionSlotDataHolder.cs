using System.Collections;
using System.Collections.Generic;
using BLINK.RPGBuilder.Characters;
using BLINK.RPGBuilder.Combat;
using BLINK.RPGBuilder.Managers;
using FATE.FATECombat.Runtime.Data;
using FATE.FATEFaction.Runtime.DatabaseEntry;
using FATE.FATEFaction.Runtime.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactionSlotDataHolder : MonoBehaviour
{
    public Image factionIcon, factionProgressBar;
    public TextMeshProUGUI factionNameText, factionDescriptionText, factionXPText, factionStanceText;

    public void Init(CharacterEntries.FactionEntry factionEntry)
    {
        RPGFaction factionREF = GameDatabase.Instance.GetFactions()[factionEntry.ID];
        factionIcon.sprite = factionREF.EntryIcon;

        factionNameText.text = factionREF.EntryDisplayName;
        if(factionDescriptionText!=null)factionDescriptionText.text = factionREF.EntryDescription;
        if (factionREF.FactionStances.Count > 0)
        {
            int pointsRequired = factionREF.FactionStances[factionEntry.stanceIndex].PointsRequired;
            factionXPText.text = factionEntry.currentPoint + " / " + pointsRequired;
            factionProgressBar.fillAmount = (float) ((float) factionEntry.currentPoint / (float) pointsRequired);
        }
        
        string alignmentText = "";
        Color stanceColor = Color.white;
        switch (FactionManager.Instance.GetAlignment(GameDatabase.Instance.GetFactions()[factionEntry.ID],
            FactionManager.Instance.GetEntityStanceToFaction(GameState.playerEntity, GameDatabase.Instance.GetFactions()[factionEntry.ID])))
        {
            case CombatData.EntityAlignment.Ally:
                alignmentText = "Allied";
                stanceColor = Color.green;
                break;
            case CombatData.EntityAlignment.Neutral:
                alignmentText = "Neutral";
                stanceColor = Color.yellow;
                break;
            case CombatData.EntityAlignment.Enemy:
                alignmentText = "Enemy";
                stanceColor = Color.red;
                break;
        }

        factionStanceText.text = factionEntry.currentStance + " (" + alignmentText + ")";
        factionStanceText.color = stanceColor;

    }
}
