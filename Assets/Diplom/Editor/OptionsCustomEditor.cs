using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Options)), CanEditMultipleObjects]
public class OptionsCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Options options = (Options)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        options._dizmosIsVisible = EditorGUILayout.Toggle("Видимость Gizmos ", options._dizmosIsVisible);
        EditorGUILayout.Space();

        if (GUILayout.Button("Повернуть влево на 90 градусов")) options.RotateObjLeft();
        EditorGUILayout.Space();

        if (GUILayout.Button("Повернуть вправо на 90 градусов")) options.RotateObjRight();
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(options);
    }
}
