using System.Collections.Generic;
using UnityEngine;

public class MashinegunDamage : Damage
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
        gameObject.GetComponent<Tracking>().isTrackingAction += IsTracking;
        base.Subscribe();
    }

    private void Start() => UpdateTimeStamp();

    public override void IsDamage(GameObject TrackingObj)
    {
        base.IsDamage(TrackingObj);

        if (_timeStamp <= Time.time)
        {
            
            foreach (var item in _shotEffect)
            {
                item.Play(true);
            }
            _obj.GetComponent<Health>().TakeDamage(_countDamage);
            _timeStamp = Time.time + _cooldown;
        }
        
    }

    public void IsTracking(bool value) 
    {
        if (_timeStamp <= Time.time) 
        {
            if(CheckSettings() && !_shotSound.isPlaying && value)
            {
                _shotSound.Play();
            }
            else if (CheckSettings() && !value) 
            {
                _shotSound.Stop();
            }
        }
    }

    public override void UpdateTimeStamp() => base.UpdateTimeStamp();
    
    private void OnDisable() 
    {
        gameObject.GetComponent<Tracking>().isTrackingAction += IsTracking;
        base.Unsubscribe();
    }

    public override bool CheckSettings() => base.CheckSettings();
}
