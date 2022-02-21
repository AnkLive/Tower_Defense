using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public Text _healthText { get; set; }
    [field: SerializeField] public Text _energyText { get; set; }
    [field: SerializeField] public float _health { get; private set; }
    [field: SerializeField] public float _energy { get; private set; }
    [field: SerializeField] public bool _isGame { get; set; } = true;
    private float _currentHealth;
    public float _currentEnergy { get; set; }

    private void Awake() => DestroyObjects.isPlayerHealthAction += SetHealth;

    private void Start() 
    {
        _currentHealth += _health;
        _currentEnergy += _energy;
        SetText(_currentHealth, _healthText);
        SetText(_currentEnergy, _energyText);
    }

    public void SetText(float value, Text textField) => textField.text = value.ToString();

    public void SetHealth(float value) 
    {
        _currentHealth -= value;

        if (_currentHealth < 0) _health = 0;
        SetText(_currentHealth, _healthText);
        _isGame = CheckHealth();

        if (!_isGame) Debug.Log("Stop");
    }

    private bool CheckHealth() => _currentHealth <= 0 ? false : true;

    public bool CheckEnergy(float value) => _currentEnergy >= value ? true : false;
}
