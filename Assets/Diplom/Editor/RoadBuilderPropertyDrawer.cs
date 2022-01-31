using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjReferenceList)), CanEditMultipleObjects]
public class ObjReferenceListPropertyDrawer : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        Rect labelPosition = new Rect(position.xMin, position.y, position.width, position.height);
        position = EditorGUI.PrefixLabel(labelPosition,  GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var objReferenceLabelRect = new Rect(labelPosition.x, position.y - 5f, position.width, position.height);
        var objNameLabelRect = new Rect(labelPosition.x, position.y + 15f, position.width, position.height);
        
        var objReferenceRect = new Rect(position.x, position.y + 20f, position.width, position.height);
        var objNameRect = new Rect(position.x, position.y + 40f, position.width, position.height);

        EditorGUI.LabelField(objReferenceLabelRect, "Ссылка на объект");
        EditorGUI.PropertyField(objReferenceRect, property.FindPropertyRelative("objReference"), GUIContent.none, true);
        EditorGUI.LabelField(objNameLabelRect, "Имя объекта");
        EditorGUI.PropertyField(objNameRect, property.FindPropertyRelative("objName"), GUIContent.none, true);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
        property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => base.GetPropertyHeight(property, label) + 50f;
}
