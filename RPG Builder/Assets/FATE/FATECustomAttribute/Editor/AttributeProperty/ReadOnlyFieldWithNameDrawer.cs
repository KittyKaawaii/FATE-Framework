using FATE.FATECustomAttribute.Runtime.AttributeParam;
using UnityEditor;
using UnityEngine;

namespace FATE.FATECustomAttribute.Editor.AttributeProperty
{
    [CustomPropertyDrawer(typeof(ReadOnlyFieldWithNameAttribute))]
    public class ReadOnlyFieldWithNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //bool previousGUIState = GUI.enabled;

            GUI.enabled = false;
            
            if (attribute is ReadOnlyFieldWithNameAttribute displayName && !string.IsNullOrEmpty(displayName.label) && !string.IsNullOrWhiteSpace(displayName.label) && displayName.label != "")
            {
                label.text = displayName.label;
            }

            EditorGUILayout.PropertyField(property, label, true);

                //GUI.enabled = previousGUIState;
        }
    }
}