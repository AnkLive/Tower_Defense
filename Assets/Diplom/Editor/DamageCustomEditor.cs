using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Damage), true), CanEditMultipleObjects]
public class DamageCustomEditor : Editor
{
    private SerializedProperty countDamage, cooldown, shotEffect, shotSound;

    public virtual void OnEnable()
    {
        countDamage = serializedObject.FindProperty("countDamage");
        cooldown = serializedObject.FindProperty("cooldown");
        shotEffect = serializedObject.FindProperty("_shotEffect");
        shotSound = serializedObject.FindProperty("shotSound");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("Базовые параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(countDamage, new GUIContent("Количество наносимого урона"), true);
        EditorGUILayout.PropertyField(cooldown, new GUIContent("Скорость перезарядки"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Дополнительные параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(shotEffect, new GUIContent("Эффект выстрела"), true);
        EditorGUILayout.PropertyField(shotSound, new GUIContent("Звук выстрела"), true);
        serializedObject.ApplyModifiedProperties();
    }
}
