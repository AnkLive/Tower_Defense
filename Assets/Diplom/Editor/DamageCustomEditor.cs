using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Damage)), CanEditMultipleObjects]
public class DamageCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Damage damage = (Damage)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        damage._countDamage = EditorGUILayout.FloatField("���������� ���������� �����", damage._countDamage);
        damage._cooldown = EditorGUILayout.FloatField("�������� �����������", damage._cooldown);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        damage._shutEffect = (ParticleSystem)EditorGUILayout.ObjectField("������ �� ������", damage._shutEffect, typeof(ParticleSystem), true);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(damage);
    }
}
