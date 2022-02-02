using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Damage)), CanEditMultipleObjects]
public class DamageCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Damage damage = (Damage)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        damage._countDamage = EditorGUILayout.FloatField("Количество наносимого урона", damage._countDamage);
        damage._cooldown = EditorGUILayout.FloatField("Скорость перезарядки", damage._cooldown);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Дополнительные параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        damage._shutEffect = (ParticleSystem)EditorGUILayout.ObjectField("Ссылка на эффект", damage._shutEffect, typeof(ParticleSystem), true);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(damage);
    }
}
