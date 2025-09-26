using TMPro;
using UnityEngine;

namespace FATE.FATEQuest.Runtime.UI
{
    public class QuestObjectiveTextSlot : MonoBehaviour
    {
        public TextMeshProUGUI objectiveText;

        public void InitSlot(string text)
        {
            objectiveText.text = text;
        
        }
    }
}
