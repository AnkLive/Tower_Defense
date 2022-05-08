using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : Health
{
    [SerializeField] private bool isDied;
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentShields;
    [SerializeField] private float amountOfHealth;
    [SerializeField] private float amountOfShields;
    [SerializeField] private Slider slider;
    [SerializeField] private Image sliderTopImage;
    [SerializeField] private Image sliderBottomImage;
    [SerializeField] private bool isShields;
    [SerializeField] private ParticleSystem hitEffect;

    [SerializeField] private int price;

    public override bool _isDied { get => isDied; set => isDied = value; }
    public override float _currentHealth { get => currentHealth; set => currentHealth = value; }
    public override float _currentShields { get => currentShields; set => currentShields = value; }
    public override float _amountOfHealth { get => amountOfHealth; set => amountOfHealth = value; }
    public override float _amountOfShields { get => amountOfShields; set => amountOfShields = value; }
    public override Slider _slider { get => slider; set => slider = value; }
    public override Image _sliderTopImage { get => sliderTopImage; set => sliderTopImage = value; }
    public override Image _sliderBottomImage { get => sliderBottomImage; set => sliderBottomImage = value; }
    public override bool _isShields { get => isShields; set => isShields = value; }
    public override ParticleSystem _hitEffect { get => hitEffect; set => hitEffect = value; }

    public int _price { get => price; set => price = value; }

    private void Awake()
    {
        _currentHealth = _amountOfHealth;

        if (_isShields) _currentShields = SetParemetersHealthBar(_amountOfShields, _slider, Color.green, Color.blue);
        else _currentHealth = SetParemetersHealthBar(_amountOfHealth, _slider, Color.red, Color.green);
    }

    public override void TakeDamage(float damage) => base.TakeDamage(damage);

    public override float SetParemetersHealthBar(float amount, Slider slider, Color topColor, Color bottomColor) =>
    base.SetParemetersHealthBar(amount, slider, topColor, bottomColor);
}
