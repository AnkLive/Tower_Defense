using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Damage), true), CanEditMultipleObjects]
public class DamageCustomEditor : Editor
{
    private SerializedProperty countDamage, cooldown, shotEffect;

    public virtual void OnEnable()
    {
        countDamage = serializedObject.FindProperty("countDamage");
        cooldown = serializedObject.FindProperty("cooldown");
        shotEffect = serializedObject.FindProperty("_shotEffect");
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
        serializedObject.ApplyModifiedProperties();
    }
}
