using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjRotation)), CanEditMultipleObjects]
public class ObjRotationPropertyDrawer : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        property.serializedObject.Update();
        
        Rect labelPosition = new Rect(position.xMin, position.y, position.width, position.height);
        position = EditorGUI.PrefixLabel(labelPosition,  GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var objLabelRect = new Rect(labelPosition.x, position.y - 30f, position.width, position.height);
        var defaultObjRotationLabelRect = new Rect(labelPosition.x, position.y - 10f, position.width, position.height);
        var trackingXLabelRect = new Rect(labelPosition.x, position.y + 10f, position.width, position.height);
        var trackingYLabelRect = new Rect(labelPosition.x, position.y + 30f, position.width, position.height);
        var trackingZLabelRect = new Rect(labelPosition.x, position.y + 50f, position.width, position.height);
        
        var objRect = new Rect(position.x, position.y + 20f, position.width, position.height);
        var defaultObjRotationRect = new Rect(position.x, position.y + 40f, position.width, position.height);
        var trackingXRect = new Rect(position.x, position.y + 60f, position.width, position.height);
        var trackingYRect = new Rect(position.x, position.y + 80f, position.width, position.height);
        var trackingZRect = new Rect(position.x, position.y + 100f, position.width, position.height);

        EditorGUI.LabelField(objLabelRect, "Объект");
        EditorGUI.PropertyField(objRect, property.FindPropertyRelative("obj"), GUIContent.none, true);
        EditorGUI.LabelField(defaultObjRotationLabelRect, "Угол поворота по умолчанию");
        EditorGUI.PropertyField(defaultObjRotationRect, property.FindPropertyRelative("defaultObjRotation"), GUIContent.none, true);
        EditorGUI.LabelField(trackingXLabelRect, "Поворот по оси X");
        EditorGUI.PropertyField(trackingXRect, property.FindPropertyRelative("trackingX"), GUIContent.none, true);
        EditorGUI.LabelField(trackingYLabelRect, "Поворот по оси Y");
        EditorGUI.PropertyField(trackingYRect, property.FindPropertyRelative("trackingY"), GUIContent.none, true);
        EditorGUI.LabelField(trackingZLabelRect, "Поворот по оси Z");
        EditorGUI.PropertyField(trackingZRect, property.FindPropertyRelative("trackingZ"), GUIContent.none, true);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
        property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => base.GetPropertyHeight(property, label) + 100f;
}

