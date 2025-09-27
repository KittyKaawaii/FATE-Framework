using FATE.FATECustomAttribute.Runtime.AttributeParam;
using UnityEditor;
using UnityEngine;

namespace FATE.FATECustomAttribute.Editor.AttributeProperty
{
    [CustomPropertyDrawer(typeof(ReadOnlyFieldAttribute))]
    public class ReadOnlyFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool previousGUIState = GUI.enabled;

            GUI.enabled = false;

            EditorGUILayout.PropertyField(property, label, true);

            GUI.enabled = previousGUIState;
        }
    }
}