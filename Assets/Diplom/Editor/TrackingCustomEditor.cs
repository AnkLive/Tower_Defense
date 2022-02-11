using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tracking)), CanEditMultipleObjects]
public class TrackingCustomEditor : Editor
{
    private bool _isAdditionalSettings = false;

    public override void OnInspectorGUI()
    {
        Tracking tracking = (Tracking)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        tracking._speedRotation = EditorGUILayout.FloatField("�������� ��������", tracking._speedRotation);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("������ ��������"), true);
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("_objectTrackingTag"), 
            new GUIContent("������ ������������� �������� �� �����"), 
            true
            );
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������� �������������� ������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        _isAdditionalSettings = EditorGUILayout.Toggle("", _isAdditionalSettings);

        if  (_isAdditionalSettings) 
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("_objTracking"), 
            new GUIContent("������ ������� ������������� ��������"), 
            true
            );
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(tracking);
    }
}
