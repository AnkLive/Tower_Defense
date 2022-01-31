using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawn)), CanEditMultipleObjects]
public class EnemySpawnCustomEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        EnemySpawn enemySpawn = (EnemySpawn)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("ѕараметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        enemySpawn._spawn = (GameObject)EditorGUILayout.ObjectField("—сылка на точку спавна", enemySpawn._spawn, typeof(GameObject), true);
        enemySpawn._waveManager = (WaveManager)EditorGUILayout.ObjectField("—сылка на менеджер волн", enemySpawn._waveManager, typeof(WaveManager), true);
        serializedObject.ApplyModifiedProperties();
        
        if (GUI.changed) EditorUtility.SetDirty(enemySpawn);
    }
}
