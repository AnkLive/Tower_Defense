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
    bool _isPause = false;
    
    private void Start() 
    {
        GameManager.isPauseAction += CheckPause;
        gameObject.GetComponent<Tracking>().isTrackingAction += IsTracking;
        base.Subscribe();
        UpdateTimeStamp();
    }

    public override void IsDamage(GameObject TrackingObj)
    {
        base.IsDamage(TrackingObj);

        if (_timeStamp <= Time.time)
        {
            if (_isPause) 
            {
                _shotSound.Pause();
            }
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
        GameManager.isPauseAction -= CheckPause;
        gameObject.GetComponent<Tracking>().isTrackingAction -= IsTracking;
        base.Unsubscribe();
    }

    public void CheckPause(bool value) 
    {
        if(value) 
        {
            _shotSound.Pause();
        } else if(CheckSettings() && !_shotSound.isPlaying && value && !value) 
        {
            _shotSound.Play();
        }
        _isPause = value;
    }

    public override bool CheckSettings() => base.CheckSettings();
}
