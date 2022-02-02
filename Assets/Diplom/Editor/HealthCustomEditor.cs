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
        EditorGUILayout.LabelField("���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        
        if (health._slider != null && health._sliderFillImage != null && health._sliderBottomImage != null) 
        {
            EditorGUI.BeginChangeCheck();
            health._amountOfHealth = EditorGUILayout.FloatField("��������", health._amountOfHealth);

            if (EditorGUI.EndChangeCheck()) 
            {
                health.SetParemeters(health._currentHealth, health._amountOfHealth, health._slider, Color.red, Color.green);
            }
            EditorGUI.BeginChangeCheck();
            health._isShields = EditorGUILayout.Toggle("����", health._isShields);
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
            EditorGUILayout.LabelField("������: ��������� ������� ��� ����������� ������ � �������������� ����������",style);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("�������������� ���������", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        health._slider = (Slider)EditorGUILayout.ObjectField("������ �� �������", health._slider, typeof(Slider), true);
        health._sliderFillImage = (Image)EditorGUILayout.ObjectField("Fill Slider", health._sliderFillImage, typeof(Image), true);
        health._sliderBottomImage = (Image)EditorGUILayout.ObjectField("Bottom Slider", health._sliderBottomImage, typeof(Image), true);
        EditorGUILayout.Space();
        
        if (health._slider != null && health._sliderFillImage != null && health._sliderBottomImage != null) 
        {
            EditorGUILayout.LabelField("�������� �������������� ������", EditorStyles.boldLabel);
            health._isAdditionalSettings = EditorGUILayout.Toggle(health._isAdditionalSettings);
            EditorGUILayout.Space();

            if (health._isAdditionalSettings) 
            {
                EditorGUILayout.LabelField("������� ����������", EditorStyles.boldLabel);
                EditorGUILayout.Space();
                health._currentHealth = EditorGUILayout.FloatField("��������", health._currentHealth);

                if  (health._isShields) health._currentShields = EditorGUILayout.FloatField("����", health._currentShields);
                else 
                {
                    health._amountOfShields = 0;
                    health._currentShields = 0;
                }
                health._isDied = EditorGUILayout.Toggle("���� ���������", health._isDied);
            }
        }
        serializedObject.ApplyModifiedProperties();
        
        if (GUI.changed) EditorUtility.SetDirty(health);
    }
}
