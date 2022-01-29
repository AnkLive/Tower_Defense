using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Options))]
[CanEditMultipleObjects]
public class OptionsCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Options options = (Options)target;
        base.OnInspectorGUI();
        options._dizmosIsVisible = EditorGUILayout.Toggle("��������� Gizmos ", options._dizmosIsVisible);
        EditorGUILayout.Space();

        if (GUILayout.Button("��������� ����� �� 90 ��������"))
        {
            options.RotateObjLeft();
            EditorGUILayout.Space();
        }

        if (GUILayout.Button("��������� ������ �� 90 ��������")) options.RotateObjRight();
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed) EditorUtility.SetDirty(options);
    }
}
