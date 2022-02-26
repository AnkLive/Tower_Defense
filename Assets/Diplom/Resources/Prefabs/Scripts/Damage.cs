using UnityEngine;

public abstract class Damage : MonoBehaviour, IDamage
{
    public abstract GameObject _obj { get; set; }
    public abstract float _countDamage { get; set; }
    public abstract float _cooldown { get; set; }
    public abstract float _timeStamp { get; set; }

    public virtual void IsDamage(GameObject TrackingObj) => ((IDamage)this)._obj = TrackingObj;

    public virtual void Subscribe() => gameObject.GetComponent<Tracking>().isDamageAction += IsDamage;

    public virtual void Unsubscribe() => gameObject.GetComponent<Tracking>().isDamageAction -= IsDamage;

    public virtual void UpdateTimeStamp() => _timeStamp = _cooldown;
}
