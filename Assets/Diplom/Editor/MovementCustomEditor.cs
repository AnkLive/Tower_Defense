using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Movement)), CanEditMultipleObjects]
public class MovementCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Movement movement = (Movement)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        movement._speed = EditorGUILayout.FloatField("��������", movement._speed);
        movement._speedDirection = EditorGUILayout.FloatField("�������� ��������", movement._speedDirection);
        movement._isBoss = EditorGUILayout.Toggle("����", movement._isBoss);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(movement);
    }
}