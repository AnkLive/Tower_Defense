using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FireRadiusGizmos)), CanEditMultipleObjects]
public class FireRadiusGizmosCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        FireRadiusGizmos fireRadiusGizmos = (FireRadiusGizmos)target;
        base.OnInspectorGUI();
        EditorGUI.BeginChangeCheck();
        fireRadiusGizmos._radius = EditorGUILayout.FloatField("Радиус стрельбы башни", fireRadiusGizmos._radius);

        if (EditorGUI.EndChangeCheck()) fireRadiusGizmos._sphereCollider.radius = fireRadiusGizmos._radius;
        serializedObject.ApplyModifiedProperties();
        
        if (GUI.changed) EditorUtility.SetDirty(fireRadiusGizmos);
    }
}
