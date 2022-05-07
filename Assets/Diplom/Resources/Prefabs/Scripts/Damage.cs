using UnityEngine;

public abstract class Damage : MonoBehaviour, IEventSubscription
{
    public abstract GameObject _obj { get; set; }
    public abstract float _countDamage { get; set; }
    public abstract float _cooldown { get; set; }
    public float _timeStamp { get; set; }
    public abstract AudioSource _shotSound { get; set; }

    public virtual void IsDamage(GameObject TrackingObj) 
    {
        _obj = TrackingObj;
    }

    public void Subscribe() => gameObject.GetComponent<Tracking>().isDamageAction += IsDamage;

    public void Unsubscribe() => gameObject.GetComponent<Tracking>().isDamageAction -= IsDamage;

    public virtual void UpdateTimeStamp() => _timeStamp = _cooldown;

    public virtual bool CheckSettings() => PlayerPrefs.GetInt("sound") == 1 ? true : false;
}
