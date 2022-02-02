using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(Health)), CanEditMultipleObjects]
public class HealthCustomEditor : Editor
{
    private Health health;
    public void Awake()
    {
        health = (Health)target;
    }

    public override void OnInspectorGUI()
    {
        var style = new GUIStyle(GUI.skin.button);
        style = EditorStyles.wordWrappedLabel;
        style.normal.textColor = Color.red;
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        
        if (health._slider != null && health._sliderFillImage != null && health._sliderBottomImage != null) 
        {
            EditorGUI.BeginChangeCheck();
            health._amountOfHealth = EditorGUILayout.FloatField("Здоровье", health._amountOfHealth);

            if (EditorGUI.EndChangeCheck()) 
            {
                health.SetParemeters(health._currentHealth, health._amountOfHealth, health._slider, Color.red, Color.green);
            }
            EditorGUI.BeginChangeCheck();
            health._isShields = EditorGUILayout.Toggle("Щиты", health._isShields);
            if  (health._isShields) 
            {
                health._amountOfShields = EditorGUILayout.FloatField(health._amountOfShields);
                health.SetParemeters(health._currentShields, health._amountOfShields, health._slider, Color.green, Color.blue);
            }
            else 
            {
                health.SetParemeters(health._currentHealth, health._amountOfHealth, health._slider, Color.red, Color.green);
                health._amountOfShields = 0;
                health._currentShields = 0;
            }
        }
        else 
        {   
            EditorGUILayout.LabelField("Ошибка: требуется указать все необходимые ссылки в дополнительных параметрах",style);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Дополнительные параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        health._slider = (Slider)EditorGUILayout.ObjectField("Ссылка на слайдер", health._slider, typeof(Slider), true);
        health._sliderFillImage = (Image)EditorGUILayout.ObjectField("Fill Slider", health._sliderFillImage, typeof(Image), true);
        health._sliderBottomImage = (Image)EditorGUILayout.ObjectField("Bottom Slider", health._sliderBottomImage, typeof(Image), true);
        EditorGUILayout.Space();
        
        if (health._slider != null && health._sliderFillImage != null && health._sliderBottomImage != null) 
        {
            EditorGUILayout.LabelField("Показать дополнительные данные", EditorStyles.boldLabel);
            health._isAdditionalSettings = EditorGUILayout.Toggle(health._isAdditionalSettings);
            EditorGUILayout.Space();

            if (health._isAdditionalSettings) 
            {
                EditorGUILayout.LabelField("Текущее показатели", EditorStyles.boldLabel);
                EditorGUILayout.Space();
                health._currentHealth = EditorGUILayout.FloatField("Здоровье", health._currentHealth);

                if  (health._isShields) health._currentShields = EditorGUILayout.FloatField("Щиты", health._currentShields);
                else 
                {
                    health._amountOfShields = 0;
                    health._currentShields = 0;
                }
                health._isDied = EditorGUILayout.Toggle("Враг уничтожен", health._isDied);
            }
        }
        serializedObject.ApplyModifiedProperties();
        
        if (GUI.changed) EditorUtility.SetDirty(health);
    }
}
