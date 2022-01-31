using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyManager)), CanEditMultipleObjects]
public class EnemyManagerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        EnemyManager enemyManager = (EnemyManager)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_allEnemyList"), new GUIContent("Список врагов на сцене"), true);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(enemyManager);
    }
}