using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ObjRotation)), CanEditMultipleObjects]
public class ObjRotationCustomEditor : Editor
{
    private SerializedProperty obj, defaultObjRotation, trackingX, trackingY, trackingZ;
    private void OnEnable()
    {
        obj = serializedObject.FindProperty("_obj");
        defaultObjRotation = serializedObject.FindProperty("_defaultObjRotation");
        trackingX = serializedObject.FindProperty("_trackingX");
        trackingY = serializedObject.FindProperty("_trackingY");
        trackingZ = serializedObject.FindProperty("_trackingZ");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Характеристики", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        //obj = (GameObject)EditorGUILayout.ObjectField("Объект", obj, typeof(GameObject), true);
        EditorGUILayout.PropertyField(obj);
        /*tracking._isShields = EditorGUILayout.Toggle("Щиты", tracking._isShields);

        if  (tracking._isShields) tracking._amountOfShields = EditorGUILayout.FloatField(" ", tracking._amountOfShields);
        else tracking._amountOfShields = 0; */
        serializedObject.Update();
        serializedObject.ApplyModifiedProperties();
    }
}
