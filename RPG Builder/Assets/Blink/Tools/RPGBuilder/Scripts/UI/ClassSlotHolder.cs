using BLINK.RPGBuilder.Managers;
using FATE.FATEClass.Runtime.DatabaseEntry;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BLINK.RPGBuilder.UIElements
{
    public class ClassSlotHolder : MonoBehaviour
    {
        public Image icon;
        public TextMeshProUGUI className;
        public Image selectedBorder;
        public int classIndex;

        public void Init(RPGClass thisClass, int index)
        {
            icon.sprite = thisClass.EntryIcon;
            className.text = thisClass.EntryDisplayName;
            classIndex = index;
        }

        public void ClickSelect()
        {
            MainMenuManager.Instance.SelectClass(classIndex);
        }

        public void SelectGender()
        {
            MainMenuManager.Instance.SelectGender(classIndex);
        }
    }
}