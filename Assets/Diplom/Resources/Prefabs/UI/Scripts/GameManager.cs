using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IEventSubscription
{
    [field: SerializeField] public Animator _controller { get; set; }
    public static event Action<bool> isPauseAction;
    [field: SerializeField] public bool _isPause { get; set; } = true;
    [field: SerializeField] public ObjectManager _objectManager { get; set; }
    [field: SerializeField] public Text _healthText { get; set; }
    [field: SerializeField] public Text _energyText { get; set; }
    [field: SerializeField] public int _health { get; private set; }
    [field: SerializeField] public int _energy { get; private set; }
    [field: SerializeField] public bool _isGame { get; set; } = true;
    private int _currentHealth;
    public int _currentEnergy { get; set; }

    private void Awake() => DestroyObjects.isPlayerHealthAction += SetHealth;

    private void Start() 
    {
        Subscribe();
        _currentHealth += _health;
        _currentEnergy += _energy;
        SetText(_currentHealth, _healthText);
        SetText(_currentEnergy, _energyText);
    }

    public void SetText(float value, Text textField) => textField.text = value.ToString();

    public void SetHealth(int value) 
    {
        _currentHealth -= value;

        if (_currentHealth < 0) _health = 0;
        SetText(_currentHealth, _healthText);
        _isGame = CheckHealth();

        if (!_isGame) StopGame(true);
    }

    public void SetEnergy(int value) 
    {
        _currentEnergy += value;
        SetText(_currentEnergy, _energyText);
    }

    private bool CheckHealth() => _currentHealth <= 0 ? false : true;

    public bool CheckEnergy(float value) => _currentEnergy >= value ? true : false;

    private void OnDisable() => Unsubscribe();

    public void Subscribe() => _objectManager.isDiedObjAction += SetEnergy;

    public void Unsubscribe() => _objectManager.isDiedObjAction -= SetEnergy;

    public void StopGame(bool value) 
    {
        Time.timeScale = value ? 0f : 1f;
        _controller.SetBool("isDimming", value);
        _isPause = value;
        isPauseAction?.Invoke(_isPause);
    }
}
