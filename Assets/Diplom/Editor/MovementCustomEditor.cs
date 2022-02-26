using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Movement), true), CanEditMultipleObjects]
public class MovementCustomEditor : Editor
{
    private SerializedProperty speed, speedDirection;

    public virtual void OnEnable()
    {
        speed = serializedObject.FindProperty("speed");
        speedDirection = serializedObject.FindProperty("speedDirection");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Базовые параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(speed, new GUIContent("Скорость"), true);
        EditorGUILayout.PropertyField(speedDirection, new GUIContent("Скорость поворота"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Дополнительные параметры", EditorStyles.boldLabel);
        serializedObject.ApplyModifiedProperties();
    }
}