using UnityEngine;

public interface IDamage
{
    GameObject _obj { get; set; }
    float _countDamage { get; set; }
    float _cooldown { get; set; }
    float _timeStamp{ get; set; }
    void IsDamage(GameObject TrackingObj);
    void Subscribe();
    void Unsubscribe();
    void UpdateTimeStamp();
}
