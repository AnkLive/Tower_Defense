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
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(damage);
    }
}
