using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [field: SerializeField, Header("Количество здоровья")]
    public float _amountOfHealth { get; set; }
    [field: SerializeField, Header("Текущее количество здоровья")]
    public float _currentHealth { get; set; }
    [SerializeField]
    private Slider _healthSlider;
    [field: SerializeField]
    public bool _isDied { get; set; } = false;

    void Start()
    {
        _currentHealth = _amountOfHealth;
        _healthSlider.maxValue = _amountOfHealth;
        _healthSlider.value = _amountOfHealth;
        _healthSlider.direction = Slider.Direction.RightToLeft;
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
