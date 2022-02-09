using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public event Action<float> takeDamageAction;
    private GameObject _ref;
    [field: SerializeField, HideInInspector]
    public float _countDamage { get; set; }
    [field: SerializeField, HideInInspector]
    public ParticleSystem _shutEffect;
    [field: SerializeField, HideInInspector]
    public float _cooldown { get; set; }
    private float _timeStamp;
    
    private void Awake() => gameObject.GetComponent<Tracking>().isDamageAction += IsDamage;
    
    private void Start() => _timeStamp = _cooldown;

    private void IsDamage(GameObject obj)
    {
        _ref = obj;

        if (_timeStamp <= Time.time)
        {
            _shutEffect.Play();
            takeDamageAction?.Invoke(_countDamage);
            //obj.GetComponent<Health>().TakeDamage(_countDamage);
            _timeStamp = Time.time + _cooldown;
        }

    }

    private void OnDisable() => gameObject.GetComponent<Tracking>().isDamageAction -= IsDamage;
}
