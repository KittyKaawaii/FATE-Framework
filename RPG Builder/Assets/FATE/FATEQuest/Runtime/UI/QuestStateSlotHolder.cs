using FATE.FATEQuest.Runtime.DatabaseEntry;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FATE.FATEQuest.Runtime.UI
{
    public class QuestStateSlotHolder : MonoBehaviour
    {
        public enum QuestSlotPanelType
        {
            interactionPanel,
            questJournal
        }

        private QuestSlotPanelType panelType;

        public Image icon, background;
        public TextMeshProUGUI questNameText;
        private RPGQuest thisQuest;

        public void InitSlot(RPGQuest quest, Color bgColor, Sprite stateIcon, QuestSlotPanelType _type)
        {
            panelType = _type;
            icon.sprite = stateIcon;
            questNameText.text = quest.EntryDisplayName;
            background.color = bgColor;
            thisQuest = quest;
        }

        public void ClickQuest()
        {
            if (panelType == QuestSlotPanelType.interactionPanel)
                UIEvents.Instance.OnDisplayQuest(thisQuest, true);
            else
                UIEvents.Instance.OnDisplayQuestInJournal(thisQuest);
        }
    }
}