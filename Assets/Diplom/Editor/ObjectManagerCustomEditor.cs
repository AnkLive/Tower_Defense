using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectManager)), CanEditMultipleObjects]
public class EnemyManagerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        ObjectManager enemyManager = (ObjectManager)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_allEnemiesList"), new GUIContent("������ ������ �� �����"), true);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_allTowersList"), new GUIContent("������ ����� �� �����"), true);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(enemyManager);
    }
}