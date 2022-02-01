using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectManager)), CanEditMultipleObjects]
public class EnemyManagerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        ObjectManager enemyManager = (ObjectManager)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_allEnemiesList"), new GUIContent("Список врагов на сцене"), true);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_allTowersList"), new GUIContent("Список башен на сцене"), true);
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(enemyManager);
    }
}