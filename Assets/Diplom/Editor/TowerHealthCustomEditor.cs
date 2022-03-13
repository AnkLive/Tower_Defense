using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TowerHealth)), CanEditMultipleObjects]
public class TowerHealthCustomEditor : EnemyHealthCustomEditor 
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
        EditorGUILayout.PropertyField(price, new GUIContent("Стоимость покупки"), true);
    }
}
