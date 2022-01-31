using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyManager)), CanEditMultipleObjects]
public class EnemyManagerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EnemyManager enemyManager = (EnemyManager)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_allEnemyList"), new GUIContent("������ ������ �� �����"), true);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(enemyManager);
    }
}