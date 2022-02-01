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
    public Slider _slider { get; set; }
    [field: SerializeField, HideInInspector]
    public bool _isDied { get; set; } = false;
    [field: SerializeField, HideInInspector]
    public Image _sliderFillImage { get; set; }
    [field: SerializeField, HideInInspector]
    public Image _sliderBottomImage { get; set; }
 
    private void Awake()
    {
        if (_isShields) SetParemeters(_currentShields, _amountOfShields, _slider, Color.green, Color.blue);
        else SetParemeters(_currentHealth, _amountOfHealth, _slider, Color.red, Color.green);
    }

    public void TakeDamage(float damage)
    {

        if (_currentHealth <= 0)  _isDied = true;
        else 
        {

            if (_isShields) 
            {
                _currentShields -= damage;

                if (_currentShields <= 0) 
                {
                    SetParemeters(_currentHealth, _amountOfHealth, _slider, Color.red, Color.green);
                    _isShields = false;
                }
            }
            else 
            {
                _currentHealth -= damage;
                _slider.value = _currentHealth;
            }
        }
    }

    public void SetParemeters(float current, float amount, Slider slider, Color a, Color b) 
    {
        current = amount;
        slider.maxValue = amount;
        slider.value = amount;
        _sliderFillImage.color = a;
        _sliderBottomImage.color = b;
    }
}
