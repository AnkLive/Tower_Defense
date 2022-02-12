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
        tracking._objectTrackingTag = EditorGUILayout.TextField("Тег отслеживаемого объекта", tracking._objectTrackingTag);
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
