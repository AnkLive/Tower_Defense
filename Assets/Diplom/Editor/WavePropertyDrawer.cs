using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Wave)), CanEditMultipleObjects]
public class WavePropertyDrawer : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        property.serializedObject.Update();
        
        Rect labelPosition = new Rect(position.xMin, position.y, position.width, position.height);
        position = EditorGUI.PrefixLabel(labelPosition,  GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var enemyNameLabelRect = new Rect(labelPosition.x, position.y - 15f, position.width, position.height);
        var enemyCountLabelRect = new Rect(labelPosition.x, position.y + 5f, position.width, position.height);
        var timeBetweenEnemyLabelRect = new Rect(labelPosition.x, position.y + 30f, position.width, position.height);
        
        var enemyNameRect = new Rect(position.x, position.y + 20f, position.width, position.height);
        var enemyCountRect = new Rect(position.x, position.y + 45f, position.width, 20f);
        var timeBetweenEnemyRect = new Rect(position.x, position.y + 70f, position.width, 20f);

        EditorGUI.LabelField(enemyNameLabelRect, "Объект");
        EditorGUI.PropertyField(enemyNameRect, property.FindPropertyRelative("_enemyName"), GUIContent.none, true);
        EditorGUI.LabelField(enemyCountLabelRect, "Количество");
        EditorGUI.IntSlider(enemyCountRect, property.FindPropertyRelative("_enemyCount"), 1, 10, GUIContent.none);
        EditorGUI.LabelField(timeBetweenEnemyLabelRect, "Время между спавном");
        EditorGUI.Slider(timeBetweenEnemyRect, property.FindPropertyRelative("_timeBetweenEnemy"), 1, 10, GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
        property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => base.GetPropertyHeight(property, label) + 80f;
}
