using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : Damage
{
    [SerializeField] private List<ParticleSystem> _shotEffect = new List<ParticleSystem>();
    [SerializeField] private float countDamage;
    [SerializeField] private float cooldown;
    [SerializeField] private AudioSource shotSound;
    public override float _countDamage { get => countDamage; set => countDamage = value; }
    public override float _cooldown { get => cooldown; set => cooldown = value; }
    public override GameObject _obj { get; set; }
    public override AudioSource _shotSound { get => shotSound; set => shotSound = value; }
    
    private void Awake() => base.Subscribe();

    private void Start() => UpdateTimeStamp();

    public override void IsDamage(GameObject TrackingObj)
    {
        base.IsDamage(TrackingObj);

        if (_timeStamp <= Time.time)
        {
            Debug.Log(PlayerPrefs.GetInt("sound"));
            if(CheckSettings())
            {
                Debug.Log(PlayerPrefs.GetInt("sound"));
                _shotSound.Play();

            }
            foreach (var item in _shotEffect)
            {
                item.Play(true);
            }
            _obj.GetComponent<Health>().TakeDamage(_countDamage);
            _timeStamp = Time.time + _cooldown;
        }
    }

    public override void UpdateTimeStamp() => base.UpdateTimeStamp();
    
    private void OnDisable() => base.Unsubscribe();

    public override bool CheckSettings() => base.CheckSettings();
}
