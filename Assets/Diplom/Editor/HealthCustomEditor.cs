using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Health), true), CanEditMultipleObjects]
public class HealthCustomEditor : Editor
{
    private bool _isAdditionalSettings = false;
    private SerializedProperty amountOfHealth, currentHealth, amountOfShields, currentShields, 
    slider, sliderTopImage, sliderBottomImage, isDied, isShields, hitEffect;
    

    public virtual void OnEnable()
    {
        amountOfHealth = serializedObject.FindProperty("amountOfHealth");
        currentHealth = serializedObject.FindProperty("currentHealth");
        amountOfShields = serializedObject.FindProperty("amountOfShields");
        currentShields = serializedObject.FindProperty("currentShields");
        slider = serializedObject.FindProperty("slider");
        sliderTopImage = serializedObject.FindProperty("sliderTopImage");
        sliderBottomImage = serializedObject.FindProperty("sliderBottomImage");
        isDied = serializedObject.FindProperty("isDied");
        isShields = serializedObject.FindProperty("isShields");
        hitEffect = serializedObject.FindProperty("hitEffect");
    }

    public override void OnInspectorGUI()
    {
        var style = new GUIStyle(GUI.skin.button);
        style = EditorStyles.wordWrappedLabel;
        style.normal.textColor = Color.red;
        serializedObject.Update();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(amountOfHealth, new GUIContent("��������"), true);
        EditorGUILayout.PropertyField(isShields, new GUIContent("����"), true);
        EditorGUILayout.PropertyField(amountOfShields, new GUIContent(" "), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.PropertyField(slider, new GUIContent("������ �� �������"), true);
        EditorGUILayout.PropertyField(sliderTopImage, new GUIContent("Top slider"), true);
        EditorGUILayout.PropertyField(sliderBottomImage, new GUIContent("Bottom slider"), true);
        EditorGUILayout.PropertyField(hitEffect, new GUIContent("hit Effect"), true);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������� �������������� ������", EditorStyles.boldLabel);
        _isAdditionalSettings = EditorGUILayout.Toggle(_isAdditionalSettings);
        EditorGUILayout.Space();

        if (_isAdditionalSettings) 
        {
            EditorGUILayout.LabelField("������� ����������", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(currentHealth, new GUIContent("��������"), true);
            EditorGUILayout.PropertyField(currentShields, new GUIContent("����"), true);
            EditorGUILayout.PropertyField(isDied, new GUIContent("���������"), true);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
