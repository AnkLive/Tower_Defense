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
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        health._amountOfHealth = EditorGUILayout.FloatField("Здоровье", health._amountOfHealth);
        health._isShields = EditorGUILayout.Toggle("Щиты", health._isShields);

        if  (health._isShields) health._amountOfShields = EditorGUILayout.FloatField(" ", health._amountOfShields);
        else health._amountOfShields = 0;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Дополнительные параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Ссылка на слайдер");
        EditorGUILayout.ObjectField(health._healthSlider, typeof(Slider), true);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Показать дополнительные данные", EditorStyles.boldLabel);
        health._isAdditionalSettings = EditorGUILayout.Toggle(health._isAdditionalSettings);
        EditorGUILayout.Space();

        if (health._isAdditionalSettings) 
        {
            EditorGUILayout.LabelField("Текущее показатели", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            health._currentHealth = EditorGUILayout.FloatField("Здоровье", health._currentHealth);

            if  (health._isShields) health._currentShields = EditorGUILayout.FloatField("Щиты", health._currentShields);

            health._isDied = EditorGUILayout.Toggle("Враг уничтожен", health._isDied);
        }
        serializedObject.ApplyModifiedProperties();
        
        if (GUI.changed) EditorUtility.SetDirty(health);
    }
}
