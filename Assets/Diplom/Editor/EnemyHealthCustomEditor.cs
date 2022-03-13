using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyHealth)), CanEditMultipleObjects]
public class EnemyHealthCustomEditor : HealthCustomEditor 
{
    private SerializedProperty rewardForDestruction;

    public override void OnEnable()
    {
        base.OnEnable();
        rewardForDestruction = serializedObject.FindProperty("rewardForDestruction");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(rewardForDestruction, new GUIContent("Награда за уничтожение"), true);
        serializedObject.ApplyModifiedProperties();
    }
}
