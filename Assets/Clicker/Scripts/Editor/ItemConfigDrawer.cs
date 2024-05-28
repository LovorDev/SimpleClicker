using Clicker.Scripts.Runtime.Config;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemConfig))]
public class ItemConfigDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUILayout.PropertyField(property.FindPropertyRelative("<ItemType>k__BackingField"), label);

        var valueCostPairs = property.FindPropertyRelative("<ValueCostPairs>k__BackingField");

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Value Cost Pairs");
        valueCostPairs.arraySize = EditorGUILayout.IntField(valueCostPairs.arraySize, GUILayout.Width(50));
        EditorGUILayout.EndHorizontal();
        
        EditorGUIUtility.labelWidth = 50;
        for (var i = 0; i < valueCostPairs.arraySize; i++)
        {
            var valueCostPair = valueCostPairs.GetArrayElementAtIndex(i);
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField($"{i + 1}) ", GUILayout.Width(20));
            EditorGUILayout.PropertyField(valueCostPair.FindPropertyRelative("<Value>k__BackingField"), GUIContent.none);
            EditorGUILayout.PropertyField(valueCostPair.FindPropertyRelative("<Cost>k__BackingField"), GUIContent.none);

            EditorGUILayout.EndHorizontal();
        }
    }
}