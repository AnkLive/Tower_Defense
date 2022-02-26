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
        EditorGUILayout.LabelField("������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(speed, new GUIContent("��������"), true);
        EditorGUILayout.PropertyField(speedDirection, new GUIContent("�������� ��������"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        serializedObject.ApplyModifiedProperties();
    }
}