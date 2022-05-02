using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyHealth)), CanEditMultipleObjects]
public class EnemyHealthCustomEditor : HealthCustomEditor 
{
    private SerializedProperty rewardForDestruction, scoreForDestruction;

    public override void OnEnable()
    {
        base.OnEnable();
        rewardForDestruction = serializedObject.FindProperty("rewardForDestruction");
        scoreForDestruction = serializedObject.FindProperty("scoreForDestruction");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(rewardForDestruction, new GUIContent("Награда за уничтожение"), true);
        EditorGUILayout.PropertyField(scoreForDestruction, new GUIContent("Счет за уничтожение"), true);
        serializedObject.ApplyModifiedProperties();
    }
}
