using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveManager)), CanEditMultipleObjects]
public class WaveManagerCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        WaveManager waveManager = (WaveManager)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        waveManager._timeBetweenWaves = EditorGUILayout.FloatField("����� ����� �������", waveManager._timeBetweenWaves);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_wavesList"), new GUIContent("�������� ����"), true);

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(waveManager);
    }
}
