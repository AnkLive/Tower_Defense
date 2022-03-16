using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Tracking), true), CanEditMultipleObjects]
public class TrackingCustomEditor : Editor
{
    private bool _isAdditionalSettings = false;
    private SerializedProperty speedRotation, objectTrackingTag, objList, objTracking;

    public virtual void OnEnable()
    {
        speedRotation = serializedObject.FindProperty("speedRotation");
        objectTrackingTag = serializedObject.FindProperty("objectTrackingTag");
        objList = serializedObject.FindProperty("objList");
        objTracking = serializedObject.FindProperty("objTracking");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.LabelField("������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(speedRotation, new GUIContent("�������� ��������"), true);
        EditorGUILayout.PropertyField(objectTrackingTag, new GUIContent("��� �������������� �������"), true);
        EditorGUILayout.PropertyField(objList, new GUIContent("������ ��������"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������� �������������� ������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        _isAdditionalSettings = EditorGUILayout.Toggle("", _isAdditionalSettings);

        if  (_isAdditionalSettings) 
        {
            EditorGUILayout.PropertyField(objTracking, new GUIContent("������ ������� ������������� ��������"), true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
