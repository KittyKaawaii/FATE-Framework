using FATE.FATEQuest.Runtime.DatabaseEntry;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FATE.FATEQuest.Runtime.UI
{
    public class QuestTrackerSlotHolder : MonoBehaviour
    {
        public TextMeshProUGUI questNameText, globalCompletionText;
        public Transform objectiveTextParent;
        public Image backgroundImage;
        private RPGQuest thisQuest;

        public void InitSlot(RPGQuest _quest)
        {
            thisQuest = _quest;
        }

        public void ClickUntrackQuest()
        {
            WorldEvents.Instance.OnQuestUntracked(thisQuest);
        }

        public void ClickQuestName()
        {
            UIEvents.Instance.OnDisplayQuestInJournal(thisQuest);
        }
    }
}