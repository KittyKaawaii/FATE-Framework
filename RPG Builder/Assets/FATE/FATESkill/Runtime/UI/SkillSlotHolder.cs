using BLINK.RPGBuilder.Managers;
using FATE.FATESkill.Runtime.DatabaseEntry;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FATE.FATESkill.Runtime.UI
{
    public class SkillSlotHolder : MonoBehaviour
    {
        public Image skillIcon, skillBackground, skillEXPBar;
        public TextMeshProUGUI skillNameText, skillLevelText;
        private RPGSkill thisSkill;
        public Animator animator;
        

        public void InitSlot(RPGSkill skill)
        {
            skillIcon.sprite = skill.EntryIcon;
            skillBackground.sprite = skill.EntryIcon;
            skillEXPBar.fillAmount = RPGBuilderUtilities.getSkillEXPPercent(skill);
            skillLevelText.text = RPGBuilderUtilities.getSkillLevel(skill.ID) + " / " +
                                  GameDatabase.Instance.GetLevels()[skill.levelTemplateID].levels;
            skillNameText.text = skill.EntryDisplayName;
            thisSkill = skill;
            
            animator.SetBool("glowing", RPGBuilderUtilities.hasPointsToSpendInSkill(skill.ID));
        }

        public void SelectSkill()
        {
            UIEvents.Instance.OnShowSkillInfo(thisSkill);
        }
    }
}