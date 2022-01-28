using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public bool _isShields { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public bool _isAdditionalSettings { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public float _amountOfHealth { get; set; }
    [field: SerializeField, HideInInspector]
    public float _currentHealth { get; set; }
    [field: SerializeField, HideInInspector]
    public float _amountOfShields { get; set; }
    [field: SerializeField, HideInInspector]
    public float _currentShields { get; set; }
    [field: SerializeField, HideInInspector]
    public Slider _healthSlider;
    [field: SerializeField, HideInInspector]
    public bool _isDied { get; set; } = false;

    void Start()
    {
        _currentHealth = _amountOfHealth;
        _healthSlider.maxValue = _amountOfHealth;
        _healthSlider.value = _amountOfHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _healthSlider.value = _currentHealth;
        if (_currentHealth <= 0)
        {
            _isDied = true;
        }
    }
}

[CustomEditor(typeof(Health)), CanEditMultipleObjects]
public class HealthCustomEditor : Editor
{

    public override void OnInspectorGUI()
    {
        Health health = (Health)target;
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Характеристики", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        health._amountOfHealth = EditorGUILayout.FloatField("Здоровье", health._amountOfHealth);
        health._isShields = EditorGUILayout.Toggle("Щиты", health._isShields);

        if  (health._isShields) health._amountOfShields = EditorGUILayout.FloatField(" ", health._amountOfShields);
        else health._amountOfShields = 0;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Параметры", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Ссылка на слайдер");
        EditorGUILayout.ObjectField(health._healthSlider, typeof(Slider), true);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Показать дополнительные настройки", EditorStyles.boldLabel);
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

        if (GUI.changed)
        {
            EditorUtility.SetDirty(health);
        }
    }
}
