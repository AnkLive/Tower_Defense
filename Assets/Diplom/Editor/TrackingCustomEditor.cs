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
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        tracking._speedRotation = EditorGUILayout.FloatField("Скорость поворота", tracking._speedRotation);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Дополнительные параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_objList"), new GUIContent("Список объектов"), true);
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("_objectTrackingTag"), 
            new GUIContent("Список отслеживаемых объектов по тегам"), 
            true
            );
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Показать дополнительные данные", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        _isAdditionalSettings = EditorGUILayout.Toggle("", _isAdditionalSettings);

        if  (_isAdditionalSettings) 
        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("_objTracking"), 
            new GUIContent("Список текущих отслеживаемых объектов"), 
            true
            );
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(tracking);
    }
}
