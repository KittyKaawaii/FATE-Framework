using FATE.FATECustomAttribute.Runtime.AttributeParam;
using UnityEditor;
using UnityEngine;

namespace FATE.FATECustomAttribute.Editor.AttributeProperty
{
    [CustomPropertyDrawer(typeof(DisplayNameAttribute))]
    public class DisplayNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            if (attribute is DisplayNameAttribute displayName && !string.IsNullOrEmpty(displayName.label) && !string.IsNullOrWhiteSpace(displayName.label) && displayName.label != "")
            {
                label.text = displayName.label;
            }

            EditorGUILayout.PropertyField(property, label, true);

        }
    }
}