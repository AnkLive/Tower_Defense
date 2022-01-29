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

        if (_currentHealth <= 0)  _isDied = true;
    }
}
