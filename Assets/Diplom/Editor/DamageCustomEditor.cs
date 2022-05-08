using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Damage), true), CanEditMultipleObjects]
public class DamageCustomEditor : Editor
{
    private SerializedProperty countDamage, cooldown, shotEffect, shotSound, tracking;

    public virtual void OnEnable()
    {
        countDamage = serializedObject.FindProperty("countDamage");
        cooldown = serializedObject.FindProperty("cooldown");
        shotEffect = serializedObject.FindProperty("_shotEffect");
        shotSound = serializedObject.FindProperty("shotSound");
        tracking = serializedObject.FindProperty("tracking");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(countDamage, new GUIContent("���������� ���������� �����"), true);
        EditorGUILayout.PropertyField(cooldown, new GUIContent("�������� �����������"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(shotEffect, new GUIContent("������ ��������"), true);
        EditorGUILayout.PropertyField(shotSound, new GUIContent("���� ��������"), true);
        EditorGUILayout.PropertyField(tracking, new GUIContent("������ �� Tracking class"), true);
        serializedObject.ApplyModifiedProperties();
    }
}
