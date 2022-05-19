using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IEventSubscription
{
    [field: SerializeField] public Animator _controller { get; set; }
    public static event Action<bool> isPauseAction;
    public static event Action<bool> isGameOverAction;
    
    [field: SerializeField] public bool _isPause { get; set; } = false;
    [field: SerializeField] public ObjectManager _objectManager { get; set; }
    [field: SerializeField] public Text _healthText { get; set; }
    [field: SerializeField] public Text _energyText { get; set; }
    [field: SerializeField] public Text _scoreText { get; set; }
    [field: SerializeField] public Text _scoreWinText { get; set; }
    [field: SerializeField] public Text _newRecordText { get; set; }
    [field: SerializeField] public int _health { get; private set; }
    [field: SerializeField] public int _energy { get; private set; }
    [field: SerializeField] public int _score { get; private set; }
    [field: SerializeField] public bool _isGame { get; set; } = true;
    [field: SerializeField] public bool _isWin { get; set; } = true;
    private int _currentHealth;
    public int _currentEnergy { get; set; }
    public GameObject gameOverPanel, UIPanel, winPanel;
    public Menu menu;
    public SafePfers save;

    public Toggle pauseToggle;

    private void Start() 
    {
        DestroyObjects.isPlayerHealthAction += SetHealth;
        StopGame(true);
        _objectManager.isWinAction += isWin;
        Subscribe();
        _currentHealth += _health;
        _currentEnergy += _energy;
        SetText(_currentHealth, _healthText);
        SetText(_currentEnergy, _energyText);
    }

    private void OnDisable() {
        DestroyObjects.isPlayerHealthAction -= SetHealth;
        Unsubscribe();
    }

    public void SetText(float value, Text textField) => textField.text = value.ToString();
    public void SetText(string value, Text textField) => textField.text = value;

    public void SetHealth(int value) 
    {
        _currentHealth -= value;

        if (_currentHealth < 0) _health = 0;
        SetText(_currentHealth, _healthText);
        _isGame = CheckHealth();

        if (!_isGame) 
        {
            isDied();
            StopGame(true);
        }
    }

    public void SetEnergyAndScore(int energy, int score) 
    {
        _currentEnergy += energy;
        _score += score;
        SetText(_currentEnergy, _energyText);
        string scoreText = "Счет " + _score;
        SetText(scoreText, _scoreText);
    }

    private bool CheckHealth() => _currentHealth <= 0 ? false : true;

    public bool CheckEnergy(float value) => _currentEnergy >= value ? true : false;

    public void Subscribe() => _objectManager.isDiedObjAction += SetEnergyAndScore;

    public void Unsubscribe() => _objectManager.isDiedObjAction -= SetEnergyAndScore;

    public void StopGame(bool value) 
    {
        Time.timeScale = value ? 0f : 1f;
        _controller.SetBool("isDimming", value);
        _isPause = value;
        isPauseAction?.Invoke(_isPause);
        pauseToggle.isOn = _isPause;
    }

    public void StopGame(Toggle toggle) 
    {
        Time.timeScale = toggle.isOn ? 0f : 1f;
        _controller.SetBool("isDimming", toggle.isOn);
        _isPause = toggle.isOn;
        isPauseAction?.Invoke(_isPause);
    }

    public void isDied() 
    {
        _controller.SetBool("isDimming", true);
        isGameOverAction?.Invoke(true);
        menu.SetScreenVisibility(gameOverPanel);
        menu.SetScreenInvisibility(UIPanel);
        Time.timeScale = 1f;
    }

    public void isWin() 
    {
        _controller.SetBool("isDimming", true);
        save.BEST_RESULT = BestResult(_score);
        _scoreWinText.text = _score.ToString();
        menu.SetScreenVisibility(winPanel);
        menu.SetScreenInvisibility(UIPanel);
        SavingGameResults();
        Time.timeScale = 1f;
    }

    public void SavingGameResults() => save.TOTAL_SCORE += ResultGameScore(_currentEnergy, _currentHealth, _score);

    public int ResultGameScore(int energy, int health, int score) => energy * health + score;

    public int BestResult(int score) 
    {
        if (save.BEST_RESULT < score) 
        {
            _newRecordText.text = "Новый рекорд!";
            return score;
        }
        else 
        {
            return save.BEST_RESULT;
        }
    }
}
