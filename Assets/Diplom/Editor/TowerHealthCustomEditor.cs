using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TowerHealth)), CanEditMultipleObjects]
public class TowerHealthCustomEditor : HealthCustomEditor 
{
    private SerializedProperty price;

    public override void OnEnable()
    {
        base.OnEnable();
        price = serializedObject.FindProperty("price");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(price, new GUIContent("Стоимость покупки"), true);
        serializedObject.ApplyModifiedProperties();
    }
}
