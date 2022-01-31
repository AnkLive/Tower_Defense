using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveManager)), CanEditMultipleObjects]
public class WaveManagerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        WaveManager waveManager = (WaveManager)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        waveManager._timeBetweenWaves = EditorGUILayout.FloatField("Время между волнами", waveManager._timeBetweenWaves);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_wavesList"), new GUIContent("Редактор волн"), true);

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(waveManager);
    }
}
