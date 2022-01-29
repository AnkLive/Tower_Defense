using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(Health)), CanEditMultipleObjects]
public class HealthCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Health health = (Health)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        health._amountOfHealth = EditorGUILayout.FloatField("��������", health._amountOfHealth);
        health._isShields = EditorGUILayout.Toggle("����", health._isShields);

        if  (health._isShields) health._amountOfShields = EditorGUILayout.FloatField(" ", health._amountOfShields);
        else health._amountOfShields = 0;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("������ �� �������");
        EditorGUILayout.ObjectField(health._healthSlider, typeof(Slider), true);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������� �������������� ������", EditorStyles.boldLabel);
        health._isAdditionalSettings = EditorGUILayout.Toggle(health._isAdditionalSettings);
        EditorGUILayout.Space();

        if (health._isAdditionalSettings) 
        {
            EditorGUILayout.LabelField("������� ����������", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            health._currentHealth = EditorGUILayout.FloatField("��������", health._currentHealth);

            if  (health._isShields) health._currentShields = EditorGUILayout.FloatField("����", health._currentShields);

            health._isDied = EditorGUILayout.Toggle("���� ���������", health._isDied);
        }
        serializedObject.ApplyModifiedProperties();
        
        if (GUI.changed) EditorUtility.SetDirty(health);
    }
}
