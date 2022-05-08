using System.Collections.Generic;
using UnityEngine;

public class NormalDamage : Damage
{
    [SerializeField] private List<ParticleSystem> _shotEffect = new List<ParticleSystem>();
    [SerializeField] private float countDamage;
    [SerializeField] private float cooldown;
    [SerializeField] private AudioSource shotSound;
    [SerializeField] private Tracking tracking;
    public override float _countDamage { get => countDamage; set => countDamage = value; }
    public override float _cooldown { get => cooldown; set => cooldown = value; }
    public override GameObject _obj { get; set; }
    public override Tracking _tracking { get => tracking; set => tracking = value; }
    public override AudioSource _shotSound { get => shotSound; set => shotSound = value; }
    
    private void Awake() 
    {
        base.Subscribe();
    }

    private void Start() => UpdateTimeStamp();

    public override void IsDamage(GameObject TrackingObj)
    {
        base.IsDamage(TrackingObj);

        

        if (_timeStamp <= Time.time)
        {
            if(CheckSettings())
        {
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
    
    private void OnDisable() 
    {
        base.Unsubscribe();
    }

    public override bool CheckSettings() => base.CheckSettings();
}
